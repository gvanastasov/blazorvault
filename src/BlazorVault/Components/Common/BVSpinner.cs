using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault
{
	public sealed class BVSpinner : BVComponentBase
	{
		protected override bool Simple => true;

		protected override string ClassBase => "spinner-border";

		[Parameter]
		public Style? Style { get; set; }

		protected override void RenderInnerHtml(RenderTreeBuilder builder, ref int sequence)
		{
			builder.OpenElement(sequence++, MarkupElements.Span);
			builder.AddAttribute(sequence++, Attributes.Class, "sr-only");
			builder.AddContent(sequence++, "Loading...");
			builder.CloseElement();
		}

		protected override void AddAttributes(RenderTreeBuilder builder, ref int sequence)
		{
			base.AddAttributes(builder, ref sequence);
			builder.AddAttribute(sequence++, Attributes.Role, "status");
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder.Add($"text-{Style.ToString().ToLower()}", Style.HasValue);
		}
	}
}
