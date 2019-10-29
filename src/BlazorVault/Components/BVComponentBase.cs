using BlazorVault.Constants;
using BlazorVault.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;

namespace BlazorVault.Components
{
	/// <summary>
	/// TODO: write
	/// </summary>
	public abstract class BVComponentBase : ComponentBase
	{
		[Parameter(CaptureUnmatchedValues = true)]
		public IReadOnlyDictionary<string, object> UnknownAttributes { get; set; }

		protected virtual string ClassBase { get; }

		protected virtual string DefaultTag
		{
			get
			{
				return MarkupElements.Div;
			}
		}

		protected abstract bool Simple { get; }

		protected virtual string Role { get; }

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			base.BuildRenderTree(builder);
			try
			{
				Validate();
				if (Simple)
				{
					BuildSimpleRenderTree(builder);
				}
			}
			catch
			{
				// todo: error handling
			}
		}

		protected virtual void BuildSimpleRenderTree(RenderTreeBuilder builder)
		{
			var sequence = 0;
			builder.OpenElement(sequence, DefaultTag);
			AddAttributes(builder, ref sequence);
			RenderInnerHtml(builder, ref sequence);
			builder.CloseElement();
		}

		protected virtual void AddAttributes(RenderTreeBuilder builder, ref int sequence)
		{
			// todo: need strategy
			builder.AddMultipleAttributes(sequence++, UnknownAttributes);

			var classString = GetClassString();
			if (!string.IsNullOrWhiteSpace(classString))
			{
				builder.AddAttribute(sequence++, Attributes.Class, classString);
			}

			if (!string.IsNullOrWhiteSpace(this.Role))
			{
				builder.AddAttribute(sequence++, Attributes.Role, this.Role);
			}
		}

		protected virtual void RenderInnerHtml(
			RenderTreeBuilder builder, ref int sequence)
		{
		}

		public string GetClassString()
		{
			var builder = new CssBuilder(ClassBase);

			if (UnknownAttributes != null && 
				UnknownAttributes.TryGetValue(
					Attributes.Class, out object @class))
			{
				builder.Add(@class.ToString());
			}

			GetClassString(builder);
			return builder.Build();
		}


		protected virtual void GetClassString(CssBuilder builder)
		{
		}

		protected virtual void Validate()
		{
		}
	}
}
