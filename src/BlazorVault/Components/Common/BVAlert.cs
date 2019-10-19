using BlazorVault.Constants;

namespace BlazorVault
{
	public sealed class BVAlert : BVStyleComponent
	{
		protected override string VariantClass
		{
			get
			{
				return string.Format(
					Modifiers.Elements.AlertGeneric, 
					Style.ToString().ToLower());
			}
		}

		protected override bool Simple => true;

		protected override string Role => Modifiers.Elements.Alert;
	}
}
