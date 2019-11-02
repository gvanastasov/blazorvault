using BlazorVault.Components;

namespace BlazorVault
{
	public sealed class BVForm : BVContentComponent
	{
		protected override string DefaultTag => "form";

		protected override bool Simple => true;
	}
}
