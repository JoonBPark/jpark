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
using System.Data.Entity.Core.EntityClient;
using PayloadUtils;

namespace OAuth2
{


    public partial class MSAForm : Form
    {

        private const string MSAClientID = "32216358-8762-4261-b0db-09d328eb79f6";
        private const string ClientSecret = "uaA8Q~hs2lwk_ux2Z1TYaRiGb-TNhbK2pT~S2cQ9";
        private const string Resource = "6b0a74c0-b074-4052-80db-9c9f3d85eedd";
        private const string SubscriptionKey = "66f361fb645648db8812d4e6646c4578";
        private static string TokenUrl = "https://login.microsoftonline.com/fd799da1-bfc1-4234-a91c-72b3a1cb9e26/oauth2/token";
        private static string PostUrl = @"https://apim.chevron.com/sales-management/delivery-confirmation/v2/msa";

        // LIVE
        private static string ConnString = @"Data Source=CO-SQL01;Initial Catalog=CHAMBERSAPP;Integrated Security=True";

        // TEST
        //private static string ConnString = @"Data Source = KRSTEKJPARK-LEN\SQLSRV2019;Initial Catalog = CHAMBERSAPP; User ID = sa; Password=Axsys12";


        private const int NumberInBatch = 30;

        public MSAForm()
        {
            InitializeComponent();
        }
        public MSAForm(string connString)
        {

        ConnString = connString;
            InitializeComponent();
        }
        
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
                daAdapter = new SqlDataAdapter("select * from PX_Cbpmsadelivery where Uploaded=0", conn);

                dset = new DataSet();
                daAdapter.Fill(dset);

                SqlCommandBuilder cb;

                cb = new SqlCommandBuilder(daAdapter);
                daAdapter.DeleteCommand = cb.GetDeleteCommand(true);
                daAdapter.UpdateCommand = cb.GetUpdateCommand(true);
                daAdapter.InsertCommand = cb.GetInsertCommand(true);

                bsource = new BindingSource();

                bsource.DataSource = dset.Tables[0];
                msaBindingNavigator.BindingSource = this.bsource;

                //1
                msiIdTextBox.DataBindings.Add(new Binding("Text", bsource, "ID", true));
                //2
               // txtCustomerUniqueID.DataBindings.Add(new Binding("Text", bsource, "customerUniqueId", true));
                //3
                txtMarketerReceiptNumber.DataBindings.Add(new Binding("Text", bsource, "marketerReceiptNum", true));

                //5
                txtOriginalMarketerReceiptNumber.DataBindings.Add(new Binding("Text", bsource, "originalMarketerRe", true));

                //6
                txtOrderNumber.DataBindings.Add(new Binding("Text", bsource, "orderNumber", true));

                //7 
                txtLineNumber.DataBindings.Add(new Binding("Text", bsource, "orderNumber", true));

                //8 
                txtMarketerAccountNumber.DataBindings.Add(new Binding("Text", bsource, "marketerAccountNum", true));

                //9
                txtCustomerAccountNumber.DataBindings.Add(new Binding("Text", bsource, "customerAccountNum", true));

                //10 
                dateTimePickerOrderDate.DataBindings.Add(new Binding("Value", bsource, "orderDate", true));
                dateTimePickerOrderDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerOrderDate.CustomFormat = "yyyy-MM-dd";

                //11
                dateDateTimePickerDelivery.DataBindings.Add(new Binding("Value", bsource, "deliveryDate", true));
                dateDateTimePickerDelivery.Format = DateTimePickerFormat.Custom;
                dateDateTimePickerDelivery.CustomFormat = "yyyy-MM-dd";

                //12
                txtTransactionType.DataBindings.Add(new Binding("Text", bsource, "transactionType", true));

                //13 
                txtPONumber.DataBindings.Add(new Binding("Text", bsource, "poNumber", true));

                txtReleaseNumber.DataBindings.Add(new Binding("Text", bsource, "releaseNumber", true));

                txtProductCode.DataBindings.Add(new Binding("Text", bsource, "productCode", true));

                txtPackageCode.DataBindings.Add(new Binding("Text", bsource, "packageCode", true));

                txtNumberOrdered.DataBindings.Add(new Binding("Text", bsource, "numberOrdered", true));

                txtDeliveredQty.DataBindings.Add(new Binding("Text", bsource, "deliveredQuantity", true));

                txtRequistionNumber.DataBindings.Add(new Binding("Text", bsource, "requisitionNumber", true));

                txtJobNumber.DataBindings.Add(new Binding("Text", bsource, "jobNumber", true));

                txtUnitNumber.DataBindings.Add(new Binding("Text", bsource, "unitNumber", true));

                txtCorporatePurchaseOrderId.DataBindings.Add(new Binding("Text", bsource, "corporatePurchaseOrd", true));

                txtBlanketPurchaseOrder.DataBindings.Add(new Binding("Text", bsource, "blanketPurchaseOrder", true));

