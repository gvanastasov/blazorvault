using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVBadge : BVStyleComponent
	{
		protected override string DefaultTag
		{
			get
			{
				return MarkupElements.Span;
			}
		}

		protected override string ClassBase
		{
			get
			{
				return Modifiers.Elements.Badge;
			}
		}

		protected override Style? DefaultStyle => BlazorVault.Style.Primary;

		/// <summary>
		/// Renders the badge with rounded edges.
		/// </summary>
		[Parameter]
		public bool Pill { get; set; }

		protected override bool Simple => true;
	}
}
