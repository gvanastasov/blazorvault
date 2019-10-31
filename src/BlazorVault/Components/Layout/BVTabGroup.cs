using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;

namespace BlazorVault.Components.Layout
{
	public class BVTabGroupBase : BVContentComponent
	{
		protected override bool Simple => false;

		public IList<BVTab> Tabs { get; private set; } = new List<BVTab>();

		public BVTab Active { get; private set; }

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

		public void Select(MouseEventArgs e, BVTab tab)
		{
			Select(tab);
		}

		public void Select(BVTab tab)
		{
			Active = tab;
		}
	}
}
