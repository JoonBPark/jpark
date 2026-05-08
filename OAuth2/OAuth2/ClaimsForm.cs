using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
//using Infragistics.Win.UltraWinEditors;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PayloadUtils;
using static System.Net.Mime.MediaTypeNames;

namespace OAuth2
{
    public partial class ClaimsForm : Form
    {   
        // REBATE
        /* OLD: 20240515
        private const string ClientID = "b21c9ea5-1eff-467b-97a0-1af5613ad634";
        private const string ClientSecret = "MjVHHT5ZauLoNebjVprRH7ulYGyxtF/EGqjKOfKBpPg=";
        private const string Resource = "7a2b1852-1958-4161-ad3b-6a922aca5fbf";
        private const string SubscriptionKey = "c457beb7e0c749ad85b239666f9e6325";
        //private static string TokenUrl = "https://login.microsoftonline.com/fd799da1-bfc1-4234-a91c-72b3a1cb9e26/oauth2/token";
        //private static string PostUrl = @"https://apim-test1.azure.chevron.com/sales-management/rebates/v1/C2RebatesClaim";
        //private static string ConnString = @"Data Source=GPEELE-HP\SQL2017;Initial Catalog=Claims;Integrated Security=True";
        //private static string ConnString = @"Data Source=WSSRV09\SQL2017;Initial Catalog=Claims; UserID=sa;Password=Axsys1234";
        */

        private const string ClientID = "8ae78294-ba61-48bc-8b73-9661c2fca4f6";

        // 20260409: New Client Secret
        // OLD: private const string ClientSecret = "rhs8Q~8po_3pHsgB6ihtLUWc5ZygN71-hNDi1aVn";
        private const string ClientSecret = "enE8Q~apiReXGZqkZmJqVQ7s5AevNcVxFrjShbfn";
        
        private const string SubscriptionKey = "66f361fb645648db8812d4e6646c4578";
        private const string Resource = "1019c6e9-1fc4-46da-960f-9ac5b9bc3ebd";
        private static string TokenUrl = "https://login.microsoftonline.com/fd799da1-bfc1-4234-a91c-72b3a1cb9e26/oauth2/token";
        private static string PostUrl = @"https://apim.chevron.com/sales-management/rebates/v1/C2RebatesClaim";

        //LIVE
        private static string ConnString = @"Data Source=CO-SQL01;Initial Catalog=CHAMBERSAPP;Integrated Security=True";

        //TEST
        //private static string ConnString = @"Data Source=KRSTEKJPARK-LEN\SQLSRV2019;Initial Catalog=CHAMBERSAPP;Integrated Security=True";



        private const int NumberInBatch = 30;

        public ClaimsForm()
        {
            InitializeComponent();
        }
        public ClaimsForm(string connString)
        {
            ConnString = connString;
            InitializeComponent();
        }


        //string connString = @"Data Source=GPEELE-HP\SQL2017;Initial Catalog=Claims;Integrated Security=True";
        SqlDataAdapter daAdapter;
        DataSet dset;
        BindingSource bsource;

          //Add new record...
        private void btnOk_Click(object sender, EventArgs e)
        {
            Save(bsource.Position);
        }
     
       
        bool ValidateClaims(PX_Claim claim2check)
        {
            return true;
        }


