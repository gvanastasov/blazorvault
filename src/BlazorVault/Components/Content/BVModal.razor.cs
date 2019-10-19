using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorVault.Components.Content
{
	public class BVModalBase : BVContentComponent
	{
		protected override bool Simple => false;

		[Inject]
		private IJSRuntime JSRuntime { get; set; }

		protected ElementReference Self { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				await Open();
			}
		}

		private async Task Open()
		{
			await JSRuntime.InvokeAsync<object>("bv.modal.open", this.Self);
		}

		protected async Task Close()
		{
			await JSRuntime.InvokeAsync<object>("bv.modal.close", this.Self);
		}
	}
}
