using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorVault.Components.Content
{
	public class BVTreeNodeBase : BVContentComponent
	{
		protected override bool Simple => false;

		[Parameter]
		public string Caret { get; set; }

		[Parameter]
		public bool Expanded { get; set; }

		[CascadingParameter]
		public BVTreeNode Parent { get; set; }

		[Parameter]
		public RenderFragment Trigger { get; set; }

		public List<BVTreeNodeBase> Children { get; set; } = new List<BVTreeNodeBase>();

		public bool IsLeaf
		{
			get
			{
				return this.Children.Count == 0 && 
					this.Trigger == null;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();

			if (Parent != null)
			{
				Parent.Children.Add(this);
			}
		}

		protected void Toggle()
		{
			Expanded = !Expanded;
		}
	}
}
