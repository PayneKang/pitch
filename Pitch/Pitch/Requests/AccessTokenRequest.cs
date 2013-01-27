using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Pitch.Requests
{
	public static class AccessTokenRequest
	{
		public static async Task<Pitch.Models.V0_1_0.AccessTokenResponseModel>
			RequestAccessToken(string serverUri, string appId, string macKeyId, string hashKey, Pitch.Models.V0_1_0.AccessTokenRequestModel request)
		{
			if (serverUri == null) throw new ArgumentNullException("serverUri");
			if (request == null) throw new ArgumentNullException("request");

			Pitch.Models.V0_1_0.AccessTokenResponseModel ret = null;
			string err = null;
			try
			{
				System.Net.Http.HttpClientHandler defaultHandler
						= new HttpClientHandler();

				HmacHandler hmacHandler = new HmacHandler(defaultHandler,
						macKeyId, hashKey);

				HttpClient client = new HttpClient(hmacHandler);
				var requestJson = JsonConvert.SerializeObject(request);
				client.DefaultRequestHeaders.Add("Accept", Miscellaneous.MEDIA_TYPE);

				var uri = String.Format("{0}/apps/{1}/authorizations",
						serverUri, appId);

				var response = await client.PostAsync(uri,
						new StringContent(requestJson, Encoding.UTF8, Miscellaneous.MEDIA_TYPE));

				if (response.IsSuccessStatusCode)
				{
					var responseString = await response.Content.ReadAsStringAsync();
					Debug.WriteLine("app_registration: " + responseString);

					ret = JsonConvert.DeserializeObject<Pitch.Models.V0_1_0.AccessTokenResponseModel>(responseString);
					ret.OriginalResponse = JsonConvert.SerializeObject(ret, Formatting.Indented);
				}
				else
				{
					err = await response.Content.ReadAsStringAsync();
				}
			}
			catch (Exception e)
			{
				ret = null;
				err = e.Message;
			}
			if (err != null)
			{
				var msg = new MessageDialog("AccessToken request failed with error: " + err + Environment.NewLine
						+ err.ToString(), "Access Token Error");
				await msg.ShowAsync();
			}
			else if (ret == null)
			{
				var msg = new MessageDialog("Didn't understand the response from the server, or other unexpected response.",
						"Access Token Error");
				await msg.ShowAsync();
			}

			return ret;
		}
	}
}
