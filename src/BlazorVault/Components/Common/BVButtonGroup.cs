using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Extensions;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault
{
	public sealed class BVButtonGroup : BVContentComponent
	{
		protected override string ClassBase
		{
			get
			{
				if (this.Stacked)
				{
					return Modifiers.Common.BtnGroupVertical;
				}

				return this.Toolbar
					? Modifiers.Common.BtnToolbar
					: Modifiers.Common.BtnGroup;
			}
		}

		[Parameter]
		public string AriaLabel { get; set; }

		[Parameter]
		public bool Toolbar { get; set; }

		/// <summary>
		/// Make a set of buttons appear vertically stacked rather than horizontally.
		/// </summary>
		[Parameter]
		public bool Stacked { get; set; }

		[Parameter]
		public Size? Size { get; set; }

		protected override string Role
		{
			get
			{
				return this.Toolbar
					? Modifiers.Common.Toolbar
					: Modifiers.Common.Group;
			}
		}

		protected override bool Simple => true;

		protected override void AddAttributes(RenderTreeBuilder builder, ref int sequence)
		{
			base.AddAttributes(builder, ref sequence);
			builder
				.AddAttribute(sequence++, Attributes.AriaLabel, this.AriaLabel);
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);

			if (this.Size.HasValue)
			{
				builder
					.Add(this.Size.Description());
			}
		}
	}
}
