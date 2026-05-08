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


    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
            if(!string.IsNullOrEmpty(Properties.Settings.Default.Connection))
            {
                this.txtConnection.Text = Properties.Settings.Default.Connection;
                Properties.Settings.Default.Save();
            }
            else
            { 
                this.txtConnection.Text =@"Data Source=CO-SQL01;Initial Catalog=CHAMBERSAPP;Integrated Security=True";

                // private static string ConnString = @"Data Source=KRSTEKJPARK-LEN\SQLSRV2019;Initial Catalog=CHAMBERSAPP; UserID=sa;Password=Axsys12";
                // @"Data Source=GPEELE-HP\SQL2017;Initial Catalog=Claims;Integrated Security=True";
            }
        }
        private void btnClaims_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Connection = this.txtConnection.Text;
            Properties.Settings.Default.Save();
            ClaimsForm claimsForm = new ClaimsForm(this.txtConnection.Text);
            claimsForm.ShowDialog();
        }

        private void btnMSAs_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Connection = this.txtConnection.Text;
            Properties.Settings.Default.Save();
            MSAForm mSAForm = new MSAForm(this.txtConnection.Text);
            mSAForm.ShowDialog();
        }

        private void Selection_Load(object sender, EventArgs e)
        {

        }

        private void btnUploadMSA_Click(object sender, EventArgs e)
        {
            // Creates or loads an INI file in the same directory as your executable
            // named EXE.ini (where EXE is the name of your executable)
            //var MyIni = new INIFile();

            // Or specify a specific name in the current dir
            var MyIni = new INIFile("Settings.ini");
            var DefaultVolume = MyIni.Read("DefaultVolume", "MyProg");
            MessageBox.Show(DefaultVolume);

            // Or specify a specific name in a specific dir
            //var MyIni = new INIFile(@"C:\Settings.ini");


            /* You can write some values like so:

            MyIni.Write("DefaultVolume", "100");
            MyIni.Write("HomePage", "http://www.google.com");

            To create a file like this:
            [MyProg]
            DefaultVolume=100
            HomePage=http://www.google.com

            To read the values out of the INI file:

var DefaultVolume = MyIni.Read("DefaultVolume");
var HomePage = MyIni.Read("HomePage");

Optionally, you can set [Section]'s:

MyIni.Write("DefaultVolume", "100", "Audio");
MyIni.Write("HomePage", "http://www.google.com", "Web");

To create a file like this:

[Audio]
DefaultVolume=100

[Web]
HomePage=http://www.google.com

            */

        }





        private void btnTEST_Click(object sender, EventArgs e)
        {
            var productNumbers = new List<string>() { "011111", " 222220 " };
            Console.WriteLine(productNumbers[0]);
            Console.WriteLine(productNumbers[1]);

            //productNumbers.TrimAll();
            //productNumbers.TrimExcess();
            //productNumbers.ForEach(x => x = x.Trim().TrimStart().TrimEnd());

            Console.WriteLine(productNumbers[0]);
            Console.WriteLine(productNumbers[1]);
        }


        /*
          public static class StringListExtensions
        {
            public static void TrimAll(this List<string> stringList)
            {
                for (int i = 0; i < stringList.Count; i++)
                {
                    stringList[i] = stringList[i].Trim(); //warning: do not change this to lambda expression (.ForEach() uses a copy)
                }
            }
        }



        private void btnTEST_Click(object sender, EventArgs e)
        {
            var productNumbers = new List<string>() { "011111", " 222220 " };
            Console.WriteLine(productNumbers[0]);
            Console.WriteLine(productNumbers[1]);

            productNumbers.TrimAll();
            //productNumbers.TrimExcess();
            //productNumbers.ForEach(x => x = x.Trim().TrimStart().TrimEnd());

            Console.WriteLine(productNumbers[0]);
            Console.WriteLine(productNumbers[1]);
        }
         */

    }
}
