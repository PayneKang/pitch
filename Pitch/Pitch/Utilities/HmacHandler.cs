using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace TentLib
{
	public class HmacHandler : MessageProcessingHandler
	{
		private readonly string id;
		private readonly string hashKey;
		private readonly Random random;
		private readonly StringBuilder sb;

		public HmacHandler(HttpMessageHandler innerHandler,
				string id, string hashKey)
			: base(innerHandler)
		{
			this.id = id;
			this.hashKey = hashKey;
			this.random = new Random();
			this.sb = new StringBuilder();
		}


		protected override HttpRequestMessage ProcessRequest(
				HttpRequestMessage request,
				System.Threading.CancellationToken cancellationToken)
		{
			var signedHeader = HmacUtils.GetHmacHeader(
				id, hashKey, request.Method.Method, request.RequestUri.PathAndQuery, 
				request.RequestUri.Host, request.RequestUri.Port);

			request.Headers.Add("Authorization", signedHeader);

			return request;
		}

		protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, System.Threading.CancellationToken cancellationToken)
		{
			// TODO: validate response signature
			return response;
		}
	}
}
