using BlazorVault.Components;
using BlazorVault.Constants;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public class BVText : BVComponentBase
	{
		/// <summary>
		/// Inner HTML.
		/// </summary>
		[Parameter]
		public RenderFragment ChildContent { get; set; }

		/// <summary>
		/// Makes a paragraph stand out.
		/// </summary>
		[Parameter]
		public bool Lead { get; set; }

		protected override string DefaultTag
		{
			get
			{
				return MarkupElements.Paragraph;
			}
		}

		protected override string ClassBase
		{
			get
			{
				if (Lead)
				{
					return string.Format(Modifiers.Typographies.Lead, Lead);
				}

				return base.ClassBase;
			}
		}

		protected override bool Simple => true;
	}
}
