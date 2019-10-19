using BlazorVault.Components;
using BlazorVault.Constants;

namespace BlazorVault
{
	public class BVCard : BVContentComponent
	{
		protected override string ClassBase
		{
			get
			{
				return Modifiers.Elements.Card;
			}
		}

		protected override bool Simple => true;
	}
}
