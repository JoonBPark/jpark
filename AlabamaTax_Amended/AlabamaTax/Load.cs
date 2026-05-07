using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    /// <summary>
    /// Load real data from Petrocycle into XML schema
    /// </summary>
    public class Load
    {
        public class Carrier
        {
            public static CarrierScheduleType Schedule(PXDMV row)
            {
                if (!row.DMVCODE.HasValue || !row.DELIVERYDATE.HasValue || !row.TERMSTATE.HasValue) return null;
                if (row.PURCHSELLFEIN == String.Empty || row.CARRFEIN == String.Empty || row.SUPPFEIN == String.Empty) return null;
                MFCarrierScheduleCode schedule;
                switch (row.SCHEDULE)
                {
                    case "14A": schedule = MFCarrierScheduleCode.Item14A; break;
                    case "14B": schedule = MFCarrierScheduleCode.Item14B; break;
                    case "14C": schedule = MFCarrierScheduleCode.Item14C; break;
                    default: return null;
                }
                return Create.Carrier.Schedule
                    (scheduleCode: schedule
                    , productCode: row.DMVCODE.Value
                    , mode: MFModeCode.J
                    , documentNumber: row.BOLNBR
                    , receivedShippedDate: row.DELIVERYDATE.Value
                    , originState: row.TERMSTATE.Value
                    , sellerName: row.SUPPNAME
                    , sellerFEIN: row.SUPPFEIN
                    , deliveredToAddress: row.DELVCITY
                    , deliveredToName: row.PURCHSELLNAME
                    , deliveredToFEIN: row.PURCHSELLFEIN
                    , net: row.NETQTY
                    , consignorName: row.CARRNAME
                    , consignorFEIN: row.CARRFEIN
                    );
            }
            public static CarrierReportType Report(IEnumerable<PXDMV> rows)
            {
                IEnumerable<CarrierScheduleType> schedules;
                schedules = (from row in rows
                             select Schedule(row)).Where(s => s != null);
                return Create.Carrier.Report(schedules);
            }
        }
        public class Distributor
        {
            public static DistributorScheduleType Schedule(PXDMV row)
            {
                MFDistributorScheduleCode schedule;
                if (!Enum.TryParse("Item" + row.SCHEDULE, out schedule)) return null;
                return Create.Distributor.Schedule
                    (scheduleCode: schedule
                    , productCode: row.DMVCODE.Value
                    , mode: MFModeCode.J
                    , documentNumber: row.BOLNBR
                    , receivedShippedDate: row.DELIVERYDATE.Value
                    , originState: row.TERMSTATE.Value
                    , destinationState: row.DELVSTATE.Value
                    , sellerName: row.SUPPNAME
                    , sellerFEIN: row.SUPPFEIN
                    , purchaserName: row.PURCHSELLNAME
                    , purchaserFEIN: row.PURCHSELLFEIN
                    , carrierFEIN: row.CARRFEIN
                    , carrierName: row.CARRNAME
                    , net: row.NETQTY
                    , gross: row.GRSQTY
                    );
            }
            public static IEnumerable<DistributorReportType> Reports(DateTime reportingMonth, IEnumerable<PXDMV> rows)
            {
                IEnumerable<DistributorScheduleType> imports;
                IEnumerable<DistributorScheduleType> exports;
                IEnumerable<DistributorScheduleType> all;
                all = (from row in rows
                       select Schedule(row)).Where(s => s != null);
                imports = all.Where(s => s.Destination.State == StateOnlyType.AL
                    && s.Origin.State != StateOnlyType.AL);
                exports = all.Where(s => s.Origin.State == StateOnlyType.AL
                    && s.Destination.State != StateOnlyType.AL);
                yield return Create.Distributor.Report
                    (MFReportIdType.IMR
                    , reportingMonth
                    , schedules: imports
                    );
                yield return Create.Distributor.Report
                    (MFReportIdType.EXPR
                    , reportingMonth
                    , schedules: exports
                    );
                yield return Create.Distributor.Report
                    (MFReportIdType.BLDR
                    , reportingMonth
                    , blenders: Enumerable.Empty<MFReportDetailType>()
                    );
            }
        }
    }
}
