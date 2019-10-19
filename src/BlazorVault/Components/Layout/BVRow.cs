using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public sealed class BVRow : BVDynamic
	{
		/// <summary>
		/// Horizontal alignment of items.
		/// </summary>
		[Parameter]
		public Justify? Horizontal { get; set; }

		[Parameter]
		public bool NoGutters { get; set; }

		protected override bool Simple => true;

		protected override string ClassBase
		{
			get
			{
				return Modifiers.Layouts.Row;
			}
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);

			if (Horizontal.HasValue && Horizontal != Justify.None)
			{
				var justification = string.Format(
					Modifiers.Layouts.JustificationGeneric,
					this.Horizontal.ToString().ToLower());

				builder.Add(justification);
			}
		}
	}
}
