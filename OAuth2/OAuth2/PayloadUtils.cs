using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OAuth2
{
    public static class PayloadUtils
    {
        /// <summary>
        /// This sends either an MSA or Claims Payload to Chevron for processing
        /// </summary>
        /// <param name="Error">Information about what happened if an error occurs</param>
        /// <param name="connection">The connection string for the database that contains the data to be sent</param>
        /// <param name="ClientID">The ClientID required by Chevron for processing</param>
        /// <param name="ClientSecret">The ClientSecret provided by Chevron to facilitate processing</param>
        /// <param name="Resource">The ResourceID provided by Chevron for processing.</param>
        /// <param name="SubscriptionKey">The SubscriptionKey provided by Chevron for processing</param>
        /// <param name="TokenUrl">The URL designated by Chevron for obtaining a Token</param>
        /// <param name="PostUrl">The URL used to Post requests to Chevron</param>
        /// <param name="DoClaims">True for sending Claims False for sending MSA records</param>
        /// <param name="NumberInBatch">How many records are sent within a batch</param>
        /// <returns>True of all records are send and false if an error occurs.</returns>
        public static bool BuildAndSendJsonPayloadFromDatabase(out string Error,
            string connection,
            string ClientID,
            string ClientSecret,
            string Resource,
            string SubscriptionKey,
            string TokenUrl,
            string PostUrl,
            bool DoClaims,   
            int NumberInBatch)
        {
            bool retval = false;
            Error = "";

            string token = Authorization.Authorization.GetClientCredentials(ClientID, ClientSecret, Resource, SubscriptionKey, TokenUrl, PostUrl);

            if (!string.IsNullOrEmpty(token))
            {
                using (ChevronEntities db = new ChevronEntities(DBUtils.GetConnectionString(connection)))
                {
                    if (DoClaims)
                    {
                        var allClaims = new List<Claim>();
                        allClaims = db.Set<Claim>().Where(x => x.Uploaded != true).ToList();  //Only include those records not Uploaded
                        if (allClaims.Any())
                        {
                            retval =  HandleAllClaimsBatches(db,
                                NumberInBatch,
                                allClaims.Count,
                                ref allClaims,
                                token,
                                SubscriptionKey,
                                PostUrl);
                        }
                        else
                        {
                            Error = "No records to process.";
                            retval = false;
                        }
                    }
                    else  //Do MSA here
                    {
                        List<Cbpmsadeliveryconfpayload> allMsas = new List<Cbpmsadeliveryconfpayload>();
                        allMsas = db.Set<Cbpmsadeliveryconfpayload>().Where(x => x.Uploaded != true).ToList();  //Only include those records not Uploaded
                        if (allMsas.Any())
                        {
                            retval = HandleAllMSABatches(db,
                                 NumberInBatch,
                                allMsas.Count,
                                ref allMsas,
                                token,
                                SubscriptionKey,
                                PostUrl);
                        }
                        else
                        {
                            Error = "No records to process.";
                            retval = false;
                        }
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

        /// <summary>
        /// Handles all the batches requested.  This function is responsible for determining how many
        /// batches are required and calling a function to process each batch.
        /// </summary>
        /// <param name="db">The Entity Framework reference used to save records</param>
        /// <param name="NumberInBatch">How many record exist are processed within one batch</param>
        /// <param name="TotalNumberOfRecords">The total number of records</param>
        /// <param name="allMsa">The full list of records to work with</param>
        /// <param name="token">The security token used to send the data</param>
        /// <param name="SubscriptionKey">The subscription key required to send data</param>
        /// <param name="PostUrl">The URL used to post data to Chevron</param>
        /// <returns>True of all Batches processed successfully</returns>
        static bool HandleAllMSABatches(ChevronEntities db,
                 int NumberInBatch,
                 int TotalNumberOfRecords,
                 ref List<Cbpmsadeliveryconfpayload> allMsa,
                 string token,
                 string SubscriptionKey,
                 string PostUrl)
        {
            int eachRecord = 0;
            int NumberOfBatches = ((TotalNumberOfRecords + NumberInBatch - 1) / NumberInBatch);
            bool retval = false;

            for (int eachBatch = 0; eachBatch < NumberOfBatches; eachBatch++)
            {
                if (HandleEachMSABatch(db,
                    ref allMsa,
                    NumberInBatch,
                    TotalNumberOfRecords,
                    ref eachRecord,
                    eachBatch,
                    token,
                    SubscriptionKey,
                    PostUrl) == false)
                {
                    retval = false;
                }
                else
                {
                    retval = true;
                }
            }
            return retval;
        }

        /// <summary>
        /// Processes a single batch of records
        /// </summary>
        /// <param name="db">The Entity Framework reference used to save records</param>
        /// <param name="allMSAs">The total list of records</param>
        /// <param name="NumberInBatch">How many record exist are processed within one batch</param>
        /// <param name="TotalNumberOfRecords">The total number of records</param>
        /// <param name="eachRecord">This record position</param>
        /// <param name="eachBatch">This batch being processed</param>
        /// <param name="token">The security token used to send the data</param>
        /// <param name="SubscriptionKey">The subscription key required to send data</param>
        /// <param name="PostUrl">The URL used to post data to Chevron</param>
        /// <returns>Returns true if this batch processes sucessfully</returns>
        static bool HandleEachMSABatch(ChevronEntities db,
           ref List<Cbpmsadeliveryconfpayload> allMSAs,
           int NumberInBatch,
           int TotalNumberOfRecords,
           ref int eachRecord,
           int eachBatch,
           string token,
           string SubscriptionKey,
           string PostUrl)
        {
            bool retval = false;
            Msas msas = ExtractMSABatch(ref allMSAs, NumberInBatch, TotalNumberOfRecords, ref eachRecord);

            if (msas.msapayloads.cbpmsadeliveryconfpayload.Count > 0)
            {
                //Here we have a batch
                string Error;
                string payload = SerializeMSABatch(msas, out Error, eachBatch, out retval);
                string dataResultpayload;
                return true;
                return SendBatch(ref db,
                    payload,
                    eachBatch,
                    token,
                    SubscriptionKey,
                    PostUrl,
                    out dataResultpayload);
            }

            return retval;
        }

        /// <summary>
        /// Creates a single Batch to send to the Chevron Host
        /// </summary>
        /// <param name="allMSAs">>The total list of records</param>
        /// <param name="NumberInBatch">How many record exist are processed within one batch</param>
        /// <param name="TotalNumberOfRecords">The total number of records</param>
        /// <param name="eachRecord">This particular record</param>
        /// <returns>A data structure that matches Chevron specifications for payload</returns>
        static Msas ExtractMSABatch(ref List<Cbpmsadeliveryconfpayload> allMSAs, int NumberInBatch, int TotalNumberOfRecords, ref int eachRecord)
        {
            Msas msas = new Msas();
            msas.msapayloads = new Msapayloads();
            msas.msapayloads.cbpmsadeliveryconfpayload = new List<Cbpmsadeliveryconfpayload>();

            for (int i = 0; i < NumberInBatch && eachRecord < allMSAs.Count(); i++)
            {
                msas.msapayloads.cbpmsadeliveryconfpayload.Add(allMSAs[eachRecord]);
                allMSAs[eachRecord].Uploaded = true;
                eachRecord++;
            }
            return msas;
        }

        /// <summary>
        /// Converts the data structure to a JSON serialized version for Chevron to consume
        /// </summary>
        /// <param name="msas">The data structure passed in</param>
        /// <param name="Error">Any error that occurs during serialization etc.</param>
        /// <param name="eachBatch">The batch number for this data (for error reporting)</param>
        /// <param name="retval">True for Success and False Otherwise</param>
        /// <returns>The actual serialized payload for Chevron</returns>
        static string SerializeMSABatch(Msas msas, out string Error, int eachBatch, out bool retval)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string payload = "";
            try
            {
                payload = serializer.Serialize(msas);
                string jsonFormatted = JValue.Parse(payload).ToString(Formatting.Indented);
                DisplayJson jsonDisplay = new DisplayJson(jsonFormatted);
                jsonDisplay.ShowDialog();
                Error = "";
                retval = true;
                return payload;
            }
            catch (Exception e1)
            {
                Error = "Error serializing Batch:" + (eachBatch + 1).ToString() + " Error:" + e1.Message + "\r\n";
                payload = "";
                retval = false;
                return payload;
            }
        }




        /// <summary>
        /// Handles all the batches requested.  This function is responsible for determining how many
        /// batches are required and calling a function to process each batch.
        /// </summary>
        /// <param name="db">The Entity Framework reference used to save records</param>
        /// <param name="NumberInBatch">How many record exist are processed within one batch</param>
        /// <param name="TotalNumberOfRecords">The total number of records</param>
        /// <param name="allMsa">The full list of records to work with</param>
        /// <param name="token">The security token used to send the data</param>
        /// <param name="SubscriptionKey">The subscription key required to send data</param>
        /// <param name="PostUrl">The URL used to post data to Chevron</param>
        /// <returns>True of all Batches processed successfully</returns>
        static bool HandleAllClaimsBatches(ChevronEntities db, 
            int NumberInBatch, 
            int TotalNumberOfClaims, 
            ref List<Claim> allClaims, 
            string token, 
            string SubscriptionKey, 
            string PostUrl)
        {
            int eachRecord = 0;
            int NumberOfBatches = ((TotalNumberOfClaims + NumberInBatch - 1) / NumberInBatch);
            bool retval = false;

            for (int eachBatch = 0; eachBatch < NumberOfBatches; eachBatch++)
            {
                if(HandleEachClaimsBatch(db, 
                    ref allClaims, 
                    NumberInBatch, 
                    TotalNumberOfClaims, 
                    ref eachRecord, 
                    eachBatch,
                    token,
                    SubscriptionKey,
                    PostUrl) == false)
                {
                    retval =  false;
                }
                else
                {
                    retval = true;
                }
            }
            return retval;
        }
        /// <summary>
        /// Processes a single batch of records
        /// </summary>
        /// <param name="db">The Entity Framework reference used to save records</param>
        /// <param name="allMSAs">The total list of records</param>
        /// <param name="NumberInBatch">How many record exist are processed within one batch</param>
        /// <param name="TotalNumberOfRecords">The total number of records</param>
        /// <param name="eachRecord">This record position</param>
        /// <param name="eachBatch">This batch being processed</param>
        /// <param name="token">The security token used to send the data</param>
        /// <param name="SubscriptionKey">The subscription key required to send data</param>
        /// <param name="PostUrl">The URL used to post data to Chevron</param>
        /// <returns>Returns true if this batch processes sucessfully</returns>
        static bool HandleEachClaimsBatch(ChevronEntities db, 
            ref List<Claim> allClaims, 
            int NumberInBatch, 
            int TotalNumberOfClaims, 
            ref int eachRecord, 
            int eachBatch,
            string token, 
            string SubscriptionKey, 
            string PostUrl)
        {
            bool retval = false;
            Claims claims = ExtractClaimsBatch(ref allClaims, NumberInBatch, TotalNumberOfClaims, ref eachRecord);
            if (claims.claims.Count > 0)
            {
                //Here we have a batch
                string Error;
                string payload = SerializeClaimsBatch(claims, out Error, eachBatch, out retval);
                string dataResultpayload;
                return SendBatch(ref db, 
                    payload, 
                    eachBatch,
                    token, 
                    SubscriptionKey, 
                    PostUrl,
                    out dataResultpayload);
            }

            return retval;
        }

        /// <summary>
        /// Creates a single Batch to send to the Chevron Host
        /// </summary>
        /// <param name="allMSAs">>The total list of records</param>
        /// <param name="NumberInBatch">How many record exist are processed within one batch</param>
        /// <param name="TotalNumberOfRecords">The total number of records</param>
        /// <param name="eachRecord">This particular record</param>
        /// <returns>A data structure that matches Chevron specifications for payload</returns>
        static Claims ExtractClaimsBatch( ref List<Claim> allClaims, int NumberInBatch, int TotalNumberOfClaims, ref int eachRecord)
        {
            Claims claims = new Claims();
            claims.claims = new List<Claim>();
            for (int i = 0; i < NumberInBatch && eachRecord < TotalNumberOfClaims; i++)
            {
                claims.claims.Add(allClaims[eachRecord]);
                allClaims[eachRecord].Uploaded = true;
                eachRecord++;
            }
            return claims;
        }


        /// <summary>
        /// Converts the data structure to a JSON serialized version for Chevron to consume
        /// </summary>
        /// <param name="msas">The data structure passed in</param>
        /// <param name="Error">Any error that occurs during serialization etc.</param>
        /// <param name="eachBatch">The batch number for this data (for error reporting)</param>
        /// <param name="retval">True for Success and False Otherwise</param>
        /// <returns>The actual serialized payload for Chevron</returns>
        static string SerializeClaimsBatch(Claims claims, out string Error, int eachBatch, out bool retval)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string payload = "";
            try
            {
                payload = serializer.Serialize(claims);
                string jsonFormatted = JValue.Parse(payload).ToString(Formatting.Indented);
                DisplayJson jsonDisplay = new DisplayJson(jsonFormatted);
                //jsonDisplay.ShowDialog();
                Error = "";
                retval = true;
                return payload;
            }
            catch (Exception e1)
            {
                Error = "Error serializing Batch:" + (eachBatch + 1).ToString() + " Error:" + e1.Message + "\r\n";
                payload = "";
                retval = false;
                return payload;
            }
        }
        /// <summary>
        /// Actually sends the batch to Chevron for processing
        /// </summary>
        /// <param name="db">The Entity Framework reference used to save records</param>
        /// <param name="payload">The serialized data to be sent to Chevron</param>
        /// <param name="eachBatch">The batch number being sent</param>
        /// <param name="token">The necessary token required to send data to Chevron</param>
        /// <param name="SubscriptionKey">The subscription key required to send data to Chevron</param>
        /// <param name="PostUrl">The URL to post to Chevron</param>
        /// <param name="dataResult">The result from the send</param>
        /// <returns>True if send is successful, puts error in dataResult if and returns false if unsuccessful</returns>
        static bool SendBatch(ref ChevronEntities db, 
            string payload, 
            int eachBatch, 
            string token,
            string SubscriptionKey,
            string PostUrl,
            out string dataResult)
        {
            //Get necessary settings
            dataResult = "";
            bool retval = false;

            //Send the data
            if (!string.IsNullOrEmpty(payload))
            {
                if (Authorization.Authorization.UseBearerToken(token, payload, SubscriptionKey, PostUrl, out dataResult))   //Succesful
                {
                    try
                    {
                        db.SaveChanges();   //Update the database including the updated field.
                        dataResult = "";
                        retval = true;
                    }
                    catch (Exception e)
                    {
                        dataResult =  "Error saving Batch:" + (eachBatch + 1).ToString() + " Error:" + e.Message + "\r\n";
                        retval = false;
                    }
                }
                else
                {
                    dataResult = "Error sending Batch:" + (eachBatch + 1).ToString() + " Error:" + dataResult + "\r\n";

                    //Unable to get payload...
                    retval = false;
                }
            }
            else
            {
                dataResult = "";
                retval = false;
            }
            return retval;
        }
    }
}

