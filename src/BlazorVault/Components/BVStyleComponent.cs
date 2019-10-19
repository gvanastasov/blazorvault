﻿using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;

namespace BlazorVault
{
	public abstract class BVStyleComponent : BVContentComponent
	{
		private Style? _style;

		[Parameter]
		public virtual Style? Style
		{
			get
			{
				return _style ?? DefaultStyle;
			}
			set
			{
				_style = value;
			}
		}

		protected virtual Style? DefaultStyle { get; }

		/// <summary>
		/// Returns a css style string in the format
		/// of 'btn-{<see cref="Style"/>}'.
		/// </summary>
		protected virtual string VariantClass
		{
			get
			{
				return string.Concat(
					ClassBase, Modifiers.Separator, this.Style.ToString().ToLower());
			}
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder.Add(VariantClass, Style.HasValue);
		}
	}
}
