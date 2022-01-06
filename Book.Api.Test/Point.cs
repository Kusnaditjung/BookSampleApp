using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Api.Test
{
	internal class Point : IEquatable<Point>
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Point(int x, int y)
		{
			X = x; Y = y; 
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Point);
		}

		public bool Equals(Point other)
		{
			if (other == null)
			{
				return false;
			}

			if (Point.ReferenceEquals(this, other))
			{
				return true;
			}

			if (other.GetType() != this.GetType())
			{
				return false;
			}


			return X == other.X && Y == other.Y;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}

		public static bool operator ==(Point lh, Point rh)
		{
			if (lh == null)
			{
				if (rh == null)
				{
					return true;
				}

				return false;
			}

			return lh.Equals(rh);
		}

		public static bool operator !=(Point lh, Point rh)
		{
			return !(lh == rh);
		}
	}
}
