using BlazorVault.Components;
using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault
{
	public sealed class BVLink : BVContentComponent
	{
		[Parameter]
		public string To { get; set; } = "#";

		protected override bool Simple => true;

		protected override string DefaultTag => MarkupElements.Anchor;

		protected override void AddAttributes(RenderTreeBuilder builder, ref int sequence)
		{
			base.AddAttributes(builder, ref sequence);

			builder.AddAttribute(sequence++, "href", this.To);
		}
	}
}
