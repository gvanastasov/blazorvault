using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace BlazorVault.Components.Content
{
	public class BVCarouselBase : BVContentComponent
	{

		protected override bool Simple => false;

		protected override string ClassBase => "carousel";

		public LinkedListNode<BVCarouselSlide> Active;

		public LinkedList<BVCarouselSlide> Slides { get; set; } = new LinkedList<BVCarouselSlide>();

		private bool HasSlides
		{
			get
			{
				return this.Slides.Any();
			}
		}

		private bool _showControls = true;
		[Parameter]
		public bool ShowControls
		{
			get
			{
				return this._showControls && this.Slides.Count > 1;
			}
			set
			{
				this._showControls = value;
			}
		}

		[Parameter]
		public bool Loop { get; set; }

		protected bool HasPrev
		{
			get
			{
				return this.Loop || (this.ShowControls && this.Active.Previous != null);
			}
		}

		protected bool HasNext
		{
			get
			{
				return this.Loop || (this.ShowControls && this.Active.Next != null);
			}
		}

		private void Awake()
		{
			if (Active == null)
			{
				Active = Slides.First;
			}

			StateHasChanged();
		}

		public void Update()
		{
			this.StateHasChanged();
		}

		protected override void OnAfterRender(bool firstRender)
		{
			if (firstRender && HasSlides)
			{
				this.Awake();
			}
		}

		public void Next()
		{
			if (HasNext)
			{
				Active = (Active.Next == null && Loop)
					? Slides.First
					: Active.Next;
			}
		}

		public void Prev()
		{
			if (HasPrev)
			{
				Active = (Active.Previous == null && Loop)
					? Slides.Last
					: Active.Previous;
			}
		}
	}
}

