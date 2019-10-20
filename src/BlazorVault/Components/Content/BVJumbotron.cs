using BlazorVault.Components;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVJumbotron : BVContentComponent
	{
		[Parameter]
		public bool Fluid { get; set; }

		protected override bool Simple => true;

		protected override string ClassBase => "jumbotron";

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder.Add("jumbotron-fluid", this.Fluid);
		}
	}
}
