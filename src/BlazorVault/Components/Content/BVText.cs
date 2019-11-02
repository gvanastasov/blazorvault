using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace BlazorVault
{
	public class BVText : BVContentComponent
	{
		/// <summary>
		/// Makes a paragraph stand out.
		/// </summary>
		[Parameter]
		public bool Lead { get; set; }

		[Parameter]
		public int? Lorem { get; set; }

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

		public string LoremContent { get; set; }

		protected override void OnParametersSet()
		{
			base.OnParametersSet();

			if (Lorem.HasValue)
			{
				LoremContent = Generators.LoremIpsum(Math.Min(Lorem.Value, 30), Lorem.Value, 3, 5, 1);
			}
		}

		protected override void RenderInnerHtml(RenderTreeBuilder builder, ref int sequence)
		{
			if (Lorem.HasValue)
			{
				builder.AddContent(sequence++, LoremContent);
			}
			else
			{
				base.RenderInnerHtml(builder, ref sequence);
			}
		}
	}
}
