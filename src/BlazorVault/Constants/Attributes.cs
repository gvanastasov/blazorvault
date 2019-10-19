namespace BlazorVault.Constants
{
	internal static class Attributes
	{
		internal const string Class = "class";

		internal const string Role = "role";

		internal const string Href = "href";

		internal const string Type = "type";

		internal const string Aria = "aria";

		internal const string TabIndex = "tabindex";

		internal const string Hidden = "hidden";

		internal static string AriaHidden
		{
			get
			{
				return string.Concat(Aria, Modifiers.Separator, Hidden);
			}
		}

		internal static string AriaLabel
		{
			get
			{
				return string.Concat(
					Aria, Modifiers.Separator, Modifiers.Common.Label);
			}
		}

		internal static string AriaCurrent
		{
			get
			{
				return string.Concat(
					Aria, Modifiers.Separator, Modifiers.Common.Current);
			}
		}

		internal static string AriaDisabled
		{
			get
			{
				return string.Concat(
					Aria, Modifiers.Separator, Modifiers.Common.Disabled);
			}
		}
	}
}
