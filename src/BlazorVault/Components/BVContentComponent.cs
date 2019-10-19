using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault.Components
{
	public abstract class BVContentComponent : BVComponentBase
	{
		/// <summary>
		/// Inner HTML.
		/// </summary>
		[Parameter]
		public virtual RenderFragment ChildContent { get; set; }

		protected override void RenderInnerHtml(
			RenderTreeBuilder builder, ref int sequence)
		{
			builder.AddContent(sequence++, ChildContent);
		}
	}
}
