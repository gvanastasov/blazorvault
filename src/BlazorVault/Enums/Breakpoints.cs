using System.ComponentModel;

namespace BlazorVault
{
	public enum Breakpoints
	{
		[Description("sm")]
		Small,

		[Description("md")]
		Medium,

		[Description("lg")]
		Large,

		[Description("xl")]
		Extra,
	}
}
