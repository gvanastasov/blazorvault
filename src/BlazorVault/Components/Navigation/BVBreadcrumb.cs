using BlazorVault.Components;
using BlazorVault.Constants;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault
{
	public sealed class BVBreadcrumb : BVContentComponent
	{
		protected override string DefaultTag
		{
			get
			{
				return MarkupElements.Nav;
			}
		}

		protected override string ClassBase
		{
			get
			{
				return Modifiers.Elements.Breadcrumb;
			}
		}

		protected override bool Simple => false;

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			base.BuildRenderTree(builder);

			var sequence = 0;
			builder.OpenElement(sequence, DefaultTag);
			builder.AddAttribute(sequence++, Attributes.AriaLabel, "breadcrumb");
			{
				builder.OpenElement(sequence++, MarkupElements.OrderedList);
				builder.AddAttribute(sequence++, Attributes.Class, GetClassString());
				builder.AddContent(sequence++, ChildContent);
				builder.CloseElement();
			}
			builder.CloseElement();
		}
	}
}