                txtAutomaticSendIndicator.DataBindings.Add(new Binding("Text", bsource, "automaticSendIndic", true));

                txtDrumToteToBulkIndicator.DataBindings.Add(new Binding("Text", bsource, "drumToteToBulkIndi", true));

                txtServiceFees.DataBindings.Add(new Binding("Text", bsource, "serviceFees", true));

                txtPartialDelivery.DataBindings.Add(new Binding("Text", bsource, "partialDelivery", true));

                

                dset.Tables[0].Columns["deliveryDate"].DefaultValue = DateTime.Today;  //Set the default value for new rows.
                this.txtCustomerUniqueID.Text = "b21c9ea5-1eff-467b-97a0-1af5613ad634";

                /*
                //_______________________________________________________________________________________________________
                //Remove blanks
                //string numberOrdered = txtNumberOrdered.Text.TrimEnd();
                //txtNumberOrdered.Text = numberOrdered;

                //txtNumberOrdered.Text = txtNumberOrdered.Text.TrimEnd();


                //1 ID
                //2 customerUniqueId
                //3 marketerReceiptNum
                txtMarketerReceiptNumber.Text = txtMarketerReceiptNumber.Text.TrimEnd();
                //5 originalMarketerRe
                txtOriginalMarketerReceiptNumber.Text = txtOriginalMarketerReceiptNumber.Text.TrimEnd();
                //6 orderNumber
                txtOrderNumber.Text = txtOrderNumber.Text.TrimEnd();
                //7 orderNumber
                txtOrderNumber.Text = txtOrderNumber.Text.TrimEnd();
                //8 marketerAccountNum
                txtMarketerAccountNumber.Text = txtMarketerAccountNumber.Text.TrimEnd();
                //9 customerAccountNum
                txtCustomerAccountNumber.Text = txtCustomerAccountNumber.Text.TrimEnd();
                //10 orderDate
                dateTimePickerOrderDate.Text = dateTimePickerOrderDate.Text.TrimEnd();
                //11 deliveryDate
                dateDateTimePickerDelivery.Text = dateDateTimePickerDelivery.Text.TrimEnd();
                //12 transactionType
                txtTransactionType.Text = txtTransactionType.Text.TrimEnd();

                //13 poNumber
                txtPONumber.Text = txtPONumber.Text.TrimEnd();

                txtReleaseNumber.Text = txtReleaseNumber.Text.TrimEnd();

                txtProductCode.Text = txtProductCode.Text.TrimEnd();

                txtPackageCode.Text = txtPackageCode.Text.TrimEnd();

                txtNumberOrdered.Text = txtNumberOrdered.Text.TrimEnd();

                txtDeliveredQty.Text = txtDeliveredQty.Text.TrimEnd();

                txtRequistionNumber.Text = txtRequistionNumber.Text.TrimEnd();

                txtJobNumber.Text = txtJobNumber.Text.TrimEnd();

                txtUnitNumber.Text = txtUnitNumber.Text.TrimEnd();

                txtCorporatePurchaseOrderId.Text = txtCorporatePurchaseOrderId.Text.TrimEnd();

                txtBlanketPurchaseOrder.Text = txtBlanketPurchaseOrder.Text.TrimEnd();

                txtAutomaticSendIndicator.Text = txtAutomaticSendIndicator.Text.TrimEnd();

                txtDrumToteToBulkIndicator.Text = txtDrumToteToBulkIndicator.Text.TrimEnd();

                txtServiceFees.Text = txtServiceFees.Text.TrimEnd();

                txtPartialDelivery.Text = txtPartialDelivery.Text.TrimEnd();
                //_______________________________________________________________________________________________________
                */

                

