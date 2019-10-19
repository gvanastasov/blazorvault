using BlazorVault.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorVault
{
	public sealed class BVCollapsable : BVContentComponent
	{
		protected override bool Simple => true;

		protected override string ClassBase => "collapse";

		[Inject]
		private IJSRuntime JSRuntime { get; set; }

		private ElementReference area;

		protected override void AddAttributes(RenderTreeBuilder builder, ref int sequence)
		{
			base.AddAttributes(builder, ref sequence);
			builder.AddElementReferenceCapture(sequence++, (@ref) => this.area = @ref);
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				await JSRuntime.InvokeAsync<object>("bv.toggle.assign", this.area);
			}
		}
	}
}
