using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class SupplierReport
    {
        public static SupplierReportType Load(PXDMV table)
        {
            SupplierReportType report = new SupplierReportType();
            report.reportUOM = MFUnitsOfMeasureType.Gallons;
            report.reportCurrency = MFCurrencyType.USD;
            report.ReportID = MFReportIdType.SR;
            List<SupplierScheduleType> schedules = new List<SupplierScheduleType>();
            while (table.LoadRow())
            {
                SupplierScheduleType sch = SupplierSchedule.Load(table);
                if (sch != null) schedules.Add(sch);
            }
            report.SupplierSchedule = schedules.ToArray();
            return report;
        }
    }
}
