using BlazorVault.Components;
using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault
{
	public sealed class BVCode : BVContentComponent
	{
		[Parameter]
		public bool SingleLine { get; set; }

		[Parameter]
		public bool Scrollable { get; set; }

		protected override bool Simple => false;

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			base.BuildRenderTree(builder);

			var sequence = 0;

			if (!SingleLine)
			{
				builder.OpenElement(sequence++, MarkupElements.Pre);
			}

			builder.OpenElement(sequence++, MarkupElements.Code);

			if (Scrollable)
			{
				var scrollableClass = string.Format(Modifiers.Layouts.ScrollableCode, Scrollable);
				builder.AddAttribute(sequence++, Attributes.Class, scrollableClass);
			}

			builder.AddContent(sequence, ChildContent);
			builder.CloseElement();

			if (!SingleLine)
			{
				builder.CloseElement();
			}
		}
	}
}
