using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UselessMachineLightSourceFinder
{
	class Program
	{
		private int NUM_OF_SENSOR = 6;
		static private StringBuilder trainingDataBuilder = new StringBuilder(100, 1000);
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
			Console.Write(data);

			trainingDataBuilder.Append(data);
			//TrainingData dataSample = TrainingData.ProcessTrainingData(trainingDataBuilder.ToString(), NUM_OF_SENSOR, new LightSourceLocation(0, 0, 0));
			//if (dataSample.SensorReadings.Count > 0)
			//{
			// there are enough data for one sample

			//}
		}
	}
}
