using Microsoft.AspNetCore.Components;

namespace BlazorVault.Components.Content
{
	public abstract class BVDropdownBase : BVContentComponent
	{
		protected override bool Simple => false;

		protected override string ClassBase => "dropdown";

		[Parameter]
		public string Text { get; set; }
	}
}
