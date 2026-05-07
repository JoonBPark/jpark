using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class CarrierSchedule
    {
        public static CarrierScheduleType Load(PXDMV row)
        {
            if (!row.DMVCODE.HasValue || !row.DELIVERYDATE.HasValue || !row.TERMSTATE.HasValue) return null;
            if (row.PURCHSELLFEIN == String.Empty || row.CARRFEIN == String.Empty || row.SUPPFEIN == String.Empty) return null;
            CarrierScheduleType xml = new CarrierScheduleType();
            switch (row.SCHEDULE)
            {
                case "14A": xml.ScheduleCode = MFCarrierScheduleCode.Item14A; break;
                case "14B": xml.ScheduleCode = MFCarrierScheduleCode.Item14B; break;
                case "14C": xml.ScheduleCode = MFCarrierScheduleCode.Item14C; break;
                default: return null;
            }
            xml.ProductCode = row.DMVCODE.Value;
            xml.Mode = MFModeCode.J;
            xml.DocumentNumber = row.BOLNBR;
            xml.ReceivedShippedDate = row.DELIVERYDATE.Value;
            xml.Origin = new CarrierScheduleTypeOrigin();
            xml.Origin.State = row.TERMSTATE.Value;
            xml.Seller = new CarrierScheduleTypeSeller();
            xml.Seller.Name = row.SUPPNAME;
            xml.Seller.FEIN = row.SUPPFEIN;
            xml.DeliveredTo = new CarrierScheduleTypeDeliveredTo();
            xml.DeliveredTo.Name = row.PURCHSELLNAME;
            xml.DeliveredTo.FEIN = row.PURCHSELLFEIN;
            xml.DeliveredTo.Address = row.DELVCITY;
            xml.Net = row.NETQTY;
            xml.Gross = row.GRSQTY;
            xml.Consignor = new CarrierScheduleTypeConsignor();
            xml.Consignor.Name = row.CARRNAME;
            xml.Consignor.FEIN = row.CARRFEIN;
            xml.DiversionNumber = MFDiversionNumberType.TRPR1;
            return xml;
        }
    }
}
