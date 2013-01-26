using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
	}
}
