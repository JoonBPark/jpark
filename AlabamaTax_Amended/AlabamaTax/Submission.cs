using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.IO;
namespace AlabamaTax
{
    /// <summary>
    /// Class encompassing the complete submission process, from loading data to validating with the web service.
    /// This is passed prerequisite information and callbacks for reporting its progress in the constructor.
    /// Then the Submit() method is run in a background thread.
    /// </summary>
    class Submission
    {
        private ItemChoiceType9 TransmitterType;
        private string TransmitterID;
        private string FEIN;
        private DateTime ReportingMonth;
        private bool Testing;
        private string Server;
        private string Database;
        private string Username;
        private string Password;
        private Create.ReportType ReportType;
        private Action<int, int> UpdateStatus;
        private Action<string> LogInfo;
        private Action Done;
        public Submission
            (Create.ReportType reportType
            , ItemChoiceType9 transmitterType
            , string transmitterID
            , string fein
            , DateTime reportingMonth
            , bool testing
            , string server
            , string database
            , string username
            , string password
            , Action<string> logInfo
            , Action<int, int> updateStatus
            , Action done
            )
        {
            ReportType = reportType;
            TransmitterType = transmitterType;
            TransmitterID = transmitterID;
            FEIN = fein;
            ReportingMonth = reportingMonth;
            Testing = testing;
            Server = server;
            Database = database;
            Username = username;
            Password = password;
            LogInfo = logInfo;
            UpdateStatus = updateStatus;
            Done = done;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.IntegratedSecurity = String.IsNullOrWhiteSpace(Username);
            builder.UserID = Username;
            builder.Password = Password;
            builder.InitialCatalog = Database;
            builder.DataSource = Server;
            conn.ConnectionString = builder.ToString();
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL connection error: " + ex.Message);
            }
            return conn;
        }
        public void Submit()
        {
            Transmission tr = new Transmission();
            MotorFuelsFiling motorFuels = new MotorFuelsFiling();
            String id = ID.New();

            SqlConnection conn = null;
            IEnumerable<PXDMV> rows = null;

            String ack = null;
            XDocument validation = null;
            #region Steps
            // In order to track progress, break the submission process into steps.
            // Each step is a lambda expression, which can access and modify variables
            // in the scope of Submit(), and create new variables limited to its own scope.
            Action[] steps =
            { () =>
                {
                    tr.TransmissionHeader = Create.TransmissionHeader
                        (agent: Create.Agent(ReportType)
                        , transmitterType: TransmitterType
                        , transmitterID: TransmitterID
                        , id: id
                        , testing: Testing
                        );
                }
            , () =>
                {
                    DateTime now = DateTime.Now;
                    motorFuels.SubmissionId = "ALMFET";
                    motorFuels.MotorFuelsHeader = Create.MotorFuelsHeader
                        (year: ReportingMonth.Year
                        , month: ReportingMonth.Month
                        , FEIN: FEIN
                        );
                }
            , () =>
                {
                    conn = GetConnection();
                    PXDMVReader reader = new PXDMVReader(conn, ReportingMonth);
                    rows = reader.Rows().ToArray(); // must use ToArray or ToList to force strict evaluation of query before closing reader
                    reader.Close();
                    conn.Close();
                }
            , () =>
                {
                    switch (ReportType)
                    {
                        case Create.ReportType.Carrier:
                            motorFuels.CarrierReport = AlabamaTax.Load.Carrier.Report(rows);
                            break;
                        case Create.ReportType.Distributor:
                            motorFuels.DistributorReport = AlabamaTax.Load.Distributor.Reports(ReportingMonth, rows).ToArray();
                            break;
                        default:
                            throw new Exception("Report type not supported.");
                    }

                    tr.MotorFuelsFiling = new MotorFuelsFiling[] { motorFuels };
                }
            , () =>
                {
                    LogInfo(String.Format("Submitting {0} report, this may take a long time", ReportType));
                    XDocument response = Client.NewSubmission(Testing, tr);
                    if (response != null)
                    {
                        ack = Client.AcknowledgementID(response);
                        LogInfo(String.Format("Submission {0} acknowledged", ack));
                    }
                    else
                    {
                        LogInfo("No response");
                    }
                }
            , () =>
                {
                    // Poll for validation
                    if (ack == "0") return;
                    const int pollSecondsBase = 30;
                    const int pollAttempts = 3;
                    for (int i = 1; validation == null && i <= pollAttempts; i++)
                    {
                        LogInfo(String.Format("Waiting {0} seconds before polling for validation", pollSecondsBase * i));
                        System.Threading.Thread.Sleep(pollSecondsBase * i * 1000);
                        LogInfo("Polling validation service");
                        validation = Client.Validation(Testing, acknowledgement: ack);
                    }
                }
            , () =>
                {
                    if (validation == null) LogInfo("No validation (failure)");
                    else
                    {
                        LogInfo("Received validation");
                        IEnumerable<ValidationError> errors = Client.ValidationErrors(validation);
                        if (errors == null) LogInfo("No errors! (success)");
                        else
                        {
                            LogInfo("There were errors in validation (failure)");
                            foreach (ValidationError err in errors)
                            {
                                LogInfo(err.ToString());
                            }
                        }
                    }
                }
            };
            #endregion
            UpdateStatus(0, steps.Length);
            try
            {
                int i = 0;
                foreach (Action step in steps)
                {
                    step();
                    //UpdateStatus(++i, steps.Length);
                }
            }
            catch (Exception e)
            {
                File.WriteAllText("exception_log.txt", e.ToString());
                LogInfo(e.Message);
                MessageBox.Show(e.Message);
                //UpdateStatus(0, steps.Length);
            }
            finally
            {
                Done();
            }
        }
    }
}
