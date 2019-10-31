using Microsoft.AspNetCore.Components;

namespace BlazorVault.Components.Layout
{
	public class BVTabBase : BVContentComponent
	{
		protected override bool Simple => false;

		public bool Active { get; set; }

		[CascadingParameter]
		private BVTabGroup Parent { get; set; }

		[Parameter]
		public RenderFragment Trigger { get; set; }

		private bool IsActive
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
