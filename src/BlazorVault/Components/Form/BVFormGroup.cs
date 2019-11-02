using BlazorVault.Components;

namespace BlazorVault
{
	public sealed class BVFormGroup : BVContentComponent
	{
		protected override bool Simple => true;

		protected override string ClassBase => "form-group";
	}
}
