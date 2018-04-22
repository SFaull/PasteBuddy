using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasteBuddy
{
    public partial class Form1 : Form
    {
        SerialDeviceManager Arduino = new SerialDeviceManager();

        public Form1()
        {
            InitializeComponent();
            panelButton.Visible = false;    // hide button options initially
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSerialPorts.DataSource = Arduino.getComPorts();
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbSerialPorts.SelectedIndex > -1)
            {
               // MessageBox.Show(String.Format("You selected port '{0}'", cmbSerialPorts.SelectedItem));
                Arduino.Connect(cmbSerialPorts.SelectedItem.ToString());
                if (Arduino.isConnected())    // on successful connection
                {
                    btnConnect.Enabled = false;
                    panelButton.Visible = true;    // hide button options initially
                    labelConnectionStatus.Text = "Status: Connected";
                    populateFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a port first");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Arduino.applyChanges();
        }

        private void populateFields()
        {
            txtButtonPress1.Text = Arduino.readButtonPress(1);   // populate fields
            txtButtonRelease1.Text = Arduino.readButtonRelease(1);   // populate fields
        }
    }
}
