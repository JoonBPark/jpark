using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class TransmissionHeader
    {
        public static TransmissionHeaderType Header(string etin, string id, bool testing = false)
        {
            TransmissionHeaderType header = new TransmissionHeaderType();
            header.recordCount = Unknown<string>.Fixme("1");
            header.Jurisdiction = "ALABAMA"; // AL or ALABAMA? spec is unclear, ALABAMA used in sample xml
            header.TransmissionId = id;
            header.ProcessType = testing ? TransmissionHeaderTypeProcessType.T : TransmissionHeaderTypeProcessType.P;
            header.AgentIdentifier = TransmissionHeaderTypeAgentIdentifier.XMLTXT;
            header.Timestamp = Timestamp.Now;
            {
                TransmissionHeaderTypeTransmitter transmitter = new TransmissionHeaderTypeTransmitter();
                transmitter.ItemElementName = ItemChoiceType9.ETIN;
                transmitter.Item = etin;
                header.Transmitter = transmitter;
            }
            return header;
        }
    }
}
