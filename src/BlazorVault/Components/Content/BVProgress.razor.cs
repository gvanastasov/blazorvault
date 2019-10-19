using Microsoft.AspNetCore.Components;
using System;

namespace BlazorVault.Components.Content
{
	public class BVProgressBase : BVComponentBase
	{
		[Parameter]
		public int Value { get; set; }

		[Parameter]
		public int Min { get; set; } = 0;

		[Parameter]
		public int Max { get; set; } = 100;

		protected override bool Simple => false;

		protected int LocalValue
		{
			get
			{
				return (int)(((Value - Min) * 1f / ( Max - Min )) * 100);
			}
		}
	}
}
