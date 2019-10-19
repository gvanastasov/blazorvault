using BlazorVault.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	/// <summary>
	/// TODO: write description.
	/// </summary>
	public class BVContainer : BVContentComponent
	{
		/// <summary>
		/// Use this for a full fluid container.
		/// </summary>
		[Parameter]
		public bool Fluid { get; set; }

		public string Modifiers
		{
			get
			{
				return Fluid
					? Constants.Modifiers.Layouts.ContainerFluid
					: Constants.Modifiers.Layouts.Container;
			}
		}

		protected override bool Simple => true;
	}
}
