using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UselessMachineLightSourceFinder
{
	class LightSourceLocator
	{
		private int[] sensor_x_coordinates;
		private int[] sensor_y_coordinates;
		private int[] sensor_z_coordinates;

		private double[] sensor_x_weight;
		private double[] sensor_y_weight => sensor_x_weight;
		private double[] sensor_z_weight;

		public static LightSourceLocation FindLightSourceLocationGivenSensorReadings(SensorReading sensorReading)
		{
			throw new NotImplementedException();
		}
	}
}
