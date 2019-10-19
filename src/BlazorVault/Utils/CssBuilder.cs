using System;
using System.Text;

namespace BlazorVault.Utils
{
	public class CssBuilder
	{
		public const string Separator = " ";

		private readonly StringBuilder _buffer;

		public CssBuilder()
		{
			this._buffer = new StringBuilder();
		}

		public CssBuilder(string @class)
		{
			this._buffer = new StringBuilder(@class);
		}

		public CssBuilder(params string[] classes)
		{
			string classString = GetClassString(ref classes);
			this._buffer = new StringBuilder(classString);
		}

		public CssBuilder Add(string @class)
		{
			if (string.IsNullOrWhiteSpace(@class))
			{
				throw new ArgumentException($"{nameof(@class)} cannot be null or white space.");
			}

			this._buffer.Append(Separator).Append(@class);
			return this;
		}

		public CssBuilder Add(string @class, bool condition)
		{
			if (condition)
			{
				Add(@class);
			}
			return this;
		}

		public CssBuilder Add(string @class, Func<bool> condition)
		{
			if (condition == null)
			{
				throw new ArgumentException($"{nameof(condition)} cannot be null.");
			}

			if (condition.Invoke())
			{
				Add(@class);
			}
			return this;
		}

		public CssBuilder Add(params string[] classes)
		{
			if (classes?.Length != 0)
			{
				string classString = GetClassString(ref classes);
				Add(classString);
			}
			return this;
		}

		public CssBuilder Add(bool condition, params string[] classes)
		{
			if (classes?.Length != 0)
			{
				string classString = GetClassString(ref classes);
				Add(classString, condition);
			}
			return this;
		}

		public CssBuilder Add(Func<bool> condition, params string[] classes)
		{
			if (classes?.Length != 0)
			{
				string classString = GetClassString(ref classes);
				Add(classString, condition);
			}
			return this;
		}

		public string Build()
		{
			return this._buffer
				.ToString()
				.Trim();
		}

		private static string GetClassString(ref string[] classes)
		{
			return string.Join(Separator, classes);
		}
	}
}
