using BlazorVault.Components;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVCarouselSlide : BVContentComponent
	{
		[Parameter]
		public bool Active { get; set; }

		protected override bool Simple => true;

		protected override string ClassBase => "carousel-item";

		[CascadingParameter]
		private BVCarousel Parent { get; set; }

		private bool IsActive
		{
			get
			{
				return Parent.Active.Value == this;
			}
		}

		protected override void OnInitialized()
		{
			var self = Parent.Slides.AddLast(this);

			if (Active)
			{
				Parent.Active = self;
			}
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder.Add("active", IsActive);
		}
	}
}
