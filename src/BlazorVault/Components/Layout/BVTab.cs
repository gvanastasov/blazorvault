using BlazorVault.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVTab : BVContentComponent
	{
		protected override bool Simple => false;

		public bool Active { get; set; }

		[CascadingParameter]
		private BVTabGroup Parent { get; set; }

		[Parameter]
		public RenderFragment Trigger { get; set; }

		public bool IsActive
		{
			get
			{
				return Parent.Active == this;
			}
		}

		protected override void OnInitialized()
		{
			Parent.Tabs.Add(this);

			if (Active)
			{
				Parent.Select(this);
			}
		}
	}
}
