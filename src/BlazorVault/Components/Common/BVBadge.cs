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

		/// <summary>
		/// Renders the badge with rounded edges.
		/// </summary>
		[Parameter]
		public bool Pill { get; set; }

		protected override string VariantClass
		{
			get
			{
				return string.Format(Modifiers.Elements.BadgeGeneric, VariantClass);
			}
		}

		protected override bool Simple => true;


		protected override void GetClassString(CssBuilder builder)
		{
			builder
				.Add(Modifiers.Elements.BadgePill, this.Pill);
		}
	}
}
