using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace BlazorVault.Extensions
{
	internal static class ObjectExtensions
	{
		internal static string Description(this object obj)
		{
			return obj
					.GetType()
					.GetMember(obj.ToString())
					.FirstOrDefault()
					?.GetCustomAttribute<DescriptionAttribute>()
					?.Description
				?? obj.ToString();
		}
	}
}
