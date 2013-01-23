using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentLib.Models.V0_1_0
{
	public class BasicProfileInfo
	{
		public BasicProfileInfo()
		{

		}

		//public BasicProfileInfo(JObject basicInfo)
		//{
		//	Name = (string)basicInfo["name"];
		//	AvatarUrl = (string)basicInfo["avatar_url"];
		//	BirthDate = (string)basicInfo["birthdate"];
		//	Location = (string)basicInfo["location"];
		//	Gender = (string)basicInfo["gender"];
		//	Bio = (string)basicInfo["bio"];
		//	WebsiteUrl = (string)basicInfo["website_url"];
		//	Permissions = basicInfo.GetTentPermissions();
		//	Version = basicInfo.GetTentVersion();
		//}

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "avatar_url")]
		public string AvatarUrl { get; set; }

		[JsonProperty(PropertyName = "birthdate")]
		public string BirthDate { get; set; }

		[JsonProperty(PropertyName = "location")]
		public string Location { get; set; }

		[JsonProperty(PropertyName = "gender")]
		public string Gender { get; set; }

		[JsonProperty(PropertyName = "bio")]
		public string Bio { get; set; }

		[JsonProperty(PropertyName = "website_url")]
		public string WebsiteUrl { get; set; }

		[JsonProperty(PropertyName = "permissions")]
		public IDictionary<string, bool> Permissions { get; set; }

		[JsonProperty(PropertyName = "version")]
		public int Version { get; set; }
	}
}
