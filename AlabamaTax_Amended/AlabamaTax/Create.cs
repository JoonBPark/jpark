using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class Create
    {
        public enum ReportType
        {
            Carrier, // validated
            Supplier, // validated
            Distributor, // validated
            Terminal // validated
        }
        public static TransmissionHeaderTypeAgentIdentifier Agent(ReportType rtype)
        {
            switch (rtype)
            {
                case ReportType.Carrier: return TransmissionHeaderTypeAgentIdentifier.XMLTRN;
                case ReportType.Supplier:
                case ReportType.Distributor: return TransmissionHeaderTypeAgentIdentifier.XMLTXT;
                case ReportType.Terminal: return TransmissionHeaderTypeAgentIdentifier.XMSTOM;
            }
            throw new Exception("Unhandled report type");
        }
        public static TransmissionHeaderType TransmissionHeader(TransmissionHeaderTypeAgentIdentifier agent, ItemChoiceType9 transmitterType, string transmitterID, string id, bool testing = false)
        {
            TransmissionHeaderType header = new TransmissionHeaderType();
            header.recordCount = "1";
            header.Jurisdiction = "ALABAMA"; // AL or ALABAMA? spec is unclear, ALABAMA used in sample xml
            header.TransmissionId = id;
            header.ProcessType = testing ? TransmissionHeaderTypeProcessType.T : TransmissionHeaderTypeProcessType.P;
            header.AgentIdentifier = agent;
            header.Timestamp = Timestamp.Now;
            {
                TransmissionHeaderTypeTransmitter transmitter = new TransmissionHeaderTypeTransmitter();
                transmitter.ItemElementName = transmitterType;
                transmitter.Item = transmitterID;
                header.Transmitter = transmitter;
            }
            return header;
        }

        public static MotorFuelsHeaderType MotorFuelsHeader(int year, int month, String FEIN)
        {
            MotorFuelsHeaderType header = new MotorFuelsHeaderType();
            header.Timestamp = Timestamp.Now;
            header.TaxPeriodBeginDate = new DateTime(year: year, month: month, day: 1);
            header.TaxPeriodBeginDateSpecified = true;
            header.TaxPeriodEndDate = header.TaxPeriodBeginDate.AddMonths(1).AddDays(-1);
            header.TaxPeriodEndDateSpecified = true;
            header.TaxYear = year.ToString();
            header.Jurisdiction = "AL";
            header.SoftwareId = "67777383"; // 67 77 73 83
                                           // C  M  I  S
            header.SoftwareVersion = Version.Current();

            header.AmendedReturnIndicator = "X";
            header.AmendedReturnIndicatorSpecified = true;
            
            
            //header.TypeOfFiling = MFFilingType.Original;
            header.TypeOfFiling = MFFilingType.Replace;

            //{
            //    ReturnHeaderTypeOriginator originator = new ReturnHeaderTypeOriginator();
            //    originator.ItemElementName = ItemChoiceType6.EFIN;
            //    originator.Item = EFIN; // EFIN is required (6 digits)
            //    // Originator type optional according to docs, but always gets included so must be required in XSD...
            //    originator.OriginatorTypeCd = Unknown<OriginatorType>.Fixme(OriginatorType.ERO);
            //    header.Originator = originator;
            //}
            {
                MFFilerType filer = new MFFilerType();
                filer.ItemElementName = ItemChoiceType7.FEIN;
                filer.Item = FEIN;
                header.Filer = filer;
            }
            return header;
        }

        public class Carrier
        {
            public static CarrierScheduleType Schedule
            (MFCarrierScheduleCode scheduleCode
            , MFProductCode productCode
            , MFModeCode mode
            , String documentNumber
            , DateTime receivedShippedDate
            , StateOnlyType originState
            , String sellerName
            , String sellerFEIN
            , String deliveredToName
            , String deliveredToFEIN
            , String deliveredToAddress
            , String consignorName
            , String consignorFEIN
            , Decimal? net = null
            , Decimal? gross = null
            )
            {
                CarrierScheduleType sch = new CarrierScheduleType();
                sch.ScheduleCode = scheduleCode;
                sch.ProductCode = productCode;
                sch.Mode = mode;
                sch.DocumentNumber = documentNumber;
                sch.ReceivedShippedDate = receivedShippedDate;
                sch.Origin = new CarrierScheduleTypeOrigin();
                sch.Origin.State = originState;
                sch.Seller = new CarrierScheduleTypeSeller();
                sch.Seller.Name = sellerName;
                sch.Seller.FEIN = sellerFEIN;
                sch.DeliveredTo = new CarrierScheduleTypeDeliveredTo();
                sch.DeliveredTo.Name = deliveredToName;
                sch.DeliveredTo.FEIN = deliveredToFEIN;
                sch.DeliveredTo.Address = deliveredToAddress;
                if (net != null) sch.Net = net.Value;
                if (gross != null) sch.Gross = gross.Value;
                sch.Consignor = new CarrierScheduleTypeConsignor();
                sch.Consignor.Name = consignorName;
                sch.Consignor.FEIN = consignorFEIN;
                sch.DiversionNumber = MFDiversionNumberType.TRPR1;
                return sch;
            }
            public static CarrierReportType Report(IEnumerable<CarrierScheduleType> schedules)
            {
                CarrierReportType report = new CarrierReportType();
                report.reportUOM = MFUnitsOfMeasureType.Gallons;
                report.reportCurrency = MFCurrencyType.USD;
                report.ReportID = MFReportIdType.TRPR;
                if (schedules.Count() == 0)
                {
                    report.NoActivity = CheckboxType.X;
                    report.NoActivitySpecified = true;
                }
                else
                {
                    report.CarrierSchedule = schedules.ToArray();
                }
                return report;
            }
        }

        public class Distributor
        {
            public static MFReportDetailType BlenderDetail(MFProductCode productCode, Decimal quantity)
            {
                MFReportDetailType dtl = new MFReportDetailType();
                dtl.ProductCode = productCode;
                MFReportDetailTypeGeneralQuantity qty = new MFReportDetailTypeGeneralQuantity();
                if (productCode == MFProductCode.Item065) qty.generalQuantityItem = "GasolineBlend";
                else if (productCode == MFProductCode.Item160) qty.generalQuantityItem = "UndyedDieselBlend";
                else throw new Exception("Product code must be 065 or 160 for a blender report.");
                qty.Value = quantity;
                dtl.Items1 = new object[] { qty };
                return dtl;
            }
            public static DistributorScheduleType Schedule
            (MFDistributorScheduleCode scheduleCode
            , MFProductCode productCode
            , MFModeCode mode
            , String documentNumber
            , DateTime receivedShippedDate
            , Decimal? net = null
            , Decimal? gross = null
            , String sellerName = null
            , String sellerFEIN = null
            , String purchaserName = null
            , String purchaserFEIN = null
            , String carrierName = null
            , String carrierFEIN = null
            , StateOnlyType originState = StateOnlyType.AL
            , StateOnlyType destinationState = StateOnlyType.AL
            )
            {
                // Generally, everything should be either originating in Alabama and ending up
                // in another state, or originating in another state and ending up in Alabama.
                // The only exception is schedule 11B, which can sometimes be intended for
                // another state but end up in Alabama, so is origin and destination are both AL.
                // In that case, it is treated like an export (since that was the original intent).
                DistributorScheduleType sch = new DistributorScheduleType();
                sch.ScheduleCode = scheduleCode;
                if (originState != StateOnlyType.AL && destinationState == StateOnlyType.AL)
                {
                    switch (sch.ScheduleCode)
                    {
                        case MFDistributorScheduleCode.Item3B:
                            sch.DiversionNumber = MFDiversionNumberType.IMR1;
                            break;
                        case MFDistributorScheduleCode.Item11B:
                            sch.DiversionNumber = MFDiversionNumberType.IMR2;
                            break;
                        case MFDistributorScheduleCode.Item1A:
                            sch.DiversionNumber = MFDiversionNumberType.IMR3;
                            break;
                        case MFDistributorScheduleCode.Item1C:
                            sch.DiversionNumber = MFDiversionNumberType.IMR4;
                            break;
                        default:
                            throw new Exception("Bad schedule code for import: " + sch.ScheduleCode);
                    }
                }
                else if (originState == StateOnlyType.AL && destinationState != StateOnlyType.AL
                    || sch.ScheduleCode == MFDistributorScheduleCode.Item11B)
                {
                    switch (sch.ScheduleCode)
                    {
                        case MFDistributorScheduleCode.Item7B:
                            sch.DiversionNumber = MFDiversionNumberType.EXPR1;
                            break;
                        case MFDistributorScheduleCode.Item11A:
                        case MFDistributorScheduleCode.Item11B:
                            sch.DiversionNumber = MFDiversionNumberType.EXPR2;
                            break;
                        case MFDistributorScheduleCode.Item7A:
                            sch.DiversionNumber = MFDiversionNumberType.EXPR3;
                            break;
                        default:
                            throw new Exception("Bad schedule code for export: " + sch.ScheduleCode);
                    }
                }
                else throw new Exception("Data represents neither import nor export: " + sch.ScheduleCode);
                sch.ProductCode = productCode;
                sch.Mode = mode;
                sch.DocumentNumber = documentNumber;
                sch.ReceivedShippedDate = receivedShippedDate;
                sch.Origin = new DistributorScheduleTypeOrigin();
                sch.Origin.State = originState;
                sch.Destination = new DistributorScheduleTypeDestination();
                sch.Destination.State = destinationState;
                sch.Carrier = new DistributorScheduleTypeCarrier();
                sch.Carrier.Name = carrierName;
                sch.Carrier.FEIN = carrierFEIN;
                switch (sch.DiversionNumber)
                {
                    case MFDiversionNumberType.IMR1:
                    case MFDiversionNumberType.IMR3:
                    case MFDiversionNumberType.IMR4:
                        sch.Seller = new DistributorScheduleTypeSeller();
                        sch.Seller.Name = sellerName;
                        sch.Seller.FEIN = sellerFEIN;
                        break;
                    case MFDiversionNumberType.IMR2:
                    case MFDiversionNumberType.EXPR1:
                    case MFDiversionNumberType.EXPR2:
                    case MFDiversionNumberType.EXPR3:
                        sch.Purchaser = new DistributorScheduleTypePurchaser();
                        sch.Purchaser.Name = purchaserName;
                        sch.Purchaser.FEIN = purchaserFEIN;
                        break;
                }
                if (net != null) sch.Net = net.Value;
                if (gross != null) sch.Gross = gross.Value;
                return sch;
            }
            public static DistributorReportType Report
            (MFReportIdType reportID
            , DateTime reportingMonth
            , IEnumerable<DistributorScheduleType> schedules = null
            , IEnumerable<MFReportDetailType> blenders = null
            )
            {
                DistributorReportType report = new DistributorReportType();
                report.ReportID = reportID;
                report.reportUOM = MFUnitsOfMeasureType.Gallons;
                report.reportCurrency = MFCurrencyType.USD;
                switch (report.ReportID)
                {
                    case MFReportIdType.IMR:
                    case MFReportIdType.EXPR:
                        if (schedules.Count() <= 0)
                        {
                            report.NoActivity = CheckboxType.X;
                            report.NoActivitySpecified = true;
                        }
                        else
                        {
                            report.TotalDueSpecified = true;
                            if (report.ReportID == MFReportIdType.IMR)
                                report.TotalDue = Tax.ImportTotalDue(reportingMonth, schedules);
                            else report.TotalDue = Tax.ExportTotalDue(reportingMonth, schedules);
                            report.DistributorSchedule = schedules.ToArray();
                        }
                        break;
                    case MFReportIdType.BLDR:
                        if (blenders.Count() <= 0)
                        {
                            report.NoActivity = CheckboxType.X;
                            report.NoActivitySpecified = true;
                        }
                        else report.DistributorReportDetails = blenders.ToArray();
                        break;
                    default:
                        throw new Exception("ReportID not valid for distributor report: " + report.ReportID);
                }
                return report;
            }
        }

        public class Supplier
        {
            public static SupplierScheduleType Schedule
            (MFSupplierScheduleCode scheduleCode
            , MFProductCode productCode
            , MFModeCode mode
            , String documentNumber
            , DateTime receivedShippedDate
            , StateOnlyType originState
            , StateOnlyType destinationState
            , String carrierName
            , String carrierFEIN
            , Decimal? net = null
            , Decimal? gross = null
            , String sellerName = null
            , String sellerFEIN = null
            , String purchaserName = null
            , String purchaserFEIN = null
            , String terminalCode = null
            )
            {
                SupplierScheduleType sch = new SupplierScheduleType();
                sch.ScheduleCode = scheduleCode;
                sch.ProductCode = productCode;
                sch.Mode = mode;
                sch.DocumentNumber = documentNumber;
                sch.ReceivedShippedDate = receivedShippedDate;
                sch.Origin = new SupplierScheduleTypeOrigin();
                sch.Origin.State = originState;
                sch.Destination = new SupplierScheduleTypeDestination();
                sch.Destination.State = destinationState;
                sch.Carrier = new SupplierScheduleTypeCarrier();
                sch.Carrier.Name = carrierName;
                sch.Carrier.FEIN = carrierFEIN;
                if (net != null) sch.Net = net.Value;
                if (gross != null) sch.Gross = gross.Value;
                switch (sch.ScheduleCode)
                {
                    case MFSupplierScheduleCode.Item1:
                    case MFSupplierScheduleCode.Item2:
                    case MFSupplierScheduleCode.Item2B:
                        sch.DiversionNumber = MFDiversionNumberType.SR1;
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
                        sch.DiversionNumber = MFDiversionNumberType.SR2;
                        break;
                    case MFSupplierScheduleCode.Item11A:
                    case MFSupplierScheduleCode.Item11B:
                        sch.DiversionNumber = MFDiversionNumberType.SR3;
                        break;
                }
                switch (sch.DiversionNumber)
                {
                    case MFDiversionNumberType.SR1:
                        sch.Seller = new SupplierScheduleTypeSeller();
                        sch.Seller.Name = sellerName;
                        sch.Seller.FEIN = sellerFEIN;
                        break;
                    case MFDiversionNumberType.SR2:
                    case MFDiversionNumberType.SR3:
                        sch.Origin.TerminalCode = terminalCode;
                        sch.Purchaser = new SupplierScheduleTypePurchaser();
                        sch.Purchaser.Name = purchaserName;
                        sch.Purchaser.FEIN = purchaserFEIN;
                        break;
                }
                return sch;
            }
            public static SupplierReportType Report(DateTime reportingMonth, IEnumerable<SupplierScheduleType> schedules)
            {
                SupplierReportType report = new SupplierReportType();
                report.reportUOM = MFUnitsOfMeasureType.Gallons;
                report.reportCurrency = MFCurrencyType.USD;
                report.ReportID = MFReportIdType.SR;
                report.SupplierSchedule = schedules.ToArray();
                report.TotalDue = Decimal.Round(Tax.SupplierTotalDue(reportingMonth, schedules), 2);
                return report;
            }
        }

        public class TerminalOperator
        {
            public static MFPositionHolderReportType PositionHolder
            (string holderName
            , string holderFEIN
            , IEnumerable<MFProductCode> productCodes
            , IEnumerable<MFTerminalInventoryType> terminalInventories
            )
            {
                MFPositionHolderReportType rep = new MFPositionHolderReportType();
                rep.PositionHolder = new MFParticipantType();
                rep.PositionHolder.Name = holderName;
                rep.PositionHolder.ItemElementName = ItemChoiceType8.FEIN;
                rep.PositionHolder.Item = holderFEIN;
                rep.ProductCode = productCodes.ToArray();
                rep.PositionHolderInventory = terminalInventories.ToArray();
                return rep;
            }
            public static TerminalReportDetailType ReportDetail
            (MFProductCode product
            , Decimal beginningInventory
            , Decimal gainLoss
            , Decimal physicalEndingInventory
            )
            {
                TerminalReportDetailType dtl = new TerminalReportDetailType();
                dtl.ProductCode = product;
                dtl.BeginningInventory = beginningInventory;
                dtl.BeginningInventorySpecified = true;
                dtl.GainLoss = gainLoss;
                dtl.GainLossSpecified = true;
                dtl.PhysicalEndingInventory = physicalEndingInventory;
                dtl.PhysicalEndingInventorySpecified = true;
                return dtl;
            }
            public static MFTerminalInventoryType Inventory
            (Decimal beginningInventory
            , Decimal totalReceipt
            , Decimal totalDisbursement
            , Decimal gainLoss
            )
            {
                MFTerminalInventoryType inv = new MFTerminalInventoryType();
                inv.BeginningInventory = beginningInventory;
                inv.BeginningInventorySpecified = true;
                Decimal endingInventory = beginningInventory + totalReceipt - totalDisbursement + gainLoss;
                inv.EndingInventory = endingInventory;
                inv.EndingInventorySpecified = true;
                inv.TotalDisbursement = totalDisbursement;
                inv.TotalDisbursementSpecified = true;
                inv.TotalReceipt = totalReceipt;
                inv.TotalReceiptSpecified = true;
                inv.GainLoss = gainLoss;
                inv.GainLossSpecified = true;
                return inv;
            }
            public static TerminalOperatorScheduleType Schedule
            (MFTOScheduleCode code
            , MFProductCode product
            , MFModeCode mode
            , string bolNumber
            , DateTime receivedShippedDate
            , string carrierName
            , string carrierFein
            , string holderName
            , string holderFein
            , Decimal? net = null
            , Decimal? gross = null
            )
            {
                TerminalOperatorScheduleType sch = new TerminalOperatorScheduleType();
                sch.ScheduleCode = code;
                sch.ProductCode = product;
                sch.Mode = mode;
                sch.DocumentNumber = bolNumber;
                sch.ReceivedShippedDate = receivedShippedDate;
                sch.Carrier = new TerminalOperatorScheduleTypeCarrier();
                sch.Carrier.Name = carrierName;
                sch.Carrier.FEIN = carrierFein;
                sch.PositionHolder = new TerminalOperatorScheduleTypePositionHolder();
                sch.PositionHolder.Name = holderName;
                sch.PositionHolder.FEIN = holderFein;
                if (net != null) sch.Net = net.Value;
                if (gross != null) sch.Gross = gross.Value;
                return sch;
            }
            public static TerminalOperatorReportType Report
            ( String terminalCode
            , IEnumerable<TerminalReportDetailType> reportDetails
            , IEnumerable<MFPositionHolderReportType> positionHolders
            , IEnumerable<TerminalOperatorScheduleType> schedules
            )
            {
                TerminalOperatorReportType report = new TerminalOperatorReportType();
                report.reportUOM = MFUnitsOfMeasureType.Gallons;
                report.reportCurrency = MFCurrencyType.USD;
                report.ReportID = MFReportIdType.TOM;
                report.TerminalCode = terminalCode;
                report.TerminalReportDetails = reportDetails.ToArray();
                report.TerminalPositionHolderReport = positionHolders.ToArray();
                report.TerminalOperatorSchedule = schedules.ToArray();
                return report;
            }
        }
    }
}
