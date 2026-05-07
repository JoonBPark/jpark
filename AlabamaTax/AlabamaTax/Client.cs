//#define LOCAL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;

using System.Windows.Forms;
namespace AlabamaTax
{
    class Client
    {
        interface IClient
        {
            object SubmissionListByAcknowledgementId(string UserName, string Password, string AcknowledgementId);
            object SubmissionListByDate(string UserName, string Password, string DateFrom, string DateTo);
            object SubmissionListByTransmissionId(string UserName, string Password, string TransmissionId);
            object NewSubmission(string UserName, string Password, object File);
            void Close();
            string UserName { get; }
            string Password { get; }
        }
        class TestClient : MEF_Test_InterfaceClient, IClient
        {
            public string UserName { get { return "testcmisolutions2v3rne"; } }
            public string Password { get { return "nuk6?pg#d3"; } }
        }
        class ProductionClient : MFET_InterfaceClient, IClient
        {
            public string UserName { get { return "Cmisolutions91i6ev"; } }
            public string Password { get { return "&n3ye9c.u*"; } }
        }
        private static XNamespace xmlns = "http://www.irs.gov/efile";

        private static string nowStamp
        {
            get { return DateTime.Now.ToString("yyyy-MM-ddTHH.mm.ss"); }
        }
        private static string testStamp(bool testing) { return (testing ? "_test" : "_production"); }
        private static IClient newBackend(bool testing)
        {
            if (testing) return new TestClient();
            else return new ProductionClient();
        }

        public static XDocument NewSubmission(bool testing, Transmission transmission)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Transmission));
            MemoryStream stream = new MemoryStream(); // must have a stream to serialize to
            serializer.Serialize(stream, transmission);
            byte[] document = stream.ToArray();
            stream.Dispose();

            File.WriteAllBytes(nowStamp + testStamp(testing) + "_submission.xml", document);
#if LOCAL
            return null;
#else
            IClient client = newBackend(testing);
            byte[] response = (byte[])client.NewSubmission(client.UserName, client.Password, stream.ToArray());
            client.Close();
            if (response == null) return null;

            File.WriteAllBytes(nowStamp + testStamp(testing) + "_acknowledgement.xml", response);

            return XDocument.Load(new MemoryStream(response));
#endif
        }
        public static String AcknowledgementID(XDocument doc)
        {
            return doc
                .Element(xmlns + "Transmission")
                    .Element(xmlns + "AcknowledgementID")
                        .Value;
        }
        public static XDocument Validation(bool testing, String acknowledgement = null, String transmission = null)
        {
#if LOCAL
            return null;
#else
            IClient client = newBackend(testing);
            byte[] response = (byte[])
                (transmission != null ? client.SubmissionListByTransmissionId(client.UserName, client.Password, transmission)
                 : (acknowledgement != null ? client.SubmissionListByAcknowledgementId(client.UserName, client.Password, acknowledgement)
                    : client.SubmissionListByDate(client.UserName, client.Password, "", "")));
            client.Close();
            if (response == null) return null;

            File.WriteAllBytes(nowStamp + testStamp(testing) + "_validation.xml", response);

            return XDocument.Load(new MemoryStream(response));
#endif
        }
        public static IEnumerable<ValidationError> ValidationErrors(XDocument doc)
        {
            XElement acknowledgement = doc
                .Element(xmlns + "AckTransmission")
                    .Element(xmlns + "Acknowledgement");
            if (acknowledgement.Element(xmlns + "AcceptanceStatus").Value == "A") return null;
            return from el in acknowledgement.Element(xmlns + "ErrorList").Elements(xmlns + "Error")
                   select new ValidationError(
                       el.Element(xmlns + "ErrorCategory").Value,
                       el.Element(xmlns + "ErrorMessage").Value,
                       el.Element(xmlns + "RuleNumber").Value,
                       el.Element(xmlns + "Severity").Value);
        }
    }
}
