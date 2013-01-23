using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitch.Models.V0_1_0;

namespace Pitch.Requests
{
    public static class OAuth
    {
        public static string CreateOAuthUri(string serverUri, AppRegistrationResponseModel appReg)
        {
            return String.Format(
                "{0}/oauth/authorize?client_id={1}&redirect_uri={2}&scope={3}&tent_profile_info_types=all&tent_post_types=all",
                serverUri, appReg.Id, appReg.RedirectUri, String.Join(",", appReg.Scopes.Keys));
        }
    }
}
