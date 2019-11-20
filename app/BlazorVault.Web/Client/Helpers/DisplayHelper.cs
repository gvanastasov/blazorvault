using BlazorVault.Web.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BlazorVault.Web.Client.Helpers
{
	public static class DisplayHelper
	{
		public static List<TComponent> GetDisplayAttributeData<TMember, TComponent>(
			IEnumerable<TMember> members, Action<TMember, TComponent> callback)
			where TMember : MemberInfo
			where TComponent : ComponentMemberViewModel, new()
		{
			var result = new List<TComponent>();
			foreach (var member in members)
			{
				var display = member
					.GetCustomAttributes(typeof(DisplayAttribute), true)
					.FirstOrDefault() as DisplayAttribute;

				if (display != null)
				{
					var data = new TComponent
					{
						Name = display.GetName(),
						Description = display.GetDescription(),
					};
					callback?.Invoke(member, data);
					result.Add(data);
				}
			}
			return result;
		}
	}
}
