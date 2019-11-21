using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorVault
{
	/// <summary>
	/// Provide contextual feedback messages for typical user actions with the 
	/// handful of available and flexible alert messages.
	/// </summary>
	public sealed class BVAlert : BVStyleComponent
	{
		private const int DismissAnimationTimespan = 150;

		/// <summary>
		/// Describes the ability to dismiss/hide the alart message.
		/// </summary>
		[Display(
			Name = nameof(Dismissible),
			Description = "Describes the ability to dismiss/hide the alart message.",
			Order = 10)]
		[Parameter]
		public bool Dismissible { get; set; }

		[Display(
			Name = nameof(HideDismissButton),
			Description = "Hides the dismiss button.",
			Order = 20)]
		[Parameter]
		public bool HideDismissButton { get; set; }

		public bool Hidden { get; set; }

		/// <summary>
		/// Returns a css style string in the format
		/// of 'alert-{<see cref="Style"/>}'.
		/// </summary>
		protected override string VariantClass
		{
			get
			{
				return string.Format(
					Modifiers.Elements.AlertGeneric, 
					Style.ToString().ToLower());
			}
		}

		/// <summary>
		/// Defaults to <see cref="Style.Primary"/>.
		/// </summary>
		protected override Style? DefaultStyle => BlazorVault.Style.Primary;

		/// <summary>
		/// Results in bootstrap 'alert' CSS class.
		/// </summary>
		protected override string ClassBase => Modifiers.Elements.Alert;

		/// <summary>
		/// The components simple markup between open and end tags.
		/// </summary>
		protected override bool Simple => true;

		/// <summary>
		/// Adds 'alert' role to the element attributes.
		/// </summary>
		protected override string Role => Modifiers.Elements.Alert;

		private Dictionary<string, object> DismissButtonAttributes { get; set; }

		// TODO: move out once we have proper state machine
		private AnimationState _animationState = AnimationState.Idle;
		private AnimationState AnimationState
		{
			get
			{
				return _animationState;
			}
			set
			{
				var dirty = false;

				_animationState = value;

				if (_animationState == AnimationState.EnterEnd)
				{
					dirty = true;
					this.Hidden = true;
				}
				else if (_animationState == AnimationState.LeaveStart)
				{
					dirty = true;
					this.Hidden = false;
				}
				else if (_animationState == AnimationState.LeaveEnd)
				{
					_animationState = AnimationState.Idle;
					dirty = true;
				}

				if (Debug)
				{
					Console.WriteLine($"animation: {_animationState}");
				}

				if (OnAnimatioStateChange.HasDelegate)
				{
					Task.Run(() => OnAnimatioStateChange.InvokeAsync(_animationState));
				}

				if (dirty)
				{
					StateHasChanged();
				}
			}
		}

		[Parameter]
		public EventCallback<AnimationState> OnAnimatioStateChange { get; set; }

		/// <summary>
		/// Dismisses the alert box after animation time ends.
		/// </summary>
		[Display(
			Name = nameof(Dismiss),
			Description = "Dismisses the alert box after animation time ends.")]
		public void Dismiss()
		{
			if (Debug)
			{
				Console.WriteLine($"Dismiss");
			}

			Task.Run(() => DismissAsync());
		}

		[Display(
			Name = nameof(Show),
			Description = "Shows the alert box after animation time ends.")]
		public void Show()
		{
			if (Debug)
			{
				Console.WriteLine($"Dismiss");
			}

			Task.Run(() => ShowAsync());
		}

		protected override void OnParametersSet()
		{
			if (Debug)
			{
				Console.WriteLine($"Parameter set");
			}

			base.OnParametersSet();

			if (this.Dismissible)
			{
				this.DismissButtonAttributes = new Dictionary<string, object>
				{
					{ "class", "close" },
					{ "aria-label", "Close" },
					{ "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, DismissAsync) }
				};
			}
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder
				.Add(this.Dismissible, "alert-dismissible", "fade")
				.Add("show", this.Dismissible && this.AnimationState == AnimationState.Idle);
		}

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			if (Debug)
			{
				Console.WriteLine($"Build tree");
			}

			if (Hidden)
			{
				return;
			}

			base.BuildRenderTree(builder);
		}

		protected override void RenderInnerHtml(RenderTreeBuilder builder, ref int sequence)
		{
			base.RenderInnerHtml(builder, ref sequence);

			if (this.Dismissible && !this.HideDismissButton)
			{
				RenderDismissButton(builder, ref sequence);
			}
		}

		/// <summary>
		/// Renders dismiss button at the right end of the alert bounding box.
		/// </summary>
		/// <param name="builder">The current tree builder.</param>
		/// <param name="sequence">The current stream pointer.</param>
		/// <returns></returns>
		private void RenderDismissButton(RenderTreeBuilder builder, ref int sequence)
		{
			builder.OpenElement(sequence++, MarkupElements.Button);
			builder.AddMultipleAttributes(sequence++, this.DismissButtonAttributes);
			RenderDismissIcon(builder, ref sequence);
			builder.CloseElement();
		}

		/// <summary>
		/// Renders the dismiss icon inside the dismiss button - <see cref="RenderDismissButton"/>.
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="sequence"></param>
		/// <returns></returns>
		private void RenderDismissIcon(RenderTreeBuilder builder, ref int sequence)
		{
			builder.OpenElement(sequence++, MarkupElements.Span);
			builder.AddAttribute(sequence++, "aria-hidden", true.ToString().ToLower());
			builder.AddMarkupContent(sequence++, "&times;");
			builder.CloseElement();
		}

		/// <summary>
		/// Dismisses the alert box after animation time ends asynchronous.
		/// </summary>
		/// <returns></returns>
		private async Task DismissAsync()
		{
			AnimationState = AnimationState.EnterStart;

			// TODO: find a smart way to delagate thise animations. State machine?
			await Task.Run(() =>
			{
				Thread.Sleep(DismissAnimationTimespan);
				AnimationState = AnimationState.EnterEnd;
			});
		}

		private async Task ShowAsync()
		{
			AnimationState = AnimationState.LeaveStart;

			await Task.Run(() =>
			{
				Thread.Sleep(DismissAnimationTimespan);
				AnimationState = AnimationState.LeaveEnd;
			});
		}
	}
}
