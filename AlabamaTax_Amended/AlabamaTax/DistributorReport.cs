using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class DistributorReport
    {
        private DistributorReportType importReport, exportReport, blenderReport;
        public DistributorReport()
        {
            importReport = baseReport();
            importReport.ReportID = MFReportIdType.IMR;
            exportReport = baseReport();
            exportReport.ReportID = MFReportIdType.EXPR;
            blenderReport = baseReport();
            blenderReport.ReportID = MFReportIdType.BLDR;
        }
        public void Load(PXDMV table)
        {
            List<DistributorScheduleType> importSchedules = new List<DistributorScheduleType>(), exportSchedules = new List<DistributorScheduleType>();
            while (table.LoadRow())
            {
                DistributorScheduleType sch = DistributorSchedule.ImportExport(table);
                if (sch == null) continue;
                if (table.IsExport) exportSchedules.Add(sch);
                else importSchedules.Add(sch);
            }
            if (importSchedules.Count > 0)
            {
                importReport = baseReport();
                importReport.DistributorSchedule = importSchedules.ToArray();
            }
            if (exportSchedules.Count > 0)
            {
                exportReport = baseReport();
                exportReport.DistributorSchedule = exportSchedules.ToArray();
            }
        }
        public void Install(MotorFuelsFiling mf)
        {
            var x = new List<DistributorReportType>();
            if (importReport != null) x.Add(importReport);
            if (exportReport != null) x.Add(exportReport);
            if (blenderReport != null) x.Add(blenderReport);
            mf.DistributorReport = x.ToArray();
        }
        private static DistributorReportType baseReport()
        {
            DistributorReportType report = new DistributorReportType();
            report.reportUOM = MFUnitsOfMeasureType.Gallons;
            report.reportCurrency = MFCurrencyType.USD;
            return report;
        }
        public static DistributorReportType BlenderReport(PXDMV table)
        {
            DistributorReportType report = baseReport();
            report.ReportID = MFReportIdType.BLDR;
            report.DistributorReportDetails = new MFReportDetailType[]
            { DistributorSchedule.Blender(true, Unknown<Decimal>.Fixme(0.0m)) // gas
            , DistributorSchedule.Blender(false, Unknown<Decimal>.Fixme(0.0m)) // diesel
            };
            return report;
        }
    }
}
