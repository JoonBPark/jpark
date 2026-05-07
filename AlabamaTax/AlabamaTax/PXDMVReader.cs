using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AlabamaTax
{
    class PXDMVReader
    {
        private SqlDataReader reader;
        public PXDMVReader(SqlConnection conn, DateTime reporting)
        {
            const string query = @"
select REPSTATE
     , PERIOD
     , SCHEDULE
     , CARRIER
     , CARRNAME
     , CARRFEIN
     , SUPPLIER
     , SUPPNAME
     , SUPPFEIN
     , TERMINAL
     , TERMCITY
     , TERMSTATE
     , DELIVERYDATE
     , PURCHSELLNAME
     , PURCHSELLFEIN
     , BOLNBR
     , DOCID
     , DMVCODE
     , GRSQTY
     , NETQTY
     , DELVCITY
     , DELVSTATE
     , SRCE
     , DELVCUSTID
from dbo.PXDMV
where REPSTATE = 'AL'
and PERIOD = @period;
";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add(new SqlParameter("@period", reporting.ToString("yyyyMM")));
            reader = command.ExecuteReader();
        }
        public PXDMVReader(SqlDataReader data)
        {
            reader = data;
        }
        protected string GetString(int index)
        {
            object field = reader.GetValue(index);
            if (field == DBNull.Value) return null;
            return field.ToString().Trim();
        }
        protected string GetCode(int index, int length)
        {
            string raw = GetString(index);
            if (raw == null || raw == "") return null;
            string rep = Regex.Replace(raw, "[^a-zA-Z0-9]+", "");
            if (rep.Length != length)
            {
                throw new Exception(String.Format("Failed to retrieve alphanumeric code of length {0} ({1}) ({2})", length, raw, rep));
            }
            return rep;
        }
        protected string GetFEIN(int index)
        {
            return GetCode(index, 9);
        }
        protected string GetETIN(int index)
        {
            return GetCode(index, 5);
        }
        protected string GetEFIN(int index)
        {
            return GetCode(index, 6);
        }
        protected DateTime? GetDateTime(int index)
        {
            object field = reader.GetValue(index);
            if (!(field is DateTime)) return null;
            return (DateTime)field;
        }
        protected MFProductCode? GetProductCode(int index)
        {
            string raw = GetString(index);
            if (raw == null) return null;
            MFProductCode code;
            if (Enum.TryParse("Item" + raw, out code)) return code;
            return null;
        }
        protected StateOnlyType? GetState(int index)
        {
            string raw = GetString(index);
            if (raw == null) return null;
            StateOnlyType state;
            if (Enum.TryParse(raw, out state)) return state;
            return null;
        }
        protected Decimal GetDecimal(int index)
        {
            double raw = reader.GetDouble(index);
            return new Decimal(raw);
        }
        public IEnumerable<PXDMV> Rows()
        {
            for (PXDMV pxdmv = Read(); pxdmv != null; pxdmv = Read())
            {
                yield return pxdmv;
            }
        }
        public PXDMV Read()
        {
            if (reader.IsClosed) return null;
            if (!reader.Read())
            {
                return null;
            }
            PXDMV pxdmv = new PXDMV();
            pxdmv.REPSTATE = GetString(0);
            pxdmv.PERIOD = GetString(1);
            pxdmv.SCHEDULE = GetString(2);
            pxdmv.CARRIER = GetString(3);
            pxdmv.CARRNAME = GetString(4);
            pxdmv.CARRFEIN = GetFEIN(5);
            pxdmv.SUPPLIER = GetString(6);
            pxdmv.SUPPNAME = GetString(7);
            pxdmv.SUPPFEIN = GetFEIN(8);
            pxdmv.TERMINAL = GetString(9);
            pxdmv.TERMCITY = GetString(10);
            pxdmv.TERMSTATE = GetState(11);
            pxdmv.DELIVERYDATE = GetDateTime(12);
            pxdmv.PURCHSELLNAME = GetString(13);
            pxdmv.PURCHSELLFEIN = GetFEIN(14);
            pxdmv.BOLNBR = GetString(15);
            pxdmv.DOCID = GetString(16);
            pxdmv.DMVCODE = GetProductCode(17);
            pxdmv.GRSQTY = GetDecimal(18);
            pxdmv.NETQTY = GetDecimal(19);
            pxdmv.DELVCITY = GetString(20);
            pxdmv.DELVSTATE = GetState(21);
            pxdmv.SRCE = GetString(22);
            pxdmv.DELVCUSTID = GetString(23);

            return pxdmv;
        }
        public void Close()
        {
            reader.Close();
        }
    }
}