                //Set position to first row
                if (dset.Tables[0].Rows.Count > 0)
                {
                    bsource.Position = 0;
                }


            }
        }


        private void btnHost_Click(object sender, EventArgs e)
        {
            //Save(bsource.Position);

            //No need to show this form, let's consolidate
            //

            /*
            var MyIni = new INIFile("Settings.ini");
            var MSAClientID = MyIni.Read("MSAClientID", "MyProg");
            var ClientSecret = MyIni.Read("MSAClientSecret", "MyProg");
            var Resource = MyIni.Read("MSAResource", "MyProg");
            var SubscriptionKey = MyIni.Read("MSASubscriptionKey", "MyProg");
            var TokenUrl = MyIni.Read("MSATokenUrl", "MyProg");
            var PostUrl = MyIni.Read("MSAPostUrl", "MyProg");
            MessageBox.Show(PostUrl);
            */

            string Error;

            if (PayloadUtils.PayloadUtils.BuildAndSendJsonPayloadFromDatabase(out Error,
                ConnString,
                MSAClientID,
                ClientSecret,
                Resource, 
                SubscriptionKey,
                TokenUrl,
                PostUrl,
                false,   //MSA is false
                NumberInBatch) == false)
            {
                MessageBox.Show(Error);
            }
            else
            {
                MessageBox.Show("All records sent successfully.");
            }
            

            /*
            if (BuildJsonPayloadFromDatabase(out Error, ConnString) == false)
            {
                MessageBox.Show(Error);
            }
            else
            {
                MessageBox.Show("All records sent successfully.");
            }
            */

            //frmMain mainForm = new frmMain();
            //mainForm.ShowDialog();

        }
        

        /*
        private bool BuildJsonPayloadFromDatabase(out string Error, string connection)
        {
            bool retval = false;
            Error = "";
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string token = Authorization.Authorization.GetClientCredentials(ClientID, ClientSecret, Resource, SubscriptionKey, TokenUrl, PostUrl);

            if (!string.IsNullOrEmpty(token))
            {
                using (ChevronEntities db = new ChevronEntities(DBUtils.GetConnectionString(connection)))
                {

                    List<Cbpmsadeliveryconfpayload> allMsas = new List<Cbpmsadeliveryconfpayload>();

                    allMsas = db.Set<Cbpmsadeliveryconfpayload>().Where(x => x.Uploaded != true).ToList();  //Only include those records not Uploaded

                    if (allMsas.Any())
                    {
                        int eachRecord = 0;

                        int NumberOfBatches = ((allMsas.Count() + NumberInBatch - 1) / NumberInBatch);   //NumberOfBatches

                        //Each batch
                        for (int eachBatch = 0; eachBatch < NumberOfBatches; eachBatch++)
                        {
                            Msas msas = new Msas();
                            msas.msapayloads = new Msapayloads();
                            msas.msapayloads.cbpmsadeliveryconfpayload = new List<Cbpmsadeliveryconfpayload>();

                            for (int i = 0; i < NumberInBatch && eachRecord < allMsas.Count(); i++)
                            {
                                msas.msapayloads.cbpmsadeliveryconfpayload.Add(allMsas[eachRecord]);
                                allMsas[eachRecord].Uploaded = true;
                                eachRecord++;
                            }
                            //Here we gave a batch
                            string payload;

                            try
                            {
                                payload = serializer.Serialize(msas);
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
                                if (Authorization.Authorization.UseBearerToken(token, payload, SubscriptionKey, PostUrl, out string dataResult))   //Succesful
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
                        Error = "No msas to process.";
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
        }
        */


        private void Save(int rowIndex)
        {
            toolStripStatusLabel1.Text = "";
            using (var conn = new SqlConnection(ConnString))
            {
                daAdapter = new SqlDataAdapter("select * from PX_Cbpmsadelivery", conn);

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

                    daRow["deliveryDate"] = this.dateDateTimePickerDelivery.Value.Date.ToString("yyyy-MM-dd"); //Make this a date.
                    daRow["orderDate"] = this.dateTimePickerOrderDate.Value.Date.ToString("yyyy-MM-dd");
                    daRow["marketerReceiptNum"] = this.txtMarketerReceiptNumber.Text;
                    daRow["originalMarketerRe"] = this.txtOriginalMarketerReceiptNumber.Text;
                    daRow["orderNumber"] = txtOrderNumber.Text;
                    daRow["lineNumber"] = txtLineNumber.Text;
                    daRow["marketerAccountNum"] = txtMarketerAccountNumber.Text;
                    daRow["customerAccountNum"] = txtCustomerAccountNumber.Text;
                    daRow["transactionType"] = txtTransactionType.Text;
                    daRow["pONumber"] = txtPONumber.Text;
                    daRow["releaseNumber"] = txtReleaseNumber.Text;
                    daRow["numberOrdered"] = txtNumberOrdered.Text;
                    daRow["deliveredQuantity"] = txtDeliveredQty.Text;
                    daRow["requisitionNumber"] = txtRequistionNumber.Text;
                    daRow["jobNumber"] = txtJobNumber.Text;
                    daRow["productCode"] = txtProductCode.Text;
                    daRow["packageCode"] = txtPackageCode.Text;
                    daRow["corporatePurchaseOrd"] = txtCorporatePurchaseOrderId.Text;
                    daRow["blanketPurchaseOrder"] = txtBlanketPurchaseOrder.Text;
                    daRow["automaticSendIndic"] = txtAutomaticSendIndicator.Text;
                    daRow["serviceFees"] = txtServiceFees.Text;
                    daRow["partialDelivery"] = txtPartialDelivery.Text;
                    daRow["unitNumber"] = txtUnitNumber.Text;
                    daRow["drumToteToBulkIndi"] = txtDrumToteToBulkIndicator.Text;
                    daRow["customerUniqueId"] = txtCustomerUniqueID.Text;
                    daRow["uploaded"] = false;

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


      

        

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //If there is anything to delete

               using (var conn = new SqlConnection(ConnString))
               {
                    daAdapter = new SqlDataAdapter("select * from Cbpmsadeliveryconfpayloads", conn);
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
