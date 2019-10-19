using BlazorVault.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public class BVDynamic : BVContentComponent
	{
		protected override bool Simple
		{
			get
			{
				return true;
			}
		}

		private string _tag;

		[Parameter]
		public string Tag
		{
			get
			{
				return _tag;
			}
			set
			{
				// TODO: add validation
				_tag = value;
			}
		}

		protected override string DefaultTag
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(this.Tag))
				{
					return this.Tag;
				}

				return base.DefaultTag;
			}
		}
	}
}
