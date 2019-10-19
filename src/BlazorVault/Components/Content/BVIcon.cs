using BlazorVault.Constants;
using BlazorVault.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault
{
	public sealed class BVIcon : ComponentBase
	{
		[Parameter]
		public Icon Type { get; set; }

		private string CssClass
		{
			get
			{
				return $"oi oi-{Type.Description()}";
			}
		}

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			base.BuildRenderTree(builder);

			var sequence = 0;
			builder.OpenElement(sequence, MarkupElements.Span);
			builder.AddAttribute(sequence++, Attributes.Class, CssClass);
			builder.AddAttribute(sequence++, Attributes.AriaHidden, true.ToString().ToLower());
			builder.CloseElement();
		}
	}
}
