using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace AlabamaTax
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new Interface());
            return;
        }
    }
}
