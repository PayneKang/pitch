using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Models.V0_1_0
{
	public class AppRegistrationResponseModel : AppRegistrationRequestModel
	{
		[JsonIgnore]
		public string OriginalResponse { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public long CreatedAt { get; set; }

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "mac_key_id")]
		public string MacKeyId { get; set; }

		[JsonProperty(PropertyName = "mac_key")]
		public string MacKey { get; set; }

		[JsonProperty(PropertyName = "mac_algorithm")]
		public string MacAlgorithm { get; set; }

		[JsonProperty(PropertyName = "authorizations")]
		IEnumerable<string> Authorizations { get; set; }
	}
}