        private void DataCollection_Load(object sender, EventArgs e)
        {
           

            using (var conn = new SqlConnection(ConnString))
            {
                

                daAdapter = new SqlDataAdapter("select * from PX_claim where Uploaded=0", conn);
                
                dset = new DataSet();
                daAdapter.Fill(dset);

                SqlCommandBuilder cb;

                cb = new SqlCommandBuilder(daAdapter);
                daAdapter.DeleteCommand = cb.GetDeleteCommand(true);
                daAdapter.UpdateCommand = cb.GetUpdateCommand(true);
                daAdapter.InsertCommand = cb.GetInsertCommand(true);


                bsource = new BindingSource();

                bsource.DataSource = dset.Tables[0];
                
                claimBindingNavigator.BindingSource = this.bsource;


                claimsIdTextBox.DataBindings.Add(new Binding("Text", bsource, "claimsid", true));
                deliveryDateDateTimePicker.Format = DateTimePickerFormat.Custom;
                deliveryDateDateTimePicker.CustomFormat = "yyyy-MM-dd";

                deliveryDateDateTimePicker.DataBindings.Add(new Binding("Value", bsource, "deliveryDate", true));
                txtRebate.DataBindings.Add(new Binding("Text", bsource, "rebateRate", true));
                txtProdcutCode.DataBindings.Add(new Binding("Text", bsource, "productCode", true));
                c2RebateAccountNumberTextBox.DataBindings.Add(new Binding("Text", bsource, "c2RebateAccountNum", true));
                txtDeliveredQuantity.DataBindings.Add(new Binding("Text", bsource, "deliveredQuantity", true));
                customerAccountNameTextBox.DataBindings.Add(new Binding("Text", bsource, "customerAccountName", true));
                marketerNameTextBox.DataBindings.Add(new Binding("Text", bsource, "marketerName", true));
                marketerEmailTextBox.DataBindings.Add(new Binding("Text", bsource, "marketerEmail", true));
                txtRebateNumber.DataBindings.Add(new Binding("Text", bsource, "marketerRebateNumber", true));
                clientIdTextBox.DataBindings.Add(new Binding("Text", bsource, "clientId", true));
                customerAccountNumberTextBox.DataBindings.Add(new Binding("Text", bsource, "customerAccountNum", true));
                txtPackageCode.DataBindings.Add(new Binding("Text", bsource, "packageCode", true));
             //   unitOfMeasureTextBox.DataBindings.Add(new Binding("Text", bsource, "UnitOfMeasure", true));

                dset.Tables[0].Columns["deliveryDate"].DefaultValue = DateTime.Today;  //Set the default value for new rows.
                                                                                       //this.clientIdTextBox.Text = "b21c9ea5-1eff-467b-97a0-1af5613ad634";

                //_______________________________________________________________________________________________________
                //Remove blanks
                deliveryDateDateTimePicker.Text = deliveryDateDateTimePicker.Text.TrimEnd();
                txtRebate.Text = txtRebate.Text.TrimEnd();
                txtProdcutCode.Text = txtProdcutCode.Text.TrimEnd();
                c2RebateAccountNumberTextBox.Text = c2RebateAccountNumberTextBox.Text.TrimEnd();
                txtDeliveredQuantity.Text = txtDeliveredQuantity.Text.TrimEnd();
                customerAccountNameTextBox.Text = customerAccountNameTextBox.Text.TrimEnd();
                marketerNameTextBox.Text = marketerNameTextBox.Text.TrimEnd();
                marketerEmailTextBox.Text = marketerEmailTextBox.Text.TrimEnd();
                txtRebateNumber.Text = txtRebateNumber.Text.TrimEnd();
                clientIdTextBox.Text = clientIdTextBox.Text.TrimEnd();
                customerAccountNumberTextBox.Text = customerAccountNumberTextBox.Text.TrimEnd();
                txtPackageCode.Text = txtPackageCode.Text.TrimEnd();

                //_______________________________________________________________________________________________________


                //Set position to first row
                if (dset.Tables[0].Rows.Count > 0)
                {
                    bsource.Position = 0;
                }

            }
        }


        private void btnHost_Click(object sender, EventArgs e)
        {
            Save(bsource.Position);  //20250515

            //No need to show this form, let's consolidate
            //
            string Error;
            if (BuildJsonPayloadFromDatabase(out Error,ConnString) == false)
            {
                MessageBox.Show(Error);
            }
            else
            {
                MessageBox.Show("All records sent successfully.");
            }
        }


        private bool BuildJsonPayloadFromDatabase(out string Error, string connection)
        {

            return PayloadUtils.PayloadUtils.BuildAndSendJsonPayloadFromDatabase(out Error,
                connection, ClientID, ClientSecret, Resource, SubscriptionKey, TokenUrl, PostUrl, true, 30);


            /*
            bool retval = false;
            Error = "";
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string token = OAuth2Static.GetClientCredentials(ClientID, ClientSecret, Resource, SubscriptionKey, TokenUrl, PostUrl);

            if (!string.IsNullOrEmpty(token))
            {
                using (ChevronEntities db = new ChevronEntities(DBUtils.GetConnectionString(connection)))
                {
                    List<Claim> allClaims = new List<Claim>();

                    allClaims = db.Set<Claim>().Where(x => x.Uploaded != true).ToList();  //Only include those records not Uploaded

                    if (allClaims.Any())
                    {
                        int eachRecord = 0;

                        int NumberOfBatches = ((allClaims.Count() + NumberInBatch - 1) / NumberInBatch);   //NumberOfBatches

                        //Each batch
                        for (int eachBatch = 0; eachBatch < NumberOfBatches; eachBatch++)
                        {
                            Claims claims = new Claims();
                            claims.claims = new List<Claim>();

                            for (int i = 0; i < NumberInBatch && eachRecord < allClaims.Count(); i++)
                            {
                                claims.claims.Add(allClaims[eachRecord]);
                                allClaims[eachRecord].Uploaded = true;
                                eachRecord++;
                            }
                            //Here we gave a batch
                            string payload;

                            try
                            {
                                payload = serializer.Serialize(claims);
                                string jsonFormatted = JValue.Parse(payload).ToString(Formatting.Indented);
                                DisplayJson jsonDisplay = new DisplayJson(jsonFormatted);
                                jsonDisplay.ShowDialog();
                            }
                            catch (Exception e1)
                            {
                                Error = Error + "Error serializing Batch:" + (eachBatch + 1).ToString() + " Error:" + e1.Message + "\r\n";
                                payload = "";
                                retval = false;
                            }
                            if (!string.IsNullOrEmpty(payload))
                            {
                                if (OAuth2Static.UseBearerToken(token, payload, SubscriptionKey, PostUrl, out string dataResult))   //Succesful
                                {
                                    try
                                    {
                                        db.SaveChanges();   //Update the database including the updated field.
                                        retval = true;
                                    }
                                    catch (Exception e)
                                    {
                                        Error = Error + "Error saving Batch:" + (eachBatch + 1).ToString() + " Error:" + e.Message + "\r\n";
                                        retval = false;
                                    }
                                }
                                else
                                {
                                    Error = Error + "Error sending Batch:" + (eachBatch + 1).ToString() + " Error:" + dataResult + "\r\n";
                                    //Unable to get payload...
                                    retval = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        Error = "No claims to process.";
                        retval = false;
                    }
                }
            }
            else
            {
                Error = "Unable to get token";
                retval = false;
            }
            return retval;  //Will be false if any failures occur
            */
        }

