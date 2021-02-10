using SmartTraceability.Desktop.Services;
using SmartTraceability.Model.Data.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO.Ports;

namespace SmartTraceability.Desktop.Views
{
    public partial class FrmReader : Form
    {
        private ReadTask readtask;
        //private UnitOfWork unitOfWork = new UnitOfWork();
        //private ApiService apiService; 
        private static SerialPort _serialPort;

        public FrmReader()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = string.Empty;
            //apiService = new ApiService();

            if (System.IO.Ports.SerialPort.GetPortNames().Any())
            {
                //Add Ports to Combo
                foreach (string cadena in (System.IO.Ports.SerialPort.GetPortNames()))
                {
                    cbPorts.Items.Add(cadena);
                }

                cbPorts.SelectedIndex = 0;
            }

            //readtask = new ReadTask(9600);
            //readtask.Callback3 += CallbackChangeText;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (cbPorts.SelectedItem != null)
            {
                if (readtask != null && readtask.IsOpen())
                {
                    toolStripStatusLabel1.Text = "The port is already open and reading";
                }
                else
                {
                    //readtask = new ReadTask(9600);
                    SetSerialPort();
                    readtask = new ReadTask(_serialPort);
                    readtask.Callback3 += CallbackChangeText;
                    readtask.Start();
                    pcbReading.IconColor = Color.FromArgb(0, 204, 68);
                    toolStripStatusLabel1.Text = "Reading...";
                }
            }
            else
            {
                MessageBox.Show("Select port", "Smart Traceability", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripStatusLabel1.Text = "First select the port to start reading";
            }
        }

        private SerialPort SetSerialPort()
        {
            // Create a new SerialPort object with default settings.
            _serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            _serialPort.PortName = "COM4";
            _serialPort.BaudRate = 9600;

            _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None", true);
            _serialPort.DataBits = 8;
            _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One", true);
            _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None", true);

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            return _serialPort;
        }

        private void CallbackChangeText(object sender, ReadTaskResponse responseTask)
        {
            // Acceder al label desde el hilo principal  
            //Console.WriteLine(response.Message); 
            txtRead.AppendText(responseTask.Message);
            txtRead.AppendText(Environment.NewLine);

            List<string> data = responseTask.Message.Split(',').ToList<string>();

            string[] words = responseTask.Message.Split(',');

            // Smart Traceability
            // Posicion: 02
            // Fecha:
            // MetodoEsterilizacion: Vapor
            // Temperatura: 56 C
            // RESULTADO POSITIVO
            // Hora Inicial 11:37
            // Hora Final 11:52

            //Dictionary<string, string> dataReaded = new Dictionary<string, string>();

            //foreach (var word in words)
            //{
            //    txtRead.AppendText(word);
            //    txtRead.AppendText(Environment.NewLine);

            //    string state = "";
            //    string serial = "";
            //    string active = "";
            //    string timeBegin = "";
            //    string timeEnd = "";
            //    string userName = "";
            //    string incubator = "";
            //    //string estado = "";
            //    dataReaded.Add("state", word);
            ////1:state
            ////2:userName
            ////3:incubator
            ////4:timeBegin
            ////5:timeEnd 
            //}

            Dictionary<int, string> dic = new Dictionary<int, string>();
            int i = 0;

            foreach (var word in words)
            {
                i++;
                //txtRead.AppendText(word);
                //txtRead.AppendText(Environment.NewLine);

                dic.Add(i, word);
                //1:state
                //2:userName
                //3:incubator
                //4:timeBegin
                //5:timeEnd  
            }

            ////Save if data is complete
            //if (i >= 5)
            //{
            //    Entry entry = new Entry();
            //    entry.DataReaded = responseTask.Message;
            //    entry.Date = DateTime.Now;
            //    //entry.SerialCode = dic[3];
            //    entry.SerialCode = "20200202185";
            //    entry.State = dic[1];
            //    //entry.UserName = dic[2];
            //    entry.UserName = "daniel78963@hotmail.com";
            //    entry.Incubator = dic[3];
            //    entry.TimeBegin = dic[4];
            //    entry.TimeEnd = dic[5];
            //    entry.Synchronized = false;

            //    entry.UserId = 1;
            //    entry.IncubatorId = 1;

            //    ///TODO: save only if data is valid  
            //    if (this.chkSaveInDB.Checked)
            //    {
            //        if (entry.State == Enumerations.StateRead.Positivo.ToString()
            //            || entry.State == Enumerations.StateRead.Negativo.ToString())
            //        {
            //            unitOfWork.EntryRepository.Insert(entry);
            //            unitOfWork.Save();
            //            txtRead.AppendText("Save data in db...");
            //        }
            //    }

            //    //SERVICE
            //    //EntryDto entryDto = EntryToEntryAPI(entry);
            //    //SaveEntryAPI(entryDto);

            txtRead.AppendText(Environment.NewLine);
            //}
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (readtask != null)
            {
                readtask.Stop();
                txtRead.AppendText("Reading stopped");
                txtRead.AppendText(Environment.NewLine);
                toolStripStatusLabel1.Text = "Reading stopped";
            }
            pcbReading.IconColor = Color.Gray;
        }
    }
}
