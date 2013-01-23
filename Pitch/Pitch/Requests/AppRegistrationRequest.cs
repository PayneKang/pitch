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
	public static class AppRegistrationRequest
	{
		public static async Task<Pitch.Models.V0_1_0.AppRegistrationResponseModel>
			RegisterNewAppAsync(string serverUri, Pitch.Models.V0_1_0.AppRegistrationRequestModel request)
		{
			if (serverUri == null) throw new ArgumentNullException("serverUri");
			if (request == null) throw new ArgumentNullException("request");

			Pitch.Models.V0_1_0.AppRegistrationResponseModel ret = null;
            Exception err = null;
            try
            {
                HttpClient client = new HttpClient();
                var requestJson = JsonConvert.SerializeObject(request);
                client.DefaultRequestHeaders.Add("Accept", Miscellaneous.MEDIA_TYPE);

                var response = await client.PostAsync(serverUri + "/apps", 
                    new StringContent(requestJson, Encoding.UTF8, Miscellaneous.MEDIA_TYPE));

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("app_registration: " + responseString);

                    ret = JsonConvert.DeserializeObject<Pitch.Models.V0_1_0.AppRegistrationResponseModel>(responseString);
                    ret.OriginalResponse = JsonConvert.SerializeObject(ret, Formatting.Indented);
                }
            }
            catch(Exception e)
            {
                ret = null;
                err = e;
            }
            if (err != null)
            {
                var msg = new MessageDialog("App registration failed with error: " + err.Message + Environment.NewLine
                    + err.ToString(), "App Registration Error");
                await msg.ShowAsync();
            }
            else if (ret == null)
            {
                var msg = new MessageDialog("Didn't understand the response from the server, or other unexpected response.",
                    "App Registration Error");
                await msg.ShowAsync();
            }

			return ret;
		}
	}
}
