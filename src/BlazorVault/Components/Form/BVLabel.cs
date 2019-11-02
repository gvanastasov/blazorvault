using BlazorVault.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVLabel : BVContentComponent
	{
		protected override string DefaultTag => "label";

		protected override bool Simple => true;

		[Parameter]
		public string For { get; set; }
	}
}
