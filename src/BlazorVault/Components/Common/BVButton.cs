using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorVault
{
	/// <summary>
	/// The element represents a clickable button, which can be 
	/// used in forms or anywhere in a document that needs simple, 
	/// standard button functionality.
	/// </summary>
	public sealed class BVButton : BVStyleComponent
	{
		[Inject]
		NavigationManager NavigationManager { get; set; }

		protected override Style? DefaultStyle => BlazorVault.Style.Primary;

		protected override string DefaultTag
		{
			get
			{
				if (IsLink)
				{
					return MarkupElements.Anchor;
				}

				return !string.IsNullOrWhiteSpace(Tag)
					? Tag
					: MarkupElements.Button;
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
		public ButtonType Type { get; set; } = ButtonType.Button;

		[Parameter]
		public string Toggle { get; set; }

		[Parameter]
		public string Href { get; set; }

		[Parameter]
		public string Tag { get; set; }

		protected override bool Simple => true;

		private bool IsToggle
		{
			get
			{
				return !string.IsNullOrWhiteSpace(Toggle);
			}
		}

		private bool IsLink
		{
			get
			{
				return !string.IsNullOrWhiteSpace(Href);
			}
		}

		// TODO: need two way binding for the state on after render
		private bool bvTargetExpanded { get; set; }

		[Inject]
		private IJSRuntime JSRuntime { get; set; }

		protected override void AddAttributes(
			RenderTreeBuilder builder, ref int sequence)
		{
			base.AddAttributes(builder, ref sequence);

			if (IsLink)
			{
				builder.AddAttribute(sequence++, "href", this.Href);
			}
			else
			{
				builder.AddAttribute(sequence++, Attributes.Type, (IsToggle ? ButtonType.Button : Type).ToString().ToLower());
				if (this.Tag != MarkupElements.Button)
				{
					builder.AddAttribute(sequence++, Attributes.Role, MarkupElements.Button);
				}
			}

			if (IsToggle)
			{
				builder.AddAttribute(sequence++, "data-toggle", "collapse");
				builder.AddAttribute(sequence++, "data-target", $"#{this.Toggle}");
				builder.AddAttribute(sequence++, "aria-expanded", bvTargetExpanded.ToString().ToLower());
				builder.AddAttribute(sequence++, "aria-controls", this.Toggle);
				builder.AddAttribute(sequence++, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, OnClick));
			}
		}

		protected override void RenderInnerHtml(RenderTreeBuilder builder, ref int sequence)
		{
			base.RenderInnerHtml(builder, ref sequence);
		}

		private async void OnClick()
		{
			if (IsToggle)
			{
				await ToggleTarget();
			}
			else if (IsLink)
			{
				NavigationManager.NavigateTo(this.Href);
			}
		}

		private async Task ToggleTarget()
		{
			var action = bvTargetExpanded ? "hide" : "show";
			await JSRuntime.InvokeAsync<object>($"bv.toggle.{action}", this.Toggle);

			this.bvTargetExpanded = !this.bvTargetExpanded;
			StateHasChanged();
		}
	}
}
