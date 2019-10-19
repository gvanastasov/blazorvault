using BlazorVault.Components;
using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVCardLine : BVContentComponent
	{
		[Parameter]
		public CardLine Type { get; set; } = CardLine.Text;

		protected override string DefaultTag
		{
			get
			{
				switch (this.Type)
				{
					case CardLine.Image:
						return MarkupElements.Image;
					case CardLine.Title:
						return MarkupElements.Header5;
					case CardLine.Subtitle:
						return MarkupElements.Header6;
					case CardLine.Text:
						return MarkupElements.Paragraph;
					case CardLine.Link:
						return MarkupElements.Anchor;
					case CardLine.Heading:
						return string.Format(
							MarkupElements.HeadingGeneric, this.HeadingSize);
					default:
						break;
				};

				return DefaultTag;
			}
		}

		protected override string ClassBase
		{
			get
			{
				switch (this.Type)
				{
					case CardLine.Text:
					case CardLine.Title:
					case CardLine.Subtitle:
					case CardLine.Link:
						return string.Format(
							Modifiers.Elements.CardGeneric, 
							this.Type.ToString().ToLower());

					case CardLine.Image:
						return "card-image-top";
					case CardLine.Heading:
						return "card-title";
					default:
						break;
				}

				return ClassBase;
			}
		}

		// TODO: validation
		[Parameter]
		public int HeadingSize { get; set; }

		protected override bool Simple => true;
	}
}
