using SmartTraceability.Model.Data.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SmartTraceability.Desktop.Services
{
    class ReadTask
    {
        static bool _continue;
        static SerialPort _serialPort;
        private string message;
        static bool _saveInDatabase;

        // Bandera booleana que indica cuando el proceso está siendo ejecutado o ha sido detenido
        private bool ReadTaskResponse;

        // Expone el contexto de sincronización en la clase entera 
        private readonly SynchronizationContext SyncContext;

        // Crear los 2 contenedores de callbacks
        //public event EventHandler<HeavyTaskResponse> Callback1;
        //public event EventHandler<HeavyTaskResponse> Callback2;
        public event EventHandler<ReadTaskResponse> Callback3;

        // Constructor de la clase HeavyTask
        //public ReadTask(int portBaudRate)
        public ReadTask(SerialPort _sp)        
        {
            _serialPort = _sp;
            // Importante actualizar el valor de SyncContext en el constructor con
            // el valor de SynchronizationContext del AsyncOperationManager
            SyncContext = AsyncOperationManager.SynchronizationContext;

            //fileName1 = Properties.Settings.Default.Ruta;

            //COMENTADO
            //Settings.Default.PortName = "COM3";
            //Settings.Default.BaudRate = portBaudRate.ToString();
            ////Settings.Default.Parity = "COM3";
            //Settings.Default.DataBits = 8.ToString();
            ////Settings.Default.StopBits = "COM3";
            ////Settings.Default.Handshake = "COM3";
            //// Save settings
            //Settings.Default.Save();

            string name;
            string message;
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            ////Thread readThread = new Thread(Read);

            //// Create a new SerialPort object with default settings.
            //_serialPort = new SerialPort();

            //// Allow the user to set the appropriate properties.
            //_serialPort.PortName = "COM4";
            ////_serialPort.BaudRate = 9600;
            //_serialPort.BaudRate = portBaudRate;

            //_serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None", true);
            //_serialPort.DataBits = 8;
            //_serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One", true);
            //_serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None", true);

            //// Set the read/write timeouts
            //_serialPort.ReadTimeout = 500;
            //_serialPort.WriteTimeout = 500;

            _serialPort.Open();
        }

        //public int SetPortBaudRate()
        //{
        //    string cadena = "9600"; 
        //    return int.Parse(cadena);
        //}

        // Método para iniciar el proceso
        public void Start()
        {
            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }

        // Método para detener el proceso
        public void Stop()
        {
            ReadTaskResponse = true;
            _serialPort.Close();
        }

        public bool IsOpen()
        {
            if (_serialPort != null)
            {
                return _serialPort.IsOpen;
            }
            else
            {
                return false;
            }

        }

        // Método donde la lógica principal de tu tarea se ejecuta
        private void Run()
        {
            while (!ReadTaskResponse)
            {
                if (_serialPort.IsOpen)
                {
                    //// En nuestro ejemplo solo esperaremos 2 segundos y eso es todo
                    //// En tu clase obviamente se ejecutará la tarea pesada
                    //Thread.Sleep(2000);

                    //// Ejecuta el primer callback desde el proceso de fondo al hilo principal (el de la interfaz gráfica)
                    //// El primer callback activa el primer boton !
                    //SyncContext.Post(e => triggerCallback1(
                    //    new HeavyTaskResponse("Algo de información de prueba")
                    //), null);

                    //// Esperar otros 2 segundos para más tareas pesadas.
                    //Thread.Sleep(2000);

                    //// Ejecutar segundo callback desde el segundo proceso al primero
                    //SyncContext.Post(e => triggerCallback2(
                    //    new HeavyTaskResponse("Más información")
                    //), null);

                    try
                    {
                        message = _serialPort.ReadLine();
                        // Ejecutar segundo callback desde el segundo proceso al primero
                        SyncContext.Post(e => triggerCallback3(
                            new ReadTaskResponse(message)
                        ), null);
                    }
                    catch (TimeoutException) { }
                    catch (IOException)
                    {
                        int p = 0;
                    }

                    //// La tarea heavy task finaliza, así que hay que detenerla.
                    //Stop();
                }
                else
                {
                    ReadTaskResponse = true;
                    SyncContext.Post(e => triggerCallback3(
                     new ReadTaskResponse("Closed Port")
                 ), null);
                }
            }
        }

        //// Métodos que ejecutan los callback si y solo si fueron declarados durante la instanciación de la clase HeavyTask
        //private void triggerCallback1(HeavyTaskResponse response)
        //{
        //    // Si el primer callback existe, ejecutarlo con la información dada
        //    Callback1?.Invoke(this, response);
        //}

        //private void triggerCallback2(HeavyTaskResponse response)
        //{
        //    // Si el segundo callback existe, ejecutarlo con la información dada
        //    Callback2?.Invoke(this, response);
        //}

        private void triggerCallback3(ReadTaskResponse response)
        {
            // Si el segundo callback existe, ejecutarlo con la información dada
            Callback3?.Invoke(this, response);
        }
    }
}

