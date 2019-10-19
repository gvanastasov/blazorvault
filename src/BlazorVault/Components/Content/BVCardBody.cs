using BlazorVault.Components;
using BlazorVault.Constants;

namespace BlazorVault
{
	public sealed class BVCardBody : BVContentComponent
	{
		protected override bool Simple
		{
			get
			{
				return true;
			}
		}

		protected override string ClassBase
		{
			get
			{
				return Modifiers.Elements.CardBody;
			}
		}

	}
}
