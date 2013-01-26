using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pitch.Models.V0_1_0.StandardPostTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Models.V0_1_0
{
	public class Post
	{
		[JsonProperty(PropertyName="id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName="entity")]
		public string Entity { get; set; }

		[JsonProperty(PropertyName="published_at")]
		public int PublishedAt { get; set; }

		[JsonProperty(PropertyName="received_at")]
		public int ReceivedAt { get; set; }

		//[JsonProperty(PropertyName="mentions")]
		//public IEnumerable<JObject> Mentions { get; set; }

		//[JsonProperty(PropertyName="licenses")]
		//public IEnumerable<JObject> Licenses { get; set; }

		[JsonProperty(PropertyName="type",Required=Required.Always)]
		public string Type { get; set; }

		[JsonProperty(PropertyName="content",Required=Required.Always)]
		public JObject Content { get; set; }

		public Status StatusContent
		{
			get
			{
				if (Content != null
					&& (String.Equals(Type, PostTypes.TYPE_STATUSv010)
					 || String.Equals(Type, PostTypes.TYPE_STATUSv020)))
				{
					return Content.ToObject<Status>();
				}
				else
				{
					return null;
				}
			}
		}

		//[JsonProperty(PropertyName="attachments")]
		//public IEnumerable<JObject> Attachments { get; set; }

		//[JsonProperty(PropertyName="app")]
		//public JObject App { get; set; }

		//[JsonProperty(PropertyName="views")]
		//public JObject Views { get; set; }

		//[JsonProperty(PropertyName="permissions")]
		//public JObject Permissions { get; set; }
	}
}
