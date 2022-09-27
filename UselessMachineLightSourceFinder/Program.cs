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
		static private double[] sensorBaselineValues = new double[] { 74.00, 62.00, 77.00, 42.00, 59.00, 69.00 };
		static private Queue<SensorReading> readingHistory = new Queue<SensorReading>();
		static private bool hasCalibrated = false;
		static void Main(string[] args)
		{
			hasCalibrated = false;

			// Step1: open port
			var serialIO = new SerialIO();
			serialIO.OpenSerialPort(9800, SensorDataHandler);

			// Step2: calibrate
			Console.WriteLine("calibrating... press key when done");
			Console.ReadKey();
			SetBaselineFromHistory();
			hasCalibrated = true;
			Console.WriteLine("done calibrating");






			Console.ReadKey();
			serialIO.CloseSerialPort();
		}

		private static void SetBaselineFromHistory()
		{
			// Step1: init all entries to 0
			double[] baseline = new double[NUM_OF_SENSOR];
			for (int i = 0; i < sr.NumOfSensors; i++)
			{
				baseline[i] = 0;
			}

			// Step2: add up all histories for each entry
			foreach (SensorReading sr in readingHistory)
			{
				for (int i = 0; i < sr.NumOfSensors; i++)
				{
					baseline[i] += sr.ReadingOfEachSensor[i];
				}
			}

			// Step3: divide each entry by number of history added
			for (int i = 0; i < sr.NumOfSensors; i++)
			{
				baseline[i] = baseline[i] / readingHistory.Count;
			}

			sensorBaselineValues = baseline;
		}

		private static void SensorDataHandler(object sender, String data)
		{
			serialBuffer.Append(data);
			List<SensorReading> readings = SensorReading.ProcessSensorData(serialBuffer.ToString(), NUM_OF_SENSOR);

			if (readings.Count > 0)
			{
				//there are enough data for at least one complete reading
				var reading = readings.Last();
				readingHistory.Enqueue(reading);

				if (hasCalibrated)
				{
					Console.Write("Prediction: ");
					var location = LightSourceLocator.FindLightSourceLocationGivenSensorReadings(reading, sensorBaselineValues);
					Console.WriteLine(location.ToString());

					_ = readingHistory.Dequeue(); // dequeue after calibration to keep its size constant
				}
							
				serialBuffer.Clear();
			}
		}
	}
}
