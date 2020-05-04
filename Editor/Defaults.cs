using UnityEngine;

namespace TeoDiaz.LevelGrid
{
	static class Defaults
	{
		public static readonly Color GridColorX = new Color(.9f, .46f, .46f, .5f);
		public static readonly Color GridColorY = new Color(.46f, .9f, .46f, .5f);
		public static readonly Color GridColorZ = new Color(.46f, .46f, .9f, .5f);

		public const int DefaultSnapMultiplier = 2048;
		public const float SnapValue = 1f;
		public const bool ShowGrid = true;
		public const bool SnapOnScale = true;
		public const bool SnapAsGroup = true;

		public const float Meter = 1f;
		public const float Centimeter = .01f;
		public const float Millimeter = .001f;
		public const float Inch = 0.0253999862840074f;
		public const float Foot = 0.3048f;
		public const float Yard = 1.09361f;
		public const float Parsec = 5f;
	}
}
