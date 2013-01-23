using SampleApp.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitch;
using Pitch.Models.V0_1_0;

namespace SampleApp.ViewModels
{
	public class HMacTestViewModel : BindableBase
	{
		public string HmacHeader
		{
			get
			{
				return HmacUtils.GetHmacHeader(Id, MacKey, Method, PathAndQuery, Host, Port);
			}
		}

		private string method = "GET";
		public string Method
		{
			get { return method; }
			set
			{
				SetProperty(ref method, value);
				OnPropertyChanged("HmacHeader");
			}
		}

		private string pathAndQuery = "";
		public string PathAndQuery
		{
			get { return pathAndQuery; }
			set
			{
				SetProperty(ref method, value);
				OnPropertyChanged("HmacHeader");
			}
		}

		private string host = "https://sleepydaddysoftware.tent.is";
		public string Host
		{
			get { return host; }
			set
			{
				SetProperty(ref host, value);
				OnPropertyChanged("HmacHeader");
			}
		}

		private int port = 80;
		public int Port
		{
			get { return port; }
			set
			{
				SetProperty(ref port, value);
				OnPropertyChanged("HmacHeader");
			}
		}

		private AppRegistrationResponseModel appInfo;
		public AppRegistrationResponseModel AppInfo
		{
			get { return appInfo ?? (appInfo = new AppRegistrationResponseModel()); }
			set
			{
				SetProperty(ref appInfo, value ?? new AppRegistrationResponseModel());
				OnPropertyChanged("Id");
				OnPropertyChanged("MacKeyId");
				OnPropertyChanged("MacKey");
				OnPropertyChanged("MacAlgorithm");
				OnPropertyChanged("HmacHeader");
			}
		}

		public string Id
		{
			get { return AppInfo.Id; }
			set 
			{
				AppInfo.Id = value;
				OnPropertyChanged("Id");
				OnPropertyChanged("HmacHeader");
			}
		}

		public string MacKeyId
		{
			get { return AppInfo.MacKeyId; }
			set
			{
				AppInfo.MacKeyId = value;
				OnPropertyChanged("MacKeyId");
				OnPropertyChanged("HmacHeader");
			}
		}

		public string MacKey
		{
			get { return AppInfo.MacKey; }
			set
			{
				AppInfo.MacKey = value;
				OnPropertyChanged("MacKey");
				OnPropertyChanged("HmacHeader");
			}
		}

		public string MacAlgorithm
		{
			get { return AppInfo.MacAlgorithm; }
			set
			{
				AppInfo.MacAlgorithm = value;
				OnPropertyChanged("MacAlgorithm");
				OnPropertyChanged("HmacHeader");
			}
		}

		
		private string appInfoJson;
		public string AppInfoJson
		{
			get { return appInfoJson; }
			set
			{
				SetProperty(ref appInfoJson, value);
				try
				{
					AppInfo = JsonConvert.DeserializeObject<AppRegistrationResponseModel>(value);
				}
				catch
				{
					AppInfo = null;
				}
			}
		}
	}
}
