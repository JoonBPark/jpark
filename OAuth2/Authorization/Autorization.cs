using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Authorization
{
    static public class Authorization
    {
        private static Regex rx = new Regex(".*\"access_token\"\\s*:\\s*\"([^\"]+)\".*");

        static public string GetClientCredentials(string client_id, string client_secret, string resourceLocal, string subscriptionKey, string tokenUrl, string postUrl, out HttpStatusCode responseCode, out string statusDescription)
        {
            string auth = client_id + ":" + client_secret;
            string authentication = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(auth));
            string content = "grant_type=client_credentials" + "&" + "client_id=" + client_id + "&" + "client_secret=" + client_secret + "&" + "resource=" + resourceLocal;
            string returnVal = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tokenUrl);
            request.KeepAlive = true;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers["Authorization"] = "Basic " + authentication;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(content), 0, content.Length);
            requestStream.Close();


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string contentRead = streamReader.ReadToEnd();
            responseCode = response.StatusCode;
            statusDescription = response.StatusDescription;
            streamReader.Close();

            MatchCollection matches = rx.Matches(contentRead);

            if (matches.Count > 0)
            {
                Match match = matches[0];
                GroupCollection groupCollection = match.Groups;

                if (groupCollection.Count > 1)
                {
                    returnVal = groupCollection[1].ToString();
                }
            }

            return returnVal;   //Returns token
        }

        static public bool UseBearerToken(string bearerToken, string payload, string subscriptionKey, string postUrl, out string dataResult)
        {
            Stream requestStream = null;

            try
            {

                ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);



                request.KeepAlive = true;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Bearer " + bearerToken;
                request.Headers["Ocp-Apim-Subscription-Key"] = subscriptionKey;
                request.Accept = "text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
                request.Proxy = null;
                request.Credentials = CredentialCache.DefaultCredentials;

                //Payload stuff
                byte[] postDataBytes = Encoding.UTF8.GetBytes(payload);
                request.ContentLength = postDataBytes.Length;


                requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                requestStream.Flush();
                requestStream.Close();

                //Now get response...
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    string contentRead = streamReader.ReadToEnd();
                    string responseCode = response.StatusCode.ToString();
                    dataResult = contentRead.ToString();
                    streamReader.Close();
                    return true;
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    // Get HttpWebResponse so that you can check the HTTP status code.  
                    HttpWebResponse httpResponse = (HttpWebResponse)e.Response;
                }
                if (null != requestStream)
                {
                    requestStream.Close();
                }

                dataResult = e.Message;
                return false;
            }
        }

        static public bool SendPayloadToChevron(bool claim, string bearerToken, string payload, string subscriptionKey, string postUrl, out string dataResult, out HttpStatusCode responseCode, out string statusDescription)
        {
            Stream requestStream = null;
            statusDescription = string.Empty; responseCode = HttpStatusCode.OK;
            try
            {

                ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);



                request.KeepAlive = true;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Bearer " + bearerToken;
                request.Headers["Ocp-Apim-Subscription-Key"] = subscriptionKey;
                request.Accept = "text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
                request.Proxy = null;
                request.Credentials = CredentialCache.DefaultCredentials;

                //Payload stuff
                byte[] postDataBytes = Encoding.UTF8.GetBytes(payload);
                request.ContentLength = postDataBytes.Length;


                requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                requestStream.Flush();
                requestStream.Close();

                //Now get response...
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    string contentRead = streamReader.ReadToEnd();
                    responseCode = response.StatusCode;
                    statusDescription = response.StatusDescription;
                    dataResult = contentRead.ToString();
                    streamReader.Close();
                    return true;
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    // Get HttpWebResponse so that you can check the HTTP status code.  
                    HttpWebResponse httpResponse = (HttpWebResponse)e.Response;
                }
                if (null != requestStream)
                {
                    requestStream.Close();
                }

                dataResult = e.Message;
                return false;
            }
        }


        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
