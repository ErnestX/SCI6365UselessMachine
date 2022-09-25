using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UselessMachineLightSourceFinder
{
	class Program
	{
		static private int NUM_OF_SENSOR = 6;
		static private StringBuilder serialBuffer = new StringBuilder(100, 1000);
		static void Main(string[] args)
		{
			// Step1: open port
			var serialIO = new SerialIO();
			serialIO.OpenSerialPort(9800, SensorDataHandler);


			Console.ReadKey();
			serialIO.CloseSerialPort();
		}

		private static void SensorDataHandler(object sender, String data)
		{
			serialBuffer.Append(data);
			List<SensorReading> readings = SensorReading.ProcessSensorData(serialBuffer.ToString(), NUM_OF_SENSOR);
			if (readings.Count > 0)
			{
				//there are enough data for at least one complete reading
				var reading = readings.Last();
				Console.Write("Parsed: ");
				foreach (int r in reading.ReadingOfEachSensor)
				{
					Console.Write(r.ToString() + ", ");
				}
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				Console.WriteLine("");
							
				serialBuffer.Clear();
			}
		}
	}
}
