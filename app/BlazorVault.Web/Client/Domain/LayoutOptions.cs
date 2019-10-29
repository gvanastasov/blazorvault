namespace BlazorVault.Web.Client.Domain
{
	internal sealed class LayoutOptions
	{
		private bool _showSideBar;
		internal bool ShowSideBar
		{
			get
			{
				return _showSideBar;
			}
			set
			{
				IsDirty = true;
				_showSideBar = value;
			}
		}

		private bool _gatesHidden;

		internal bool GatesHidden
		{
			get
			{
				return _gatesHidden;
			}
			set
			{
				IsDirty = true;
				_gatesHidden = value;
			}
		}

		private string _title;
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				IsDirty = true;
				_title = value;
			}
		}

		internal bool IsDirty { get; set; }
	}
}
