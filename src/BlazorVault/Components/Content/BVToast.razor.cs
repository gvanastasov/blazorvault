using BlazorVault.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorVault.Components.Content
{
	public class BVToastBase : BVContentComponent
	{
		[Parameter]
		public VerticalPosition Vertical { get; set; } = VerticalPosition.Top;

		[Parameter]
		public HorizontalPosition Horizontal { get; set; } = HorizontalPosition.Right;

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
			string xPos = this.Horizontal.ToString().ToLower();
			string yPos = this.Vertical.ToString().ToLower();
			await JSRuntime.InvokeAsync<object>("bv.toast.show", this.Self, xPos, yPos);
		}

		protected async Task Hide()
		{
			await JSRuntime.InvokeAsync<object>("bv.toast.hide", this.Self);
		}
	}
}
