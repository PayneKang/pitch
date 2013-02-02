using SampleApp.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Pitch;
using Pitch.Models;
using Pitch.Models.V0_1_0;
using Pitch.Requests;

namespace SampleApp.ViewModels
{
	class TestPageViewModel : BindableBase
	{
		private string appName = "Pitch";
		public string AppName
		{
			get { return appName; }
			set { SetProperty(ref appName, value); }
		}

		private string uri = "https://sleepydaddysoftware.tent.is";
		public string URI
		{
			get { return uri; }
			set { SetProperty(ref uri, value); }
		}

		private string postText = "First post from the Pitch sample app";
		public string PostText
		{
			get { return postText; }
			set { SetProperty(ref postText, value); }
		}

		private Profile profile;
		public Profile Profile
		{
			get { return profile; }
			set { 
				SetProperty(ref profile, value);
				OnPropertyChanged("ProfileResponseAsString");
			}
		}

		private string server;
		public string Server
		{
			get { return server; }
			set { SetProperty(ref server, value); }
		}

		private AppRegistrationRequestModel CreateDefaultAppRegistration()
		{
			var ret = new AppRegistrationRequestModel();
			ret.Name = "Pitch Sample App";
			ret.Description = "Pitch development app registration.";
			ret.Url = "https://github.com/JeroMiya/pitch";
			ret.Icon = "https://twimg0-a.akamaihd.net/profile_images/116917834/69fe09b1-a01b-4dcf=8da3-f86c9d32081b_normal.JPG";
			ret.RedirectUri = "https://app.example.com/tent/callback";
			ret.Scopes["write_profile"] = "Uses an app profile section to describe foos";
			ret.Scopes["read_followings"] = "Calculates foos based on your followings";
			return ret;
		}

		private AppRegistrationRequestModel appRegistration;
		public AppRegistrationRequestModel AppRegistration
		{
			get { return appRegistration ?? (appRegistration = CreateDefaultAppRegistration()); }
			set { SetProperty(ref appRegistration, value); }
		}

		private AppRegistrationResponseModel appRegistrationResponse;
		public AppRegistrationResponseModel AppRegistrationResponse
		{
			get { return appRegistrationResponse; }
			set
			{
				SetProperty(ref appRegistrationResponse, value);
				OnPropertyChanged("AppRegistrationResponseAsString");
			}
		}

		public string ProfileResponseAsString
		{
			get {
				var ret = "";
				try {
					ret = JsonConvert.SerializeObject(Profile, Formatting.Indented);
				} catch {
					ret = "";
				}
				return ret;
			}
		}

		public string AppRegistrationResponseAsString
		{
			get {
				var ret = "";
				try {
					ret = JsonConvert.SerializeObject(AppRegistrationResponse, Formatting.Indented);
				} catch {
					ret = "";
				}
				return ret; 
			}
			set {
				try {
					var response = JsonConvert.DeserializeObject<AppRegistrationResponseModel>(value);
					if (response != null) {
						AppRegistrationResponse = response;
					}
				} catch { }
			}
		}

		private string oAuthUri;
		public string OAuthUri
		{
			get { return oAuthUri; }
			set { SetProperty(ref oAuthUri, value); }
		}

		private string oAuthCode;
		public string OAuthCode
		{
			get { return oAuthCode; }
			set { SetProperty(ref oAuthCode, value); }
		}

		private string accessTokenResponse;
		public string AccessTokenResponse
		{
			get { return accessTokenResponse; }
			set 
			{ 
				SetProperty(ref accessTokenResponse, value);
				AccessToken = JsonConvert.DeserializeObject<AccessTokenResponseModel>(value);
			}
		}

		private AccessTokenResponseModel accessToken;
		public AccessTokenResponseModel AccessToken
		{
			get { return accessToken; }
			set { SetProperty(ref accessToken, value); }
		}

		public async Task DoRequest()
		{
			Profile = await Pitch.Requests.ProfileRequest.GetProfileAsync(URI);
			Server = Profile.CoreInfo_v0_1_0.Servers.FirstOrDefault();
		}

		public async Task DoAppRegistration()
		{
			AppRegistration.Scopes["write_posts"] = "You can post things, for sure.";
			AppRegistration.Scopes["read_posts"] = "You can read your posts dude.";
			AppRegistration.Scopes["read_profile"] = "Basic read profile";
			var response = await Pitch.Requests.AppRegistrationRequest.RegisterNewAppAsync(Server, AppRegistration);
			AppRegistrationResponse = response;
			OAuthUri = OAuth.CreateOAuthUri(Server, response);
		}

		public async Task DoAccessTokenRequest()
		{
			var response = await AccessTokenRequest.RequestAccessToken(
					Server,
					AppRegistrationResponse.Id,
					AppRegistrationResponse.MacKeyId,
					AppRegistrationResponse.MacKey,
					new AccessTokenRequestModel(OAuthCode));
			AccessTokenResponse = response.OriginalResponse;
			AccessToken = response;
		}

		public async Task DoPostMessage()
		{
			if (AccessToken != null)
			{
				var post = new Pitch.Models.V0_1_0.Post();
				var status = new Pitch.Models.V0_1_0.StandardPostTypes.Status();
				status.Text = postText;
				post.StatusContent = status;
				post.Permissions = new Permissions() { Public = true };
				await PostRequest.Post(Server, post, AccessToken);
			}
		}
	}
}
