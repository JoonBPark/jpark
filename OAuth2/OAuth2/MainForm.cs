using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OAuth2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void btnCredentials_Click(object sender, EventArgs e)
        {
            string Error;
            if(BuildJsonPayloadFromDatabase(out Error) == false)
            {
                MessageBox.Show(Error);
            }
            else
            {
                MessageBox.Show("All records sent successfully.");
            }
        }


        int NumberInBatch = 30;

        /// <summary>
        /// This handles sending each batch to the host.
        /// </summary>
        /// <returns></returns>
        private bool BuildJsonPayloadFromDatabase(out string Error)
        {
            bool retval = false;
            Error = "";
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string token = OAuth2Static.GetClientCredentials(this.txtClientID.Text, txtClientSecret.Text, txtResource.Text);
            if (!string.IsNullOrEmpty(token))
            {
                using (ClaimsEntities db = new ClaimsEntities())
                {
                    List<Claim> allClaims = new List<Claim>();
                   
                    allClaims = db.Set<Claim>().Where(x=>x.Uploaded != true).ToList();  //Only include those records not Uploaded

                    if (allClaims.Any())
                    {
                        int eachRecord = 0;

                        int NumberOfBatches = ((allClaims.Count()+NumberInBatch-1) / NumberInBatch);   //NumberOfBatches

                        //Each batch
                        for (int eachBatch= 0; eachBatch < NumberOfBatches; eachBatch++)
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
                            catch(Exception e1)
                            {
                                Error = Error + "Error serializing Batch:" + (eachBatch+1).ToString() + " Error:" + e1.Message + "\r\n";
                                payload = "";
                                retval = false;
                            }
                            if (!string.IsNullOrEmpty(payload))
                            {
                                if (OAuth2Static.UseBearerToken(token, payload, out string dataResult))   //Succesful
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
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            this.txtClientID.Text = "b21c9ea5-1eff-467b-97a0-1af5613ad634";
            this.txtClientSecret.Text = "MjVHHT5ZauLoNebjVprRH7ulYGyxtF/EGqjKOfKBpPg=";
            this.txtResource.Text = "7a2b1852-1958-4161-ad3b-6a922aca5fbf";
            this.txtSubscriptionKey.Text = "c457beb7e0c749ad85b239666f9e6325";
        }

    }
}
