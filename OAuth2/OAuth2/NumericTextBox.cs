using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace OAuth2
{

    public class NumericTextBox : TextBox
    {
        public List<char> allowedCharacters = new List<char>();
        public NumericTextBox()
        {
            allowedCharacters.Add(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            allowedCharacters.Add(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator));
            allowedCharacters.Add(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NegativeSign));

        }
 
    private bool _AllowCurrency = false;
    public bool AllowCurrency
    {
        get
        {
            return _AllowCurrency;
        }
        set
        {
            if (!_AllowCurrency == value)
            {
                if (_AllowCurrency)
                    allowedCharacters.Remove(System.Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol));
                else
                    allowedCharacters.Add(System.Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol));
                _AllowCurrency = value;
            }
        }
    }

    public bool EnforceDecimal { get; set; } = true;

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        e.Handled = true;
        if (allowedCharacters.Contains(e.KeyChar))
            e.Handled = false;
        else
        {
            UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(e.KeyChar);
            if (category == UnicodeCategory.Control || category == UnicodeCategory.DecimalDigitNumber)
                e.Handled = false;
        }
        base.OnKeyPress(e);
    }

    protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
    {
        if (EnforceDecimal)
        {
            if (TextLength > 0 && !IsNumeric(Text))
            {
                SelectAll();
                e.Cancel = true;
            }
        }
        base.OnValidating(e);
        }
        bool IsNumeric(string var)
        {
            double myNum;
            if (Double.TryParse(var, out myNum))
            {
                // it is a number
                return true;
            }
            else
            {
                return false;
                // it is not a number
            }
        }
        protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x302)
        {
                if (Clipboard.ContainsText())
                {
                    string clip = Clipboard.GetText();
                    if (!IsNumeric(clip))
                    {
                        m.Msg = 0;
                    }
                }
        }
        base.WndProc(ref m);
    }
}

}
