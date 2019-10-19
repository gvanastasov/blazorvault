using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorVault
{
	public sealed class BVGroupItem : BVStyleComponent
	{
		[Parameter]
		public bool Active { get; set; }

		[Parameter]
		public bool Disabled { get; set; }

		[Parameter]
		public bool Link { get; set; }

		[CascadingParameter(Name = "Actions")]
		public bool IsActionElement { get; set; }

		protected override bool Simple => true;

		protected override string DefaultTag
		{
			get
			{
				return this.IsActionElement
					? this.ActionTag
					: MarkupElements.ListItem;
			}
		}

		protected override string ClassBase => Modifiers.Elements.ListGroupItem;

		private string ActionTag
		{
			get
			{
				return this.Link
					? MarkupElements.Anchor
					: MarkupElements.Button;
			}
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder.Add("list-group-item-action", this.IsActionElement);
			builder.Add(Modifiers.Common.Active, this.Active);
			builder.Add(Modifiers.Common.Disabled, this.Disabled && this.Link);
		}

		protected override void AddAttributes(RenderTreeBuilder builder, ref int sequence)
		{
			base.AddAttributes(builder, ref sequence);

			if (IsActionElement)
			{
				if (!Link)
				{
					builder.AddAttribute(sequence++, Attributes.Type, ButtonType.Button.ToString().ToLower());
				}
			}

			if (Disabled)
			{
				if (Link) 
				{
					builder.AddAttribute(sequence++, Attributes.AriaDisabled, true.ToString().ToLower());

					if (IsActionElement)
					{
						builder.AddAttribute(sequence++, Attributes.TabIndex, -1);
					}
				}
				else
				{
					builder.AddAttribute(sequence++, Modifiers.Common.Disabled, true);
				}
			}
		}
	}
}
