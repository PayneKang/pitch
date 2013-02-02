using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Pitch.Requests
{
	public static class PostRequest
	{
		public static async Task<IEnumerable<Pitch.Models.V0_1_0.Post>> GetPosts(string serverUri, IEnumerable<string> postTypes)
		{
			IEnumerable<Pitch.Models.V0_1_0.Post> ret = null;
			string uri = String.Format(CultureInfo.InvariantCulture, "{0}/posts?post_types={1}", serverUri,
				string.Join(",", postTypes));

			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					ret = JsonConvert.DeserializeObject<IEnumerable<Pitch.Models.V0_1_0.Post>>(
						await response.Content.ReadAsStringAsync());
				}
			}
			return ret;
		}

		public static async Task Post(string serverUri,
			Pitch.Models.V0_1_0.Post post,
			Pitch.Models.V0_1_0.AccessTokenResponseModel userAccessToken)
		{
			string uri = String.Format(CultureInfo.InvariantCulture, "{0}/posts", serverUri);
			string err = null;

			try
			{
				using (HttpClientHandler defaultHandler = new HttpClientHandler())
				using (HmacHandler hmacHandler = new HmacHandler(defaultHandler, userAccessToken.AccessToken, userAccessToken.MacKey))
				using (HttpClient client = new HttpClient(hmacHandler))
				{
					client.DefaultRequestHeaders.Add("Accept", Miscellaneous.MEDIA_TYPE);

					var requestJson = JsonConvert.SerializeObject(post);
					client.DefaultRequestHeaders.Add("Accept", Miscellaneous.MEDIA_TYPE);

					var response = await client.PostAsync(uri,
						new StringContent(requestJson, Encoding.UTF8, Miscellaneous.MEDIA_TYPE));
					if (response.IsSuccessStatusCode)
					{
						var responseString = await response.Content.ReadAsStringAsync();
						Debug.WriteLine("app_registration: " + responseString);
					}
					else
					{
						err = await response.Content.ReadAsStringAsync();
					}
				}
			}
			catch (Exception e)
			{
				err = e.Message;
			}
			if (err != null)
			{
				var msg = new MessageDialog("AccessToken request failed with error: " + err + Environment.NewLine
						+ err.ToString(), "Access Token Error");
				await msg.ShowAsync();
			}
		}
	}
}
