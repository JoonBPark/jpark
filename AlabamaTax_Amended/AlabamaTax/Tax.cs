using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
namespace AlabamaTax
{
    class Tax
    {
        public enum FuelRate
        {
            Gasoline,
            UndyedDiesel,
            AviationGasoline,
            JetFuel,
            UntaxedDyedDiesel,
            TransMix, //joon 20240717
            UntaxedOther
        }
        public class Schedule
        {
            public Decimal Gallons;
            public MFProductCode ProductCode;
            public Schedule(MFProductCode product, Decimal gallons)
            {
                Gallons = gallons;
                ProductCode = product;
            }
        }
        class Taxable
        {
            public Decimal Net;
            public FuelRate Rate;
            public Taxable(Decimal net, FuelRate rate)
            {
                Net = net;
                Rate = rate;
            }
        }
        private static Decimal ApplyLateFee(DateTime reportingMonth, Decimal taxDue)
        {
            DateTime cutoff = new DateTime(reportingMonth.Year, reportingMonth.Month, 22).AddMonths(1);
            MessageBox.Show(cutoff.ToString() + " " + reportingMonth.ToString() + " " + DateTime.Now);
            if (DateTime.Now.Date > cutoff)
            {
                taxDue += Math.Max(taxDue + taxDue * 0.1m, taxDue + 50m);
            }
            return taxDue;
        }
        public static Decimal ExportRefund(IEnumerable<DistributorScheduleType> schedules)
        {
            var section1 = from s in schedules
                           where s.ScheduleCode == MFDistributorScheduleCode.Item7B
                           || s.ScheduleCode == MFDistributorScheduleCode.Item11A
                           select new Taxable(s.Net, RateType(s.ProductCode));
            var line3 = from t in section1
                        group t by t.Rate into g
                        select new Taxable(g.Sum(t => t.Net), g.Key);
            var line5 = from col in line3
                        select col.Net * TaxRate(col.Rate);
            return line5.Sum();
        }
        public static Decimal ExportTotalDue(DateTime reportingMonth, IEnumerable<DistributorScheduleType> schedules)
        {
            var section2 = from s in schedules
                           where s.ScheduleCode == MFDistributorScheduleCode.Item11B
                           select new Taxable(s.Net, RateType(s.ProductCode));
            var line6 = from t in section2
                        group t by t.Rate into g
                        select new Taxable(g.Sum(t => t.Net), g.Key);
            var line8 = from col in line6
                        select col.Net * TaxRate(col.Rate);
            return ApplyLateFee(reportingMonth, line8.Sum());
        }
        public static Decimal ImportTotalDue(DateTime reportingMonth, IEnumerable<DistributorScheduleType> schedules)
        {
            var line9 = from s in schedules
                        where s.ScheduleCode == MFDistributorScheduleCode.Item3B
                        || s.ScheduleCode == MFDistributorScheduleCode.Item11B
                        select new Taxable(s.Net, RateType(s.ProductCode));
            var line11 = from t in line9
                         group t by t.Rate into g
                         select new Taxable(g.Sum(t => t.Net), g.Key); // sum by rate
            var line3 = from c in line11
                        select c.Net * TaxRate(c.Rate);
            return ApplyLateFee(reportingMonth, line3.Sum());
        }
        public static Decimal SupplierTotalDue(DateTime reportingMonth, IEnumerable<SupplierScheduleType> schedules)
        {
            var taxables = from schedule in schedules
                           where schedule.ScheduleCode == MFSupplierScheduleCode.Item5A
                           || schedule.ScheduleCode == MFSupplierScheduleCode.Item5C
                           || schedule.ScheduleCode == MFSupplierScheduleCode.Item2
                           || schedule.ScheduleCode == MFSupplierScheduleCode.Item5Q
                           || schedule.ScheduleCode == MFSupplierScheduleCode.Item11B
                           || schedule.ScheduleCode == MFSupplierScheduleCode.Item10B
                           || schedule.ScheduleCode == MFSupplierScheduleCode.Item2B
                           select new Taxable(schedule.Net, RateType(schedule.ProductCode));
            var line1 = from t in taxables
                        group t by t.Rate into g
                        select new Taxable(g.Sum(t => t.Net), g.Key);

            var line3 = from fuel in line1
                        select fuel.Net * TaxRate(fuel.Rate);

            var line4 = from col in line3
                        select col * 0.005m;

            var line5 = from col in line3
                        select col * 0.001m;
            Decimal totalDiscount = line5.Sum();
            const Decimal maxDiscount = 2000m;
            if (totalDiscount > maxDiscount)
            {
                decimal proRate = maxDiscount / totalDiscount;
                line5 = from col in line5
                        select col * proRate;
            }
            var discount = line4.Zip(line5, (d0, d1) => d0 + d1);
            var line6 = line3.Zip(discount, (t, d) => t - d);

            return ApplyLateFee(reportingMonth, line6.Sum());
        }
        public static Decimal TaxRate(FuelRate rate)
        {
            //Effective September 1, 2019, the gasoline and undyed diesel excise taxes will increase by $.06
            //per gallon to $.24 per gallon for gasoline and to $.25 per gallon for undyed diesel.

            //Rebuild Alabama Act Notice 8/2020 - Informational update concerning tax rate change
            //This notice was sent to all of the Alabama motor fuel licensees.  
            //I wanted to make sure your company was made aware of the tax rate change for the Alabama gasoline (changing from $.24 to $.26 per gallon) 
            //and undyed diesel fuel (changing from $.25 to $.27) excise tax rates effective with the October 2020 period that will be due November 20, 2020.  

            //20210930
            //tax rate change for the Alabama gasoline (changing from $.26 to $.28 per gallon) and undyed diesel fuel (changing from $.27 to $.29) excise tax rates effective with the October 2021 period.  

            //20231116: tax rate for Alabama gas went from .28 to .29

            switch (rate)
            {
                //20231116: tax rate for Alabama gas went from .28 to .29 //0.24m;   // 0.16
                // 20250806: The rates as of 7/1/2025 for Alabama are .30 on gas and .31 on the LD
                case FuelRate.Gasoline:
                    return 0.30m;
                case FuelRate.UndyedDiesel:
                    return 0.31m;  //0.29m;   //0.25m;  // 0.19
                case FuelRate.AviationGasoline:
                    return 0.095m;
                case FuelRate.JetFuel:
                    return 0.035m;
                case FuelRate.TransMix: //joon 20240717
                    return 0.3m; //joon 20240717
                default:
                    return 0.0m;
            }
        }
        public static FuelRate RateType(MFProductCode fta)
        {
            switch (fta)
            {
                case MFProductCode.Item052:
                case MFProductCode.Item055:
                case MFProductCode.Item058:
                case MFProductCode.Item059:
                case MFProductCode.Item061:
                case MFProductCode.Item065:
                case MFProductCode.Item071:
                case MFProductCode.Item075:
                case MFProductCode.Item076:
                case MFProductCode.Item078:
                case MFProductCode.Item079:
                case MFProductCode.Item090:
                case MFProductCode.Item091:
                case MFProductCode.Item093:
                case MFProductCode.Item121:
                case MFProductCode.Item122:
                case MFProductCode.Item123:
                case MFProductCode.Item124:
                case MFProductCode.Item126:
                case MFProductCode.Item139:
                case MFProductCode.Item140:
                case MFProductCode.Item141:
                case MFProductCode.Item196:
                case MFProductCode.Item198:
                case MFProductCode.Item199:
                case MFProductCode.Item223:
                case MFProductCode.Item241:
                case MFProductCode.Item243:
                case MFProductCode.Item248:
                case MFProductCode.Item249:
                case MFProductCode.Item265:
                    return FuelRate.Gasoline;
                case MFProductCode.Item142:
                case MFProductCode.Item145:
                case MFProductCode.Item147:
                case MFProductCode.Item150:
                case MFProductCode.Item154:
                case MFProductCode.Item160:
                case MFProductCode.Item161:
                case MFProductCode.Item167:
                case MFProductCode.Item170:
                case MFProductCode.Item282:
                case MFProductCode.Item283:
                case MFProductCode.Item285:
                case MFProductCode.Item960:
                    return FuelRate.UndyedDiesel;
                case MFProductCode.Item125:
                    return FuelRate.AviationGasoline;
                case MFProductCode.Item130:
                    return FuelRate.JetFuel;
                case MFProductCode.Item072:
                case MFProductCode.Item073:
                case MFProductCode.Item074:
                case MFProductCode.Item153:
                case MFProductCode.Item171:
                case MFProductCode.Item226:
                case MFProductCode.Item227:
                case MFProductCode.Item228:
                case MFProductCode.Item231:
                    return FuelRate.UntaxedDyedDiesel;
                case MFProductCode.Item001:
                case MFProductCode.Item054:
                case MFProductCode.Item077:
                case MFProductCode.Item092:
                //case MFProductCode.Item100:  //joon 20240717 // Transmix is subject to excise tax if it is imported, and this was imported from Florida.
                case MFProductCode.Item152:
                case MFProductCode.Item175:
                case MFProductCode.Item188:
                case MFProductCode.Item224:
                case MFProductCode.Item225:
                case MFProductCode.Item259:
                case MFProductCode.Item279:
                case MFProductCode.Item280:
                case MFProductCode.Item281:
                    return FuelRate.UntaxedOther;
                case MFProductCode.Item100:
                    return FuelRate.TransMix; //joon 20240717

                default:
                    throw new Exception("Unknown tax rate for fuel type " + fta.ToString());
            }
        }
    }
}
