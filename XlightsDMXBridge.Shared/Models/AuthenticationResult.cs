using System;
using Newtonsoft.Json;

namespace XlightsDMXBridge.Shared
{
	public class AuthenticationResult
	{

 		[JsonProperty("result", Required = Required.Always)]
		public string Result
		{
			get;
			set;
		}

		[JsonProperty("message", Required = Required.Default)]
		public string Message
		{
			get;
			set;
		}

		[JsonProperty("ip", Required = Required.Default)]
		public string IpAddress
		{
			get;
			set;
		}

	}
}
