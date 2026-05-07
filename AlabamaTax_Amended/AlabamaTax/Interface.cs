using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AlabamaTax
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
            populate();
            this.Text += " " + Version.Pretty();
        }

        private void populate()
        {
            //serverTextBox.Text = "wssrv05";
            //databaseTextBox.Text = "COUGAROILAPP";
            //etinTextBox.Text = "12345";
            //transmitterIDTextBox.Text = "123456";
            //feinTextBox.Text = "470000002";

            transmitterTypeComboBox.DataSource = Enum.GetValues(typeof(ItemChoiceType9));
            monthPicker.Value = DateTime.Now.AddMonths(-1);
        }
        private void log(string info)
        {
            string line = String.Format("[{0:hh:mm:ss}] -- {1} --{2}", DateTime.Now, info, Environment.NewLine);
            logTextBox.AppendText(line);
        }

        private Create.ReportType selectedReportType()
        {
            Create.ReportType? type =
                carrierRadioButton.Checked ?
                Create.ReportType.Carrier :
                (distributorRadioButton.Checked ?
                Create.ReportType.Distributor :
                (supplierRadioButton.Checked ?
                Create.ReportType.Supplier :
                (terminalOperatorRadioButton.Checked ?
                (Create.ReportType?)Create.ReportType.Terminal : null)));
            if (!type.HasValue)
                throw new Exception("Unknown report type selection.");
            return type.Value;
        }
        private void submit()
        {
            submitButton.Enabled = false;
            Submission sub = new Submission(
                reportType: selectedReportType(),
                transmitterType: (ItemChoiceType9)transmitterTypeComboBox.SelectedValue,
                transmitterID: transmitterIDTextBox.Text,
                fein: feinTextBox.Text,
                reportingMonth: monthPicker.Value,
                testing: testCheckBox.Checked,
                server: serverTextBox.Text,
                database: databaseTextBox.Text,
                username: userTextBox.Text,
                password: passwordTextBox.Text,
                logInfo: log,
                updateStatus: (val, max) => { progressBar.Maximum = max; progressBar.Value = val; },
                done: () => { submitButton.Enabled = true; }           
            );
            Thread subThread = new Thread(new ThreadStart(sub.Submit));
            subThread.IsBackground = true;
            subThread.Start();
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            const string question =
@"You have selected to make a production submission.
This will electronically file a {0} Motor Fuel Excise Tax return with the state of Alabama.
Are you sure you wish to continue?";
            if (!testCheckBox.Checked)
            {
                DialogResult answer = MessageBox.Show(String.Format(question, selectedReportType()), "Are you sure?", MessageBoxButtons.YesNo);
                if (answer != DialogResult.Yes)
                {
                    return;
                }
            }
            submit();
        }
    }
}
