using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UselessMachineLightSourceFinder
{
	public class SerialIO
	{
		public delegate void SensorDataHandler(object sender, String e);
		private SensorDataHandler sdh;
		private SerialPort sp;

		public void OpenSerialPort(int baudRate, SensorDataHandler sensorDataHandler) {
			this.sdh = sensorDataHandler;

			sp = new SerialPort("COM3");

			sp.BaudRate = baudRate;
			sp.Parity = Parity.None;
			sp.StopBits = StopBits.One;
			sp.DataBits = 8;
			sp.Handshake = Handshake.None;

			sp.DataReceived += new SerialDataReceivedEventHandler(SensorDataReceivedHandler);

			sp.Open();
		}

		public void CloseSerialPort()
		{
			if (sp != null)
			{
				sp.Close();
			}
		}

		private void SensorDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
		{
			SerialPort sp = (SerialPort)sender;
			string indata = sp.ReadExisting();

			this.sdh(this, indata);
		}
	}
}
