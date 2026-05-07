using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class PositionHolderReport
    {
        public static MFPositionHolderReportType Create(
            string holderName,
            string holderFein,
            IList<MFProductCode> product,
            IList<MFTerminalInventoryType> terminalInventory)
        {
            MFPositionHolderReportType rep = new MFPositionHolderReportType();
            rep.PositionHolder = new MFParticipantType();
            rep.PositionHolder.Name = holderName;
            rep.PositionHolder.ItemElementName = ItemChoiceType8.FEIN;
            rep.PositionHolder.Item = holderFein;
            rep.ProductCode = product.ToArray();
            rep.PositionHolderInventory = terminalInventory.ToArray();
            return rep;
        }
    }
}
