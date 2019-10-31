using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;

namespace BlazorVault.Components.Layout
{
	public class BVTabGroupBase : BVContentComponent
	{
		protected override bool Simple => false;

		public IList<BVTabBase> Tabs { get; private set; } = new List<BVTabBase>();

		public BVTabBase Active { get; private set; }

		private bool HasTabs
		{
			get
			{
				return this.Tabs.Any();
			}
		}

		private void Awake()
		{
			if (Active == null)
			{
				Active = Tabs.FirstOrDefault();
			}

			StateHasChanged();
		}

		public void Update()
		{
			this.StateHasChanged();
		}

		protected override void OnAfterRender(bool firstRender)
		{
			if (firstRender && HasTabs)
			{
				this.Awake();
			}
		}

		public void Select(MouseEventArgs e, BVTabBase tab)
		{
			Select(tab);
		}

		public void Select(BVTabBase tab)
		{
			Active = tab;
		}
	}
}
