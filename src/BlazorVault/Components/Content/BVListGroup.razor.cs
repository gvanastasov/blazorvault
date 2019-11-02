using BlazorVault.Constants;
using BlazorVault.Extensions;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;

namespace BlazorVault.Components.Content
{
	public class BVListGroupBase : BVContentComponent
	{
		[Parameter]
		public bool Actions { get; set; }

		/// <summary>
		/// Enable this to remove the borders and the rounded corners.
		/// </summary>
		[Parameter]
		public bool Flush { get; set; }

		/// <summary>
		/// Changes the layout from vertical to horizontal across all 
		/// breakpoints.
		/// </summary>
		[Parameter]
		public bool Horizontal { get; set; }

		[Parameter]
		public Breakpoints? Breakpoint { get; set; }

		protected override bool Simple => false;

		protected override string ClassBase => Modifiers.Elements.ListGroup;

		protected override string DefaultTag
		{
			get
			{
				return this.Actions
					? MarkupElements.Div
					: MarkupElements.UnorderedList;
			}
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder.Add(Modifiers.Elements.ListGroupFlush, this.Flush);

			var horizontalClass = Modifiers.Elements.ListGroupHorizontal;

			if (Breakpoint.HasValue)
			{
				horizontalClass = string.Concat(horizontalClass, Modifiers.Separator, this.Breakpoint.Description());
			}

			builder.Add(horizontalClass, this.Horizontal);
		}
	}
}
