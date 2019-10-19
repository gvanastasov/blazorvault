using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorVault
{
	/// <summary>
	/// The element represents a clickable button, which can be 
	/// used in forms or anywhere in a document that needs simple, 
	/// standard button functionality.
	/// </summary>
	public sealed class BVButton : BVStyleComponent
	{
		protected override string DefaultTag
		{
			get
			{
				return MarkupElements.Button;
			}
		}

		protected override string ClassBase
		{
			get
			{
				return Modifiers.Common.Btn;
			}
		}

		[Parameter]
		public ButtonType Type { get; set; }

		[Parameter]
		public string Toggle { get; set; }

		protected override bool Simple => true;

		[Inject]
		private IJSRuntime JSRuntime { get; set; }

		protected override void AddAttributes(
			RenderTreeBuilder builder, ref int sequence)
		{
			base.AddAttributes(builder, ref sequence);
			builder.AddAttribute(sequence++, Attributes.Type, Type.ToString().ToLower());

			if (this.DefaultTag != MarkupElements.Button)
			{
				builder.AddAttribute(sequence++, Attributes.Role, MarkupElements.Button);
			}

			if (!string.IsNullOrWhiteSpace(Toggle))
			{
				builder.AddAttribute(sequence++, "data-toggle", "collapse");
				builder.AddAttribute(sequence++, "data-target", $"#{this.Toggle}");
				builder.AddAttribute(sequence++, "aria-expanded", false.ToString().ToLower());
				builder.AddAttribute(sequence++, "aria-controls", this.Toggle);
				builder.AddAttribute(sequence++, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, OnClick));
			}
		}

		private async void OnClick()
		{
			await JSRuntime.InvokeAsync<object>("exampleJsFunctions.showPrompt");

			this.Style = BlazorVault.Style.Dark;

			StateHasChanged();
		}
	}
}
