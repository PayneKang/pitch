using SampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Pitch;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace SampleApp.Views
{
	/// <summary>
	/// A basic page that provides characteristics common to most applications.
	/// </summary>
	public sealed partial class TestPage : SampleApp.Common.LayoutAwarePage
	{
		public TestPage()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			DataContext = new TestPageViewModel();
		}
		/// <summary>
		/// Populates the page with content passed during navigation.  Any saved state is also
		/// provided when recreating a page from a prior session.
		/// </summary>
		/// <param name="navigationParameter">The parameter value passed to
		/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
		/// </param>
		/// <param name="pageState">A dictionary of state preserved by this page during an earlier
		/// session.  This will be null the first time a page is visited.</param>
		protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
		{
		}

		/// <summary>
		/// Preserves state associated with this page in case the application is suspended or the
		/// page is discarded from the navigation cache.  Values must conform to the serialization
		/// requirements of <see cref="SuspensionManager.SessionState"/>.
		/// </summary>
		/// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
		protected override void SaveState(Dictionary<String, Object> pageState)
		{
		}

		private async void TestButton_Click_1(object sender, RoutedEventArgs e)
		{
			// HttpClient functionality can be extended by plugging multiple handlers together and providing
			// HttpClient with the configured handler pipeline.

			await ((TestPageViewModel)DataContext).DoRequest();
		}

		private async void RegisterAppButton_Click_1(object sender, RoutedEventArgs e)
		{
			await ((TestPageViewModel)DataContext).DoAppRegistration();
		}

		private async void AccessTokenButton_Click_1(object sender, RoutedEventArgs e)
		{
			await ((TestPageViewModel)DataContext).DoAccessTokenRequest();
		}

		private async void PostMessage_Click_1(object sender, RoutedEventArgs e)
		{
			await ((TestPageViewModel)DataContext).DoPostMessage();
		}
	}
}
