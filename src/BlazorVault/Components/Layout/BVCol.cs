using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVCol : BVContentComponent
	{
		// TODO: add validation
		/// <summary>
		/// Width of column within a 12-column grid. Leave null for equal 
		/// distribution.
		/// </summary>
		[Parameter]
		public int? Width { get; set; }

		// TODO: add validation
		// TODO: add summary
		// TODO: use and add other breakpoints
		[Parameter]
		public int? Sm { get; set; }

		[Parameter]
		public bool Break { get; set; }

		protected override bool Simple => true;

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);

			if (Break)
			{
				builder.Add(Modifiers.Layouts.W100);
			}
			else
			{
				if (Width.HasValue)
				{
					var cols = string.Format(Modifiers.Layouts.ColumnGeneric, Width);
					builder.Add(cols);
				}
				else
				{
					builder.Add(Modifiers.Layouts.Column);
				}
			}
		}
	}
}
