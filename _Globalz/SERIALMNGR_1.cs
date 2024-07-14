using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LiteCanSimProj._Globalz
{
    public class SERIALMNGR_1
    {
        private static SERIALMNGR_1 _instance = null;
        private SerialPort _serialPort;
        public static SERIALMNGR_1 Instance => _instance ?? (_instance = new SERIALMNGR_1());

        public event Action<string, bool> aPortHasOpened_orCloesdEVENT;
        public event Action<string> DataReceived;

        private SERIALMNGR_1()
        {
            _serialPort = new SerialPort
            {
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };

            _serialPort.DataReceived += SerialPort_DataReceived;
        }
        public string[] GetAvailablePortNames()
        {
            return System.IO.Ports.SerialPort.GetPortNames();
        }
        public void OpenPort(string portName, int baudRate)
        {
            if (_serialPort.IsOpen)
            {
                ClosePort();
            }

            _serialPort.PortName = portName;
            _serialPort.BaudRate = baudRate;
            _serialPort.Open();
            aPortHasOpened_orCloesdEVENT?.Invoke(portName, true);
        }
        public void OpenPort(string portName, int baudRate, Handshake handshake, bool rtsEnable)
        {
            if (_serialPort.IsOpen)
            {
                ClosePort();
            }


            _serialPort.PortName = portName;
            _serialPort.BaudRate = baudRate;
            _serialPort.Handshake = handshake;
            _serialPort.RtsEnable = rtsEnable;
            _serialPort.Open();
            aPortHasOpened_orCloesdEVENT?.Invoke(portName, true);
        }

        public void ClosePort()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                aPortHasOpened_orCloesdEVENT?.Invoke(_serialPort.PortName, false);
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = _serialPort.ReadExisting();
            // Handle incoming data here
            DataReceived?.Invoke(data);
        }

        public void RegisterDataReceivedHandler(Action<string> handler)
        {
            DataReceived += handler;
        }

        public void UnregisterDataReceivedHandler(Action<string> handler)
        {
            DataReceived -= handler;
        }
        public void RegisterPortOpenedClosedHandler(Action<string, bool> handler)
        {
            aPortHasOpened_orCloesdEVENT += handler;
        }

        public void UnregisterPortOpenedClosedHandler(Action<string, bool> handler)
        {
            aPortHasOpened_orCloesdEVENT -= handler;
        }
        public void SendMessage(string argstrmessage)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Write(argstrmessage);
            }
            else
            {
                Debug.Print("Serial port is NOT open.!!!!!");
            }
        }


        public SerialPort GetActivatedPort() {
            return this._serialPort;
        }
    }
}
