﻿using System;
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

        private const int numberOfButtons = 16;

        public Form1()
        {
            InitializeComponent();
            panelButton.Visible = false;    // hide button options initially
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSerialPorts.DataSource = Arduino.getComPorts();

            textboxButtonPressList.Add(txtButtonPress1);
            textboxButtonPressList.Add(txtButtonPress2);
            textboxButtonPressList.Add(txtButtonPress3);
            /* 
             * 
             * Continue this for all text fields for button presses
             * 
             */

            textboxButtonReleaseList.Add(txtButtonRelease1);
            textboxButtonReleaseList.Add(txtButtonRelease2);
            textboxButtonReleaseList.Add(txtButtonRelease3);
            /* 
             * 
             * Continue this for all text fields for button presses
             * 
             */
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
                        panelButton.Visible = true;    // hide button options initially
                        labelConnectionStatus.Text = "Status: Connected";
                        Thread.Sleep(500);
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
    }
}
