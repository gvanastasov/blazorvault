using BlazorVault.Components;

namespace BlazorVault
{
	public sealed class BVDropdownItem : BVContentComponent
	{
		protected override bool Simple => true;

		protected override string ClassBase => "dropdown-item";
	}
}