using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Utils;
using BlazorVault.Validators;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorVault
{
	/// <summary>
	/// TODO: write
	/// </summary>
	public sealed class BVHeading : BVContentComponent
	{
		private int _level = 1;

		[Parameter]
		public int Level
		{
			get
			{
				return _level;
			}
			set
			{
				if (!ElementNameValidator.IsValidHeadingSize(value))
				{
					var message = string.Format(
						Templates.ExceptionMessages.Between, value, nameof(Level), 1, 6);
					throw new Exception(message);
				}
				_level = value;
			}
		}

		private int? _as;

		[Parameter]
		public int? As
		{
			get
			{
				return _as;
			}
			set
			{
				if (value.HasValue && !ElementNameValidator.IsValidHeadingSize(value.Value))
				{
					var message = string.Format(
						Templates.ExceptionMessages.Between, value, nameof(As), 1, 6);
					throw new Exception(message);
				}
				_as = value;
			}
		}

		/// <summary>
		/// Makes the heading render larger than normal.
		/// </summary>
		[Parameter]
		public bool Large { get; set; }

		protected override string DefaultTag
		{
			get
			{
				return string.Format(MarkupElements.HeadingGeneric, this.Level);
			}
		}

		protected override bool Simple => true;

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);

			if (As.HasValue)
			{
				var template = Large
					? Modifiers.Typographies.Display
					: Modifiers.Typographies.Heading;

				var size = Math.Min(As.Value, Large ? 4 : 6);
				builder.Add(string.Format(template, size));
			}
			else if (Large)
			{
				var displayClass = string.Format(Modifiers.Typographies.Display, Level);
				builder.Add(displayClass);
			}
		}
	}
}
