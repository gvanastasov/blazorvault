namespace BlazorVault.Constants
{
	internal static class MarkupElements
	{
		internal const string Image = "img";

		internal const string Anchor = "a";

		internal const string HeadingGeneric = "h{0}";

		internal const string Span = "span";

		internal const string Paragraph = "p";

		internal const string Pre = "pre";

		internal const string Code = "code";

		internal const string Div = "div";

		internal const string OrderedList = "ol";

		internal const string UnorderedList = "ul";

		internal const string ListItem = "li";

		internal const string Nav = "nav";

		internal const string Button = "button";

		internal static string Header1
		{
			get
			{
				return string.Format(HeadingGeneric, 1);
			}
		}

		internal static string Header2
		{
			get
			{
				return string.Format(HeadingGeneric, 2);
			}
		}

		internal static string Header3
		{
			get
			{
				return string.Format(HeadingGeneric, 3);
			}
		}

		internal static string Header4
		{
			get
			{
				return string.Format(HeadingGeneric, 4);
			}
		}

		internal static string Header5
		{
			get
			{
				return string.Format(HeadingGeneric, 5);
			}
		}

		internal static string Header6
		{
			get
			{
				return string.Format(HeadingGeneric, 6);
			}
		}
	}
}
