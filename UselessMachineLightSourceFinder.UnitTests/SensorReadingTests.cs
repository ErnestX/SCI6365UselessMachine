using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UselessMachineLightSourceFinder.UnitTests
{
	[TestClass]
	public class SensorReadingTests
	{
		[TestMethod]
		public void TestParsingData_OneLine_CorrectOutputs()
		{
			var testString = "11 22 33 \n".Replace("\n", Environment.NewLine);
			var sensorData = SensorReading.ProcessSensorData(testString, 3);
			Assert.AreEqual(1, sensorData.Count);
			Assert.AreEqual(3, sensorData[0].NumOfSensors);
			Assert.AreEqual(11, sensorData[0].ReadingOfEachSensor[0]);
			Assert.AreEqual(22, sensorData[0].ReadingOfEachSensor[1]);
			Assert.AreEqual(33, sensorData[0].ReadingOfEachSensor[2]);
		}

		[TestMethod]
		public void TestParsingData_ThreeLines_CorrectOutputs()
		{
			var testString = "11 22 33 \n 12 23 34 \n 55 66 77 \n".Replace("\n", Environment.NewLine);
			var sensorData = SensorReading.ProcessSensorData(testString, 3);
			Assert.AreEqual(3, sensorData.Count);
			Assert.AreEqual(3, sensorData[0].NumOfSensors);

			Assert.AreEqual(11, sensorData[0].ReadingOfEachSensor[0]);
			Assert.AreEqual(22, sensorData[0].ReadingOfEachSensor[1]);
			Assert.AreEqual(33, sensorData[0].ReadingOfEachSensor[2]);

			Assert.AreEqual(12, sensorData[1].ReadingOfEachSensor[0]);
			Assert.AreEqual(23, sensorData[1].ReadingOfEachSensor[1]);
			Assert.AreEqual(34, sensorData[1].ReadingOfEachSensor[2]);

			Assert.AreEqual(55, sensorData[2].ReadingOfEachSensor[0]);
			Assert.AreEqual(66, sensorData[2].ReadingOfEachSensor[1]);
			Assert.AreEqual(77, sensorData[2].ReadingOfEachSensor[2]);
		}

		[TestMethod]
		public void TestParsingData_OneLineWithCorruptedData_EmptyOutput_1()
		{
			var testString = "11 Q2 33 \n".Replace("\n", Environment.NewLine);
			var sensorData = SensorReading.ProcessSensorData(testString, 3);
			Assert.AreEqual(0, sensorData.Count);
		}

		[TestMethod]
		public void TestParsingData_OneLineWithCorruptedData_EmptyOutput_2()
		{
			var testString = "11 22 Q2 33 \n".Replace("\n", Environment.NewLine);
			var sensorData = SensorReading.ProcessSensorData(testString, 3);
			Assert.AreEqual(0, sensorData.Count);
		}

		[TestMethod]
		public void TestParsingData_OneLineWithMoreReadingsThanExpected_DiscardLine()
		{
			var testString = "11 22 33 44 \n 12 23 34 \n".Replace("\n", Environment.NewLine);
			var sensorData = SensorReading.ProcessSensorData(testString, 3);
			Assert.AreEqual(1, sensorData.Count);
			Assert.AreEqual(3, sensorData[0].NumOfSensors);

			Assert.AreEqual(12, sensorData[0].ReadingOfEachSensor[0]);
			Assert.AreEqual(23, sensorData[0].ReadingOfEachSensor[1]);
			Assert.AreEqual(34, sensorData[0].ReadingOfEachSensor[2]);
		}

		[TestMethod]
		public void TestParsingData_NoNewLineEnding_DiscardLastLine()
		{
			var testString = "11 22 33 \n 12 23 34 \n 55 66 7".Replace("\n", Environment.NewLine);
			var sensorData = SensorReading.ProcessSensorData(testString, 3);
			Assert.AreEqual(2, sensorData.Count);
			Assert.AreEqual(3, sensorData[0].NumOfSensors);

			Assert.AreEqual(11, sensorData[0].ReadingOfEachSensor[0]);
			Assert.AreEqual(22, sensorData[0].ReadingOfEachSensor[1]);
			Assert.AreEqual(33, sensorData[0].ReadingOfEachSensor[2]);

			Assert.AreEqual(12, sensorData[1].ReadingOfEachSensor[0]);
			Assert.AreEqual(23, sensorData[1].ReadingOfEachSensor[1]);
			Assert.AreEqual(34, sensorData[1].ReadingOfEachSensor[2]);
		}
	}
}

