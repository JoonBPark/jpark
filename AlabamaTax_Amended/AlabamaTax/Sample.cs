using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    /// <summary>
    /// Hardcoded sample data for each type of transmission.
    /// </summary>
    class Sample
    {
        public static MotorFuelsFiling DistributorFiling()
        {
            MotorFuelsFiling motorFuels = new MotorFuelsFiling();
            motorFuels.SubmissionId = "ALMFET";
            motorFuels.MotorFuelsHeader = Create.MotorFuelsHeader(2012, 10, "470000004");
            motorFuels.DistributorReport = new DistributorReportType[]
            { Create.Distributor.Report
                (MFReportIdType.IMR
                , DateTime.Now.AddMonths(-1)
                , schedules:
                new DistributorScheduleType []
                { Create.Distributor.Schedule
                  ( scheduleCode: MFDistributorScheduleCode.Item3B
                  , productCode: MFProductCode.Item065
                  , mode: MFModeCode.R
                  , documentNumber: "112131"
                  , receivedShippedDate: new DateTime(2012, 10, 3)
                  , originState: StateOnlyType.LA
                  , carrierName: "K D LORGAN"
                  , carrierFEIN: "129638527"
                  , sellerName: "NMA OIL CO INC"
                  , sellerFEIN: "470000006"
                  , net: 89777m
                  )
                , Create.Distributor.Schedule
                  ( scheduleCode: MFDistributorScheduleCode.Item11B
                  , productCode: MFProductCode.Item125
                  , mode: MFModeCode.S
                  , documentNumber: "12055"
                  , receivedShippedDate: new DateTime(2012, 10, 3)
                  , originState: StateOnlyType.LA
                  , carrierName: "OAKLEY PIPELINE"
                  , carrierFEIN: "470000007"
                  , purchaserName: "PJ OIL CO"
                  , purchaserFEIN: "470000004"
                  , net: 84000m
                  )
                }
                )
            , Create.Distributor.Report
                (MFReportIdType.EXPR
                , DateTime.Now.AddMonths(-1)
                , schedules:
                new DistributorScheduleType []
                {
                    Create.Distributor.Schedule
                    ( scheduleCode: MFDistributorScheduleCode.Item7B
                    , productCode: MFProductCode.Item065
                    , mode: MFModeCode.J
                    , documentNumber: "24371"
                    , receivedShippedDate: new DateTime(2012, 10, 2)
                    , destinationState: StateOnlyType.GA
                    , carrierName: "K D LORGAN"
                    , carrierFEIN: "129638527"
                    , purchaserName: "LEXON COMPANY US"
                    , purchaserFEIN: "470000002"
                    , net: 8426m
                    )
                }
                )
            , Create.Distributor.Report
                (MFReportIdType.BLDR
                , DateTime.Now.AddMonths(-1)
                , blenders:
                new MFReportDetailType []
                {
                    //Create.Distributor.BlenderDetail
                    //( MFProductCode.Item065
                    //, quantity: 2000
                    //),
                    //Create.Distributor.BlenderDetail
                    //( MFProductCode.Item160
                    //, quantity: 2000
                    //)
                }
                )
            };
            return motorFuels;
        }
        public static MotorFuelsFiling CarrierFiling()
        {
            MotorFuelsFiling motorFuels = new MotorFuelsFiling();
            motorFuels.SubmissionId = "ALMFET";
            motorFuels.MotorFuelsHeader = Create.MotorFuelsHeader(2012, 10, "470000002");
            motorFuels.CarrierReport =
            Create.Carrier.Report
                (new CarrierScheduleType[]
                { Create.Carrier.Schedule
                    ( scheduleCode: MFCarrierScheduleCode.Item14A
                    , productCode: MFProductCode.Item065
                    , mode: MFModeCode.J
                    , documentNumber : "638941483"
                    , receivedShippedDate : new DateTime(2012, 10, 5)
                    , originState: StateOnlyType.AL
                    , sellerName: "Paggett Oil Co"
                    , sellerFEIN: "129876543"
                    , deliveredToAddress: "123 Ripley Road Montgomery MS 36106"
                    , deliveredToName: "Lenan Transport"
                    , deliveredToFEIN: "780123456"
                    , net: 8541m
                    , consignorName: "K D Lorgan"
                    , consignorFEIN: "129638527"
                    )
                }
                );
            return motorFuels;
        }
        public static MotorFuelsFiling SupplierFiling()
        {
            MotorFuelsFiling motorFuels = new MotorFuelsFiling();
            motorFuels.SubmissionId = "ALMFET";
            motorFuels.MotorFuelsHeader = Create.MotorFuelsHeader(2012, 10, "470000006");
            motorFuels.SupplierReport =
            Create.Supplier.Report
                (DateTime.Now.AddMonths(-1)
                , new SupplierScheduleType[]
                { Create.Supplier.Schedule
                    ( scheduleCode : MFSupplierScheduleCode.Item2B
                    , productCode : MFProductCode.Item065
                    , mode: MFModeCode.PL
                    , documentNumber: "MG 01 137"
                    , receivedShippedDate: new DateTime(2012, 10, 20)
                    , originState: StateOnlyType.MS
                    , destinationState: StateOnlyType.AL
                    , carrierName: "TRANSPORT INC."
                    , carrierFEIN: "633764195"
                    , sellerName: "FUEL INC."
                    , sellerFEIN: "631928375"
                    , net: 113736m
                    , gross: 816m
                    )
                }
                );
            return motorFuels;
        }
        public static MotorFuelsFiling TerminalOperatorFiling()
        {
            MotorFuelsFiling motorFuels = new MotorFuelsFiling();
            motorFuels.SubmissionId = "ALMFET";
            motorFuels.MotorFuelsHeader = Create.MotorFuelsHeader(2012, 10, "470000007");
            motorFuels.TerminalOperatorReport = new TerminalOperatorReportType[]
            {
                Create.TerminalOperator.Report
                ( "T54AL1111"
                , reportDetails:
                new TerminalReportDetailType[]
                { Create.TerminalOperator.ReportDetail
                  ( product: MFProductCode.Item065
                  , beginningInventory: 23823967m
                  , gainLoss: 527m
                  , physicalEndingInventory: 15355863
                  )
                }
                , positionHolders:
                new MFPositionHolderReportType[]
                { Create.TerminalOperator.PositionHolder
                  ( productCodes: new MFProductCode[] { MFProductCode.Item065 }
                  , holderName: "OAKLEY PIPELINE"
                  , holderFEIN: "470000007"
                  , terminalInventories:
                  new MFTerminalInventoryType[]
                  { Create.TerminalOperator.Inventory
                    ( beginningInventory: 14023336m
                    , totalReceipt: 6597000m
                    , totalDisbursement: 5265000m
                    , gainLoss: 527m
                    )
                  }
                  )
                }
                , schedules: new TerminalOperatorScheduleType[]
                { Create.TerminalOperator.Schedule
                  ( code: MFTOScheduleCode.Item15A
                  , product: MFProductCode.Item065
                  , mode: MFModeCode.PL
                  , bolNumber: "1000"
                  , receivedShippedDate: new DateTime(2012, 10, 1)
                  , carrierFein: "470000002"
                  , carrierName: "LEXON COMPANY US"
                  , net: 6597000m
                  , holderFein: "470000007"
                  , holderName: "OAKLEY PIPELINE"
                  )
                , Create.TerminalOperator.Schedule
                  ( code: MFTOScheduleCode.Item15B
                  , product: MFProductCode.Item065
                  , mode: MFModeCode.PL
                  , bolNumber: "1000"
                  , receivedShippedDate: new DateTime(2012, 10, 1)
                  , carrierFein: "470000002"
                  , carrierName: "LEXON COMPANY US"
                  , net: 5265000m
                  , holderFein: "470000007"
                  , holderName: "OAKLEY PIPELINE"
                  )
                }
                )
            };
            //motorFuels.SupplierReport = new SupplierReportType();
            //motorFuels.SupplierReport.NoActivity = CheckboxType.X;
            return motorFuels;
        }
    }
}
