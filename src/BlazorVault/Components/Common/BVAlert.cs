using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace BlazorVault
{
	/// <summary>
	/// Provide contextual feedback messages for typical user actions with the 
	/// handful of available and flexible alert messages.
	/// </summary>
	public sealed class BVAlert : BVStyleComponent
	{
		/// <summary>
		/// Describes the ability to dismiss/hide the alart message.
		/// </summary>
		[Display(
			Name = nameof(Dismissible),
			Description = "Describes the ability to dismiss/hide the alart message.",
			Order = 10)]
		[Parameter]
		public bool Dismissible { get; set; }

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
	}
}
