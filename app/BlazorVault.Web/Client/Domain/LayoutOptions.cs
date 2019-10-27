using System;

namespace BlazorVault.Web.Client.Domain
{
	internal sealed class LayoutOptions
	{
		private bool showSideBar;
		internal bool ShowSideBar
		{
			get
			{
				return showSideBar;
			}
			set
			{
				IsDirty = true;
				showSideBar = value;
			}
		}

		private bool gatesHidden;
		internal bool GatesHidden
		{
			get
			{
				return gatesHidden;
			}
			set
			{
				IsDirty = true;
				gatesHidden = value;
			}
		}

		internal bool IsDirty { get; set; }
	}
}