        private void Save(int rowIndex)
        {
            toolStripStatusLabel1.Text = "";
            using (var conn = new SqlConnection(ConnString))
            {
                daAdapter = new SqlDataAdapter("select * from px_claim where uploaded=0", conn);

                using (var cb = new SqlCommandBuilder(daAdapter))
                {
                    daAdapter.DeleteCommand = cb.GetDeleteCommand(true);
                    daAdapter.UpdateCommand = cb.GetUpdateCommand(true);
                    daAdapter.InsertCommand = cb.GetInsertCommand(true);
                    //This is the database row to update

                    DataRow daRow;
                    if (rowIndex < dset.Tables[0].Rows.Count && rowIndex != -1)
                    {
                        daRow = dset.Tables[0].Rows[rowIndex];
                    }
                    else
                    {
                        if (bsource.Current != null)
                        {
                            daRow = (DataRow)((DataRowView)bsource.Current).Row;
                        }
                        else
                        {
                            daRow = dset.Tables[0].NewRow();
                        }
                    }

                    daRow.BeginEdit();

                    //daRow["claimsId"] = this.claimsIdTextBox.Text;   //Don't update key field
                    //daRow["orderType"] = this.orderTypeTextBox.Text;
                    daRow["deliveryDate"] = this.deliveryDateDateTimePicker.Value.Date.ToString("yyyy-MM-dd"); //Make this a date.
                    
                    try
                    {
                        daRow["rebateRate"] = Convert.ToDouble(this.txtRebate.Text);
                    }
                    catch
                    {
                        daRow["rebateRate"] = 0.00;
                    }
                    daRow["rebateRate"] = this.txtRebate.Text;
                    daRow["productCode"] = this.txtProdcutCode.Text;
                    daRow["c2RebateAccountNum"] = this.c2RebateAccountNumberTextBox.Text;
                    daRow["DeliveredQuantity"] = this.txtDeliveredQuantity.Text;
                    daRow["customerAccountName"] = this.customerAccountNameTextBox.Text;
                    daRow["marketerEmail"] = this.marketerEmailTextBox.Text;
                    daRow["marketerRebateNumber"] = this.txtRebateNumber.Text;
                    daRow["clientId"] = this.clientIdTextBox.Text;
                    daRow["customerAccountNum"] = this.customerAccountNumberTextBox.Text;
                    daRow["packageCode"] = this.txtPackageCode.Text;
                    daRow["marketerName"] = this.marketerNameTextBox.Text;
//                    daRow["UnitOfMeasure"] = this.unitOfMeasureTextBox.Text;
                    daRow.EndEdit();

                    //rowIndex == -1 means no rows exist
                    //rowIndex >= rows.Count means a new record
                    //Otherwise, this is an update

                    if (rowIndex >= dset.Tables[0].Rows.Count || rowIndex == -1)
                    { 
                        dset.Tables[0].Rows.Add(daRow);
                    }
                    int numberOfRowsAffected = daAdapter.Update(dset);  //This updates the adapter with the dataset changes

                    // MessageBox.Show("Number of affected Rows = " + numberOfRowsAffected);
                    toolStripStatusLabel1.Text = numberOfRowsAffected + " record(s) saved";
                    dset.AcceptChanges();    //This tells the dataset to accept the changes.
                }
            }
        }

        private void claimBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            Save(bsource.Position);            
        }


        private void txtRebate_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbx = (sender as TextBox);
            String candidateText = txtbx.Text;
            // Retreat! Attempting to convert an empty string is not pretty
            if (String.IsNullOrEmpty(candidateText)) return;
            try
            {
                Convert.ToDouble(candidateText);
            }
            catch (Exception)
            {
                String allButTheLast = candidateText.Substring(0, candidateText.Length - 1);
                txtbx.Text = allButTheLast;
                txtbx.Select(txtbx.Text.Length, 0);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //If there is anything to delete


               using (var conn = new SqlConnection(ConnString))
               {
                    daAdapter = new SqlDataAdapter("select * from px_claims where uploaded=0", conn);
                    using (var cb = new SqlCommandBuilder(daAdapter))
                    {
                        daAdapter.UpdateCommand = cb.GetUpdateCommand(true);
                        daAdapter.DeleteCommand = cb.GetDeleteCommand(true);

                        int numberOfRowsAffected = daAdapter.Update(dset);
                        toolStripStatusLabel1.Text = numberOfRowsAffected + " database records deleted.";
                    }
               }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
