using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TentLib.Models;

namespace TentLib.Requests
{
	public static class ProfileRequest
	{
		public static async Task<IEnumerable<string>> GetProfileUriAsync(string entityUri)
		{
			IEnumerable<string> ret = null;
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync(entityUri);
				if (response.IsSuccessStatusCode)
				{
					ret = response.Headers.GetValues("Link").Where(X => X.Contains(Miscellaneous.PROFILE_REL_WITH_REL))
							.Select(x => x.Substring(1, x.IndexOf("; rel=") - 2));
				}
			}
			return ret;
		}

		public static async Task<Profile> GetProfileAsync(string entityUri)
		{
			Profile ret = null;
			// TODO: support multiple profile uris
			var profileUri = (await GetProfileUriAsync(entityUri)).FirstOrDefault();
			if (profileUri != null)
			{
				HttpClient client = new HttpClient();
				var response = await client.GetAsync(profileUri);
				if (response.IsSuccessStatusCode)
				{
					var responseString = await response.Content.ReadAsStringAsync();
					Debug.WriteLine("profile: " + responseString);

					ret = JsonConvert.DeserializeObject<Profile>(responseString);
					
				}
			}
			return ret;
		}
	}
}
