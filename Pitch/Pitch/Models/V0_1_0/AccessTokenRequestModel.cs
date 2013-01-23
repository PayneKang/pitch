using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Models.V0_1_0
{
    public class AccessTokenRequestModel
    {
        public AccessTokenRequestModel() { }
        public AccessTokenRequestModel(string code)
        {
            Code = code;
            TokenType = "mac";
            TentExpiresAt = HmacUtils.GetTsFromDateTime(DateTime.Now 
                + TimeSpan.FromMinutes(30));
        }

        [JsonProperty(PropertyName="code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName="token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName="tent_expires_at")]
        public int TentExpiresAt { get; set; }
    }

    public class AccessTokenResponseModel
    {
        [JsonIgnore]
        public string OriginalResponse { get; set; }

        [JsonProperty(PropertyName="access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "mac_key")]
        public string MacKey { get; set; }

        [JsonProperty(PropertyName = "mac_algorithm")]
        public string MacAlgorithm { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "tent_expires_at")]
        public int TentExpiresAt { get; set; }
    }
}
