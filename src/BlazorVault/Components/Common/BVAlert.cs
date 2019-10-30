using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVAlert : BVStyleComponent
	{
		[Parameter]
		public bool Dismissible { get; set; }

		protected override string VariantClass
		{
			get
			{
				return string.Format(
					Modifiers.Elements.AlertGeneric, 
					Style.ToString().ToLower());
			}
		}

		protected override Style? DefaultStyle => BlazorVault.Style.Primary;

		protected override string ClassBase => Modifiers.Elements.Alert;

		protected override bool Simple => true;

		protected override string Role => Modifiers.Elements.Alert;
	}
}
