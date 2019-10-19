using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorVault.Components.Content
{
	public class BVToastBase : BVContentComponent
	{
		protected override bool Simple => false;

		[Inject]
		private IJSRuntime JSRuntime { get; set; }

		protected ElementReference Self { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				await Show();
			}
		}

		private async Task Show()
		{
			await JSRuntime.InvokeAsync<object>("bv.toast.show", this.Self);
		}

		protected async Task Hide()
		{
			await JSRuntime.InvokeAsync<object>("bv.toast.hide", this.Self);
		}
	}
}
