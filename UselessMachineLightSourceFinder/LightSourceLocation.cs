using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UselessMachineLightSourceFinder
{
	/// <summary>
	/// The location of the light source in the physical world
	/// </summary>
	public struct LightSourceLocation
	{
		public LightSourceLocation(double x, double y, double z)
		{
			this.X_cm = x;
			this.Y_cm = y;
			this.Z_cm = z;
		}

		override public String ToString()
		{
			return String.Format("X: {0:0.00} Y: {1:0.00} Z: {2:0.00}", this.X_cm, this.Y_cm, this.Z_cm);
		}

		/// <summary>
		/// the x coordinate in the physical world, with 0.0 at the centre of the model 
		/// </summary>
		public double X_cm { get; set; }
		/// <summary>
		///  the y coordinate in the physical world, with 0.0 at the centre of the model 
		/// </summary>
		public double Y_cm { get; set; }
		/// <summary>
		///  the z coordinate in the physical world, with 0.0 at the base of the model; must be non-negative
		/// </summary>
		public double Z_cm { get; set; }
	}
}
