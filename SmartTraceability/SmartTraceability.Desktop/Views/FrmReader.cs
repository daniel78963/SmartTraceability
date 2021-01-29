using SmartTraceability.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartTraceability.Desktop.Views
{
    public partial class FrmReader : Form
    { 
        private ReadTask readtask;
        //private UnitOfWork unitOfWork = new UnitOfWork();
        //private ApiService apiService; 

        public FrmReader()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //if (cbPorts.SelectedItem != null)
            //{
            //    if (readtask != null && readtask.IsOpen())
            //    {
            //        toolStripStatusLabel1.Text = "The port is already open and reading";
            //    }
            //    else
            //    {
            //        readtask = new ReadTask(9600);
            //        readtask.Callback3 += CallbackChangeText;
            //        readtask.Start();
            //        pcbReading.IconColor = Color.FromArgb(0, 204, 68);
            //        toolStripStatusLabel1.Text = "Reading...";
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Select port", "Smart Traceability", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    toolStripStatusLabel1.Text = "First select the port to start reading";
            //}
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (readtask != null)
            {
                readtask.Stop();
                txtRead.AppendText("Reading stopped");
                toolStripStatusLabel1.Text = "Reading stopped";
            }
            pcbReading.IconColor = Color.Gray;
        }
    }
}
