using BlazorVault.Components;

namespace BlazorVault
{
	public sealed class BVInput : BVComponentBase
	{
		protected override string DefaultTag => "input";

		protected override bool Simple => true;

		protected override string ClassBase => "form-control";
	}
}
