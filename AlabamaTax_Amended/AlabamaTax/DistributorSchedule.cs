using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class DistributorSchedule
    {
        public static MFReportDetailType Blender(bool gas, Decimal quantity)
        {
            MFReportDetailType schedule = new MFReportDetailType();
            schedule.ProductCode = gas ? MFProductCode.Item065 : MFProductCode.Item160;
            MFReportDetailTypeGeneralQuantity qty = new MFReportDetailTypeGeneralQuantity();
            qty.generalQuantityItem = gas ? "GasolineBlend" : "UndyedDieselBlend";
            qty.Value = quantity;
            schedule.Items1 = new object[] { qty };
            return schedule;
        }
        public static DistributorScheduleType ImportExport(PXDMV row)
        {
            MFDistributorScheduleCode code;
            if (!Enum.TryParse("Item" + row.SCHEDULE, out code)) return null;
            DistributorScheduleType xml = new DistributorScheduleType();
            xml.ScheduleCode = code;
            if (row.IsImport)
            {
                switch (xml.ScheduleCode)
                {
                    case MFDistributorScheduleCode.Item3B:
                        xml.DiversionNumber = MFDiversionNumberType.IMR1;
                        break;
                    case MFDistributorScheduleCode.Item11B:
                        xml.DiversionNumber = MFDiversionNumberType.IMR2;
                        break;
                    case MFDistributorScheduleCode.Item1A:
                        xml.DiversionNumber = MFDiversionNumberType.IMR3;
                        break;
                    case MFDistributorScheduleCode.Item1C:
                        xml.DiversionNumber = MFDiversionNumberType.IMR4;
                        break;
                }
            }
            else if (row.IsExport)
            {
                switch (xml.ScheduleCode)
                {
                    case MFDistributorScheduleCode.Item7B:
                        xml.DiversionNumber = MFDiversionNumberType.EXPR1;
                        break;
                    case MFDistributorScheduleCode.Item11A:
                    case MFDistributorScheduleCode.Item11B:
                        xml.DiversionNumber = MFDiversionNumberType.EXPR2;
                        break;
                    case MFDistributorScheduleCode.Item7A:
                        xml.DiversionNumber = MFDiversionNumberType.EXPR3;
                        break;
                }
            }
            else return null;
            xml.ProductCode = row.DMVCODE.Value;
            xml.Mode = MFModeCode.J;
            xml.DocumentNumber = row.BOLNBR;
            xml.ReceivedShippedDate = row.DELIVERYDATE.Value;
            xml.Origin = new DistributorScheduleTypeOrigin();
            xml.Origin.State = row.TERMSTATE.Value;
            xml.Destination = new DistributorScheduleTypeDestination();
            xml.Destination.State = row.DELVSTATE.Value;
            switch (xml.DiversionNumber)
            {
                case MFDiversionNumberType.IMR1:
                case MFDiversionNumberType.IMR3:
                case MFDiversionNumberType.IMR4:
                    xml.Seller = new DistributorScheduleTypeSeller();
                    xml.Seller.Name = row.SUPPNAME;
                    xml.Seller.FEIN = row.SUPPFEIN;
                    break;
                case MFDiversionNumberType.IMR2:
                case MFDiversionNumberType.EXPR1:
                case MFDiversionNumberType.EXPR2:
                case MFDiversionNumberType.EXPR3:
                    xml.Purchaser = new DistributorScheduleTypePurchaser();
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
