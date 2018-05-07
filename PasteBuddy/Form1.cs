using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PasteBuddy
{
    public partial class Form1 : Form
    {
        SerialDeviceManager Arduino = new SerialDeviceManager();
        List<TextBox> textboxButtonPressList = new List<TextBox>();     // store all button press textboxes
        List<TextBox> textboxButtonReleaseList = new List<TextBox>();   // store all button release textboxes

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSerialPorts.DataSource = Arduino.getComPorts();
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            labelConnectionStatus.Text = "Status:";
            if (btnConnect.Text == "Connect")
            {
                if (cmbSerialPorts.SelectedIndex > -1)
                {
                    // MessageBox.Show(String.Format("You selected port '{0}'", cmbSerialPorts.SelectedItem));
                    bool success = Arduino.Connect(cmbSerialPorts.SelectedItem.ToString());
                    if (Arduino.isConnected() && success)    // on successful connection
                    {
                        btnConnect.Text = "Disconnect";
                        labelConnectionStatus.Text = "Status: Connected";
                        Thread.Sleep(500);
                        int buttonCount = Arduino.buttonCount();
                        generateUI(buttonCount);
                        populateFields();
                    }
                    else
                    {
                        labelConnectionStatus.Text = "Status: [ERROR] No response from device. Try a different COM port";
                    }
                }
                else
                {
                    MessageBox.Show("Please select a port first");
                }
            }
            else
            {
                btnConnect.Text = "Connect";
                panelButton.Visible = false;    // hide button options initially
                labelConnectionStatus.Text = "Status: Not Connected";
                Arduino.Disconnect();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            applyChanges(); // send changes to device
            populateFields();   // read back device memory into field
        }

        private void applyChanges()
        {
            int index = 0;
            foreach (TextBox textboxPress in textboxButtonPressList)
            {
                Arduino.writeButtonPress(index, textboxPress.Text);
                index++;
            }

            index = 0;
            foreach (TextBox textboxRelease in textboxButtonReleaseList)
            {
                Arduino.writeButtonRelease(index, textboxRelease.Text);
                index++;
            }
        }

        private void populateFields()
        {
            int index = 0;
            foreach(TextBox textboxPress in textboxButtonPressList)
            {
                textboxPress.Text = Arduino.readButtonPress(index);
                index++;
            }

            index = 0;
            foreach (TextBox textboxRelease in textboxButtonReleaseList)
            {
                textboxRelease.Text = Arduino.readButtonRelease(index);
                index++;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populateFields();
        }

        private void cmbSerialPorts_MouseClick(object sender, MouseEventArgs e)
        {
            cmbSerialPorts.DataSource = Arduino.getComPorts();
        }

        private void generateUI(int _buttonCount)
        {
            panelButton.Visible = true;    // show

            // generate as many UI elements that are required based on the number of buttons on the device
            for (int i = 0; i < _buttonCount; i++)
            {
                /* create textbox for button ID */
                TextBox textBox = new TextBox();
                textBox.Tag = i;
                textBox.Text = i.ToString();
                textBox.Width = fpanelButtonID.Width - 5;
                textBox.Enabled = false;
                fpanelButtonID.Controls.Add(textBox);
            }

            for (int i = 0; i < _buttonCount; i++)
            {
                /* create textbox for button press event */
                TextBox textbox = new TextBox();
                textbox.Tag = i;
                textbox.Width = fpanelButtonPress.Width - 10;
                textboxButtonPressList.Add(textbox);
                fpanelButtonPress.Controls.Add(textbox);
            }

            for (int i = 0; i < _buttonCount; i++)
            {
                /* create textbox for button release event */
                TextBox textbox = new TextBox();
                textbox.Tag = i;
                textbox.Width = fpanelButtonPress.Width - 10;
                textboxButtonReleaseList.Add(textbox);
                fpanelButtonRelease.Controls.Add(textbox);
            }
        }
    }
}
