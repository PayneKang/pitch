using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Models
{
	public class Profile
	{
		/*
		 * {
"https://tent.io/types/info/basic/v0.1.0": {
"name": "Sleepy Daddy Software™",
"avatar_url": "https://twimg0-a.akamaihd.net/profile_images/1169617834/69fe09b1-a01b-4dcf-8da3-f86c9d32081b_normal.JPG",
"birthdate": "",
"location": "",
"gender": "",
"bio": "",
"website_url": "",
"permissions": {
	"public": true
},
"version": 4
},
"https://tent.io/types/info/core/v0.1.0": {
"entity": "https://sleepydaddysoftware.tent.is",
"licenses": [],
"servers": [
	"https://sleepydaddysoftware.tent.is/tent"
],
"permissions": {
	"public": true
},
"version": 1,
"tent_version": "0.2"
}
}
		 */
		//public static bool TryParse(string content, out Profile profile)
		//{
		//	profile = new Profile();
		//	profile.Original = content;
		//	try
		//	{
		//		JObject root = JObject.Parse(content);
		//		profile.BasicInfo_v0_1_0 = new Pitch.Models.V0_1_0.BasicProfileInfo((JObject)root[InfoTypes.TYPE_BASIC_V0_1_0]);
		//		profile.CoreInfo_v0_1_0 = new Pitch.Models.V0_1_0.CoreProfileInfo((JObject)root[InfoTypes.TYPE_CORE_V0_1_0]);
		//	}
		//	catch
		//	{
		//		profile = null;
		//		return false;
		//	}
		//	return true;
		//}

		//public string Original { get; private set; }

		//public Profile() { }
		//public Profile(string profile)
		//{
		//	Original = profile;
		//}

		[JsonProperty(PropertyName = InfoTypes.TYPE_BASIC_V0_1_0)]
		public Pitch.Models.V0_1_0.BasicProfileInfo BasicInfo_v0_1_0 { get; set; }

		[JsonProperty(PropertyName = InfoTypes.TYPE_CORE_V0_1_0)]
		public Pitch.Models.V0_1_0.CoreProfileInfo CoreInfo_v0_1_0 { get; set; }
	}
}
