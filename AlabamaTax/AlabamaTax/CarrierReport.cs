using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class CarrierReport
    {
        public static CarrierReportType Load(PXDMV table)
        {
            CarrierReportType report = new CarrierReportType();
            report.reportUOM = MFUnitsOfMeasureType.Gallons;
            report.reportCurrency = MFCurrencyType.USD;
            report.ReportID = MFReportIdType.TRPR;
            List<CarrierScheduleType> schedules = new List<CarrierScheduleType>();
            while (table.LoadRow())
            {
                CarrierScheduleType sch= CarrierSchedule.Load(table);
                if (sch != null) schedules.Add(sch);
            }
            report.CarrierSchedule = schedules.ToArray();
            //if (Unknown<bool>.Fixme(false)) //FIXME: check this box if no schedules?
            //{
            //    report.NoActivity = CheckboxType.X;
            //}
            return report;
        }
    }
}
