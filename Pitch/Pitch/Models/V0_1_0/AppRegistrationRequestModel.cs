using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Models.V0_1_0
{
	public class AppRegistrationRequestModel
	{
		public AppRegistrationRequestModel()
		{
			RedirectUris = new List<string>();
			Scopes = new Dictionary<string, string>();
		}

		[JsonIgnore]
		public string RedirectUri
		{
			get 
			{
				var list = RedirectUris.ToList();
				if (list.Count == 0)
					return "";
				else
					return list[0]; 
			}
			set
			{
				var list = RedirectUris.ToList();
				if (list.Count == 0)
				{
					list.Add(value);
				}
				else
				{
					list[0] = value;
				}
				RedirectUris = list;
			}
		}

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "icon")]
		public string Icon { get; set; }

		[JsonProperty(PropertyName = "redirect_uris")]
		public IEnumerable<string> RedirectUris { get; set; }

		[JsonProperty(PropertyName = "scopes")]
		public IDictionary<string, string> Scopes { get; set; }
	}
}
