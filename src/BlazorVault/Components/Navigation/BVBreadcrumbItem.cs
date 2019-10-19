using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault
{
	public sealed class BVBreadcrumbItem : BVContentComponent
	{
		protected override string DefaultTag
		{
			get
			{
				return MarkupElements.ListItem;
			}
		}

		protected override string ClassBase
		{
			get
			{
				return Modifiers.Elements.BreadcrumbItem;
			}
		}

		[Parameter]
		public bool Active { get; set; }

		[Parameter]
		public string Href { get; set; } = "#";

		protected override bool Simple => false;

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			base.BuildRenderTree(builder);

			var sequence = 0;
			builder.OpenElement(sequence, this.DefaultTag);
			builder.AddAttribute(sequence++, Attributes.Class, GetClassString());
			{
				if (!this.Active)
				{
					builder.OpenElement(sequence++, MarkupElements.Anchor);
					{
						builder.AddAttribute(sequence++, Attributes.Href, this.Href);
						builder.AddContent(sequence++, this.ChildContent);
					}
					builder.CloseElement();
				}
				else
				{
					builder.AddAttribute(sequence++, Attributes.AriaCurrent, "page");
					builder.AddContent(sequence++, this.ChildContent);
				}
			}
			builder.CloseElement();
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder.Add(Modifiers.Common.Active, this.Active);
		}
	}
}
