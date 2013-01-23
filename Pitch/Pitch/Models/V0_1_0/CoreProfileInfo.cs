using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Models.V0_1_0
{
	public class CoreProfileInfo
	{
		//public CoreProfileInfo() { }
		//public CoreProfileInfo(JObject coreInfo)
		//{
		//	Entity = (string)coreInfo["entity"];
		//	Licenses = coreInfo.GetTentLicenses();
		//	Servers = ((JArray)coreInfo["servers"]).Select(x => (string)x);
		//	Permissions = coreInfo.GetTentPermissions();
		//	Version = coreInfo.GetTentVersion();
		//	TentVersion = (string)coreInfo["tent_version"];
		//}

		[JsonProperty(PropertyName = "entity")]
		public string Entity { get; set; }

		[JsonProperty(PropertyName = "licenses")]
		public IEnumerable<string> Licenses { get; set; }

		[JsonProperty(PropertyName = "servers")]
		public IEnumerable<string> Servers { get; set; }

		[JsonProperty(PropertyName = "permissions")]
		public IDictionary<string, bool> Permissions { get; set; }

		[JsonProperty(PropertyName = "version")]
		public int Version { get; set; }

		[JsonProperty(PropertyName = "tent_version")]
		public string TentVersion { get; set; }
	}
}
