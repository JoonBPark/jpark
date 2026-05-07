using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AlabamaTax
{
    public class PXDMV
    {
        public string REPSTATE;
        public string PERIOD;
        public string SCHEDULE;
        public string CARRIER;
        public string CARRNAME;
        public string CARRFEIN;
        public string SUPPLIER;
        public string SUPPNAME;
        public string SUPPFEIN;
        public string TERMINAL;
        public string TERMCITY;
        public StateOnlyType? TERMSTATE;
        public DateTime? DELIVERYDATE;
        public string PURCHSELLNAME;
        public string PURCHSELLFEIN;
        public string BOLNBR;
        public string DOCID;
        public MFProductCode? DMVCODE;
        public Decimal GRSQTY;
        public Decimal NETQTY;
        public string DELVCITY;
        public StateOnlyType? DELVSTATE;
        public string SRCE;
        public string DELVCUSTID;

        public override string ToString()
        {
            string[] shows =
            { REPSTATE
            , PERIOD
            , SCHEDULE
            , CARRNAME
            , CARRFEIN
            , SUPPNAME
            , SUPPFEIN
            , TERMCITY
            , TERMSTATE.ToString()
            , DELIVERYDATE.ToString()
            , PURCHSELLNAME
            , PURCHSELLFEIN
            , BOLNBR
            , DMVCODE.ToString()
            , GRSQTY.ToString()
            , NETQTY.ToString()
            , DELVCITY
            , DELVSTATE.ToString()
            };
            return String.Join(", ", shows);
        }
    }
}
