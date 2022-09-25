using System;
using System.Collections.Generic;
using System.Linq;

namespace UselessMachineLightSourceFinder
{
	/// <summary>
	/// Represents readings of each light sensor at a single moment in time
	/// </summary>
	public struct SensorReading
	{
		public SensorReading(List<int> readingOfEachSensor)
		{
			this.ReadingOfEachSensor = new List<int>(readingOfEachSensor); // make a copy of the list
		}

		public int NumOfSensors => this.ReadingOfEachSensor.Count;
		public List<int> ReadingOfEachSensor { get; }

		/// <summary>
		/// Read the serial data sent from Arduino in predefined format
		/// </summary>
		/// <param name="rawSerialDataForReadings"> The serial data, which may be cut off in the middle </param>
		/// <param name="numberOfSensors"> The number of sensor data each reading should have </param>
		/// <returns> the list of readings parsed from the string, with corrupted readings discarded </returns>
		public static List<SensorReading> ProcessSensorData(String rawSerialDataForReadings, int numberOfSensors)
		{
			// Step1: split at new lines to get each set of readings at a certain moment
			List<String> readingSets = new List<String>(rawSerialDataForReadings.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
			if (readingSets.Last() != "")
			{
				readingSets.RemoveAt(readingSets.Count - 1); // not having an empty string at the end means the data doesn't end with a new line, which means the last line is not finished. Remove it. 
			}
			List<SensorReading> newSensorReadings = new List<SensorReading>();
			foreach (String readingSet in readingSets)
			{
				// Step2: split at spaces to get each reading in a set
				bool success = true;
				List<String> readings = new List<String>(readingSet.Split(null));

				var readingsInInteger = new List<int>();
				for (int i = 0; i < readings.Count; i++)
				{
					var reading = readings[i];
					if (reading == "")
					{
						continue; // ignore empty string
					}

					int readingInInteger;
					bool s = Int32.TryParse(reading, out readingInInteger);
					success = success && s;
					readingsInInteger.Add(readingInInteger);
				}

				if (success && readingsInInteger.Count == numberOfSensors)
				{
					var newSensorReading = new SensorReading(readingsInInteger);
					newSensorReadings.Add(newSensorReading);
				}
				// if doesn't satisfy the check, this line of readings is corrupted. data discarded
			}
			return newSensorReadings;
		}
	}
}
