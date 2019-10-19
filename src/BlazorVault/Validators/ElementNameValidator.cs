using System;

namespace BlazorVault.Validators
{
	internal static class ElementNameValidator
	{
		internal static bool IsValidHeadingSize(int value)
		{
			return value >= 1 && value <= 6;
		}
	}
}
