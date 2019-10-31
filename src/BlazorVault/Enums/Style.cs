using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorVault
{
	public enum Style
	{
		Primary,

		Secondary,

		Success,

		Danger,

		Warning,

		Info,

		Light,

		Dark,
	}

	public static class Styles
	{
		public static IEnumerable<Style> Collection()
		{
			return Enum
				.GetValues(typeof(Style))
				.Cast<Style>();
		}
	}
}
