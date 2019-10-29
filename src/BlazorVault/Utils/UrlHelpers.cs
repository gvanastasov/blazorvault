﻿using System;
using System.Web;

namespace BlazorVault.Web.Client.Helpers
{
	public static class UrlHelpers
	{
		public static bool AreTheSameUrls(this string url1, string url2)
		{
			url1 = url1.NormalizeUrl();
			url2 = url2.NormalizeUrl();
			return url1.Equals(url2);
		}

		public static bool AreTheSameUrls(this Uri uri1, Uri uri2)
		{
			var url1 = uri1.NormalizeUrl();
			var url2 = uri2.NormalizeUrl();
			return url1.Equals(url2);
		}

		public static string[] DefaultDirectoryIndexes = new[]
		{
			"index.html"
		};

		public static string NormalizeUrl(this Uri uri)
		{
			var url = urlToLower(uri);
			url = removeDefaultDirectoryIndexes(url);
			url = removeTheFragment(url);
			url = removeDuplicateSlashes(url);
			return removeTrailingSlashAndEmptyQuery(url);
		}

		public static string NormalizeUrl(this string url)
		{
			return NormalizeUrl(new Uri(url));
		}

		private static string removeDuplicateSlashes(string url)
		{
			var path = new Uri(url).AbsolutePath;
			return path.Contains("//") ? url.Replace(path, path.Replace("//", "/")) : url;
		}

		private static string removeTheFragment(string url)
		{
			var fragment = new Uri(url).Fragment;
			return string.IsNullOrWhiteSpace(fragment) ? url : url.Replace(fragment, string.Empty);
		}

		private static string urlToLower(Uri uri)
		{
			return HttpUtility.UrlDecode(uri.AbsoluteUri.ToLowerInvariant());
		}

		private static string removeTrailingSlashAndEmptyQuery(string url)
		{
			return url
					.TrimEnd(new[] { '?' })
					.TrimEnd(new[] { '/' });
		}

		private static string removeDefaultDirectoryIndexes(string url)
		{
			foreach (var index in DefaultDirectoryIndexes)
			{
				if (url.EndsWith(index))
				{
					url = url.TrimEnd(index.ToCharArray());
					break;
				}
			}
			return url;
		}
	}
}
