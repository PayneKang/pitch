using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Models.V0_1_0
{
	public class Permissions
	{
		[JsonProperty(PropertyName="public")]
		public bool Public { get; set; }
	}
}
