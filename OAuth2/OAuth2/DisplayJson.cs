using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAuth2
{
    public partial class DisplayJson : Form
    {
        public DisplayJson(string textToDisplay)
        {
            InitializeComponent();
            this.txtJson.Text = textToDisplay;
        }
    }
}
