using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace TentLib
{
	public static class HmacUtils
	{
		public static string GetNormalizedRequestString(
				string ts, string nonce, string method, string pathAndQuery, string host, int port)
		{
			var norm = new StringBuilder();
			norm.Append(ts); norm.Append('\n');
			norm.Append(nonce); norm.Append('\n');
			norm.Append(method.ToUpperInvariant()); norm.Append('\n');
			norm.Append(pathAndQuery.ToLowerInvariant()); norm.Append('\n');
			norm.Append(host.ToLowerInvariant()); norm.Append('\n');
			norm.Append(port.ToString(CultureInfo.InvariantCulture)); norm.Append('\n');
			return norm.ToString();
		}

		public static string GetNormalizedRequestString(
				string ts, string nonce, HttpRequestMessage request)
		{
			return GetNormalizedRequestString(ts, nonce,
					request.Method.ToString(),
					request.RequestUri.PathAndQuery,
					request.RequestUri.Host,
					request.RequestUri.Port);
		}

		public static string GetHmacHeader(
			string id, string hashKey, string method, string pathAndQuery, string host, int port)
		{
			var norm = new StringBuilder();
			var ts = HmacUtils.GetTs();
			var random = new Random();
			var nonce = HmacUtils.GetNonce(random);

			var stringToSign = HmacUtils.GetNormalizedRequestString(ts, nonce, method, pathAndQuery, host, port);

			var macAlgorithmProvider = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
			var encoding = BinaryStringEncoding.Utf8;
			var messageBuffer = CryptographicBuffer.ConvertStringToBinary(stringToSign, encoding);
			var keyBuffer = CryptographicBuffer.ConvertStringToBinary(hashKey, encoding);
			var hmacKey = macAlgorithmProvider.CreateKey(keyBuffer);
			var signedMessage = CryptographicEngine.Sign(hmacKey, messageBuffer);
			var mac = CryptographicBuffer.EncodeToBase64String(signedMessage);

			return String.Format(CultureInfo.InvariantCulture, "MAC id=\"{0}\", ts=\"{1}\", nonce=\"{2}\", mac=\"{3}\"",
					id, ts, nonce, mac);
		}

		public static string GetNonce(Random random)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < Miscellaneous.NONCE_LENGTH; i++)
			{
				sb.Append(
						Miscellaneous.HEX_CHARSET[
						random.Next(Miscellaneous.HEX_CHARSET.Length)]);
			}
			return sb.ToString();
		}

		public static int GetTsFromDateTime(DateTime dateTime)
		{
			return ((int)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds);
		}

		public static string GetTs()
		{
			return GetTsFromDateTime(DateTime.UtcNow)
					.ToString(CultureInfo.InvariantCulture);
		}

	}
}
