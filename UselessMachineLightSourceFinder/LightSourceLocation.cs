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
		public LightSourceLocation(float x, float y, float z)
		{
			if (z < 0.0)
			{
				throw new ArgumentException("z is smaller than zero");
			}
			this.X_cm = x;
			this.Y_cm = y;
			this.Z_cm = z;
		}

		/// <summary>
		/// the x coordinate in the physical world, with 0.0 at the centre of the model 
		/// </summary>
		public float X_cm { get; set; }
		/// <summary>
		///  the y coordinate in the physical world, with 0.0 at the centre of the model 
		/// </summary>
		public float Y_cm { get; set; }
		/// <summary>
		///  the z coordinate in the physical world, with 0.0 at the base of the model; must be non-negative
		/// </summary>
		public float Z_cm { get; set; }
	}
}
