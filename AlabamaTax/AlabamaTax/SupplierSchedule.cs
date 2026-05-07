using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class SupplierSchedule
    {
        public static SupplierScheduleType Load(PXDMV row)
        {
            if (!row.DMVCODE.HasValue || !row.DELIVERYDATE.HasValue || !row.TERMSTATE.HasValue) return null;
            if (row.PURCHSELLFEIN == String.Empty || row.CARRFEIN == String.Empty || row.SUPPFEIN == String.Empty) return null;
            MFSupplierScheduleCode code;
            if (!Enum.TryParse("Item" + row.SCHEDULE, out code)) return null;
            SupplierScheduleType xml = new SupplierScheduleType();
            xml.ScheduleCode = code;
            switch (xml.ScheduleCode)
            {
                case MFSupplierScheduleCode.Item1:
                case MFSupplierScheduleCode.Item2:
                case MFSupplierScheduleCode.Item2B:
                    xml.DiversionNumber = MFDiversionNumberType.SR1;
                    break;
                case MFSupplierScheduleCode.Item5A:
                case MFSupplierScheduleCode.Item5C:
                case MFSupplierScheduleCode.Item5Q:
                case MFSupplierScheduleCode.Item7A:
                case MFSupplierScheduleCode.Item7C:
                case MFSupplierScheduleCode.Item8:
                case MFSupplierScheduleCode.Item9C:
                case MFSupplierScheduleCode.Item9E:
                case MFSupplierScheduleCode.Item10A:
                case MFSupplierScheduleCode.Item10B:
                case MFSupplierScheduleCode.Item10Z:
                    xml.DiversionNumber = MFDiversionNumberType.SR2;
                    break;
                case MFSupplierScheduleCode.Item11A:
                case MFSupplierScheduleCode.Item11B:
                    xml.DiversionNumber = MFDiversionNumberType.SR3;
                    break;
                default:
                    return null;
            }
            xml.ProductCode = row.DMVCODE.Value;
            xml.Mode = MFModeCode.J;
            xml.DocumentNumber = row.BOLNBR;
            xml.ReceivedShippedDate = row.DELIVERYDATE.Value;
            xml.Origin = new SupplierScheduleTypeOrigin();
            xml.Origin.State = row.TERMSTATE.Value;
            xml.Destination = new SupplierScheduleTypeDestination();
            xml.Destination.State = row.DELVSTATE.Value;
            switch (xml.DiversionNumber)
            {
                case MFDiversionNumberType.SR1:
                    xml.Seller = new SupplierScheduleTypeSeller();
                    xml.Seller.Name = row.SUPPNAME;
                    xml.Seller.FEIN = row.SUPPFEIN;
                    break;
                case MFDiversionNumberType.SR2:
                case MFDiversionNumberType.SR3:
                    xml.Origin.TerminalCode = row.TERMINAL;//Unknown<string>.Fixme("123456789");
                    xml.Purchaser = new SupplierScheduleTypePurchaser();
                    xml.Purchaser.Name = row.PURCHSELLNAME;
                    xml.Purchaser.FEIN = row.PURCHSELLFEIN;
                    break;
            }
            xml.Net = row.NETQTY;
            xml.Gross = row.GRSQTY;
            return xml;
        }
    }
}
