using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Models.V0_1_0.StandardPostTypes
{
	public class Status
	{
		[JsonProperty(PropertyName="text")]
		public string Text { get; set; }

		[JsonProperty(PropertyName="location")]
		public JObject Location { get; set; }
	}
}
