using BlazorVault.Components;
using BlazorVault.Constants;
using BlazorVault.Utils;
using BlazorVault.Web.Client.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;
using System;

namespace BlazorVault
{
	public sealed class BVLink : BVContentComponent, IDisposable
	{
		[Inject]
		private NavigationManager UriHelper { get; set; }

		/// <summary>
		/// Relative path to the root.
		/// </summary>
		[Parameter]
		public string To { get; set; }

		[Parameter]
		public bool Active { get; set; }

		protected override bool Simple => true;

		protected override string DefaultTag => MarkupElements.Anchor;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				UriHelper.LocationChanged -= OnLocationChanged;
			}
		}

		protected override void AddAttributes(RenderTreeBuilder builder, ref int sequence)
		{
			base.AddAttributes(builder, ref sequence);
			builder.AddAttribute(sequence++, "href", this.To);
		}

		protected override void GetClassString(CssBuilder builder)
		{
			base.GetClassString(builder);
			builder.Add("active", this.Active);
		}

		protected override void OnInitialized()
		{
			UriHelper.LocationChanged += OnLocationChanged;
			OnLocationChanged(this, new LocationChangedEventArgs(UriHelper.Uri, true));
		}

		private void OnLocationChanged(object sender, LocationChangedEventArgs e)
		{
			var href = UriHelper.BaseUri + To;
			var active = e?.Location.AreTheSameUrls(href) ?? false;

			if (this.Active != active)
			{
				this.Active = active;
			}
			StateHasChanged();
		}
	}
}
