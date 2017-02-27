using System;
using System.Net;
using System.Net.Sockets;
using XlightsACNBridge.Shared; 

namespace XlightsACNBridge
{
	public class XScheduleAPI
	{

		public XScheduleAPI(string url)
		{
			BaseEndpoint = url;
			IsLocalAddress = (url.Contains("localhost") || url.Contains("127.0.0.1"));

		}

		#region Properties

		public string BaseEndpoint
		{
			get;
			private set;
		}
		public bool IsLocalAddress
		{
			get;
			private set;
		}

		#endregion
		public void Authenticate(string Password)
		{
			string resource = string.Format("xScheduleLogin?Credential={0}",( (IsLocalAddress ? "127.0.0.1" : GetLocalIPAddress())  + "+" + Password).GenerateMD5hash() );
			var authenticationResult =  XlightsACNBridge.Shared.RestSharp.RestfulGET<Shared.AuthenticationResult>(resource, BaseEndpoint);
		 	if (authenticationResult.Result != "ok")
			{
				resource = string.Format("xScheduleLogin?Credential={0}", (authenticationResult.IpAddress + Password).GenerateMD5hash());
				authenticationResult = XlightsACNBridge.Shared.RestSharp.RestfulGET<Shared.AuthenticationResult>(resource, BaseEndpoint);

				if (authenticationResult.Result != "ok")
				{
					throw new ArgumentException(authenticationResult.Message);
				}
			}
	 	}
		const string GETPLAYLISTS = "GetPlayLists";
		const string GETPLAYLISTSTEPS = "GetPlayListSteps";
		const string GETQUEUEDSTEPS = "GetQueuedSteps";
		const string GETMATRICES = "GetMatrices";
		const string GETPLAYLISTSCHEDULES = "GetPlayListSchedules";
		const string GETPLAYLISTSCHEDULE = "GetPlayListSchedule";
		const string GETPLAYINGSTATUS = "GetPlayingStatus";
		const string GETBUTTONS = "GetButtons";

		public PlayListQueryResult GetPlayLists() {
			return  Query<PlayListQueryResult>(GETPLAYLISTS, null);
			 
		}

		public PlaylistStepsQueryResult GetPlayListSteps(string playlistName)
		{
			var result =  Query<PlaylistStepsQueryResult>(GETPLAYLISTSTEPS, playlistName);
			return result;
		}

		public PlaylistStepsQueryResult GetQueuedSteps()
		{
			var result = Query<PlaylistStepsQueryResult>(GETQUEUEDSTEPS, null);
			return result;
		}

		public GetMatricesResult GetMatrices()
		{
			var result = Query<GetMatricesResult>(GETMATRICES, null);
			return result;
		}

		public GetSchedulesResult GetPlayListSchedules(string playlistName) { 
			var result = Query<GetSchedulesResult>(GETPLAYLISTSCHEDULES, playlistName);
			return result;
		}

		public ScheduleListItem GetPlayListSchedule(string playlistName, string scheduleName) { 
			var result = Query<ScheduleListItem>(GETPLAYLISTSCHEDULE, playlistName + "," + scheduleName);
			return result;
		}

		public GetPlayingStatusResult GetPlayingStatus() { 
			
			var result = Query<GetPlayingStatusResult>(GETPLAYINGSTATUS, null);
			return result;
		}

		public GetButtonsResult GetButtons() {
			var result = Query<GetButtonsResult>(GETBUTTONS, null);
			return result;
		}

		/*
 
	
 
		
		*/
		protected T Query<T>(string query, string parameters) {
			string resource = string.Format("xScheduleQuery?Query={0}&Parameters={1}", WebUtility.UrlEncode(query), WebUtility.UrlEncode(parameters));
			return XlightsACNBridge.Shared.RestSharp.RestfulGET<T>(resource, BaseEndpoint);
		}
		protected string Query(string query, string parameters) { 
			string resource = string.Format("xScheduleQuery?Query={0}&Parameters={1}", WebUtility.UrlEncode(query), WebUtility.UrlEncode(parameters));
			return XlightsACNBridge.Shared.RestSharp.RestfulGET(resource, BaseEndpoint);
		}
		protected T Command<T>(string command, string parameters)
		{
			string resource = string.Format("xScheduleCommand?Command={0}&Parameters={1}", WebUtility.UrlEncode(command), WebUtility.UrlEncode(parameters));
			return XlightsACNBridge.Shared.RestSharp.RestfulGET<T>(resource, BaseEndpoint);
		}
		protected string Command(string command, string parameters)
		{
			string resource = string.Format("xScheduleCommand?Command={0}&Parameters={1}", WebUtility.UrlEncode(command), WebUtility.UrlEncode(parameters));
			return XlightsACNBridge.Shared.RestSharp.RestfulGET(resource, BaseEndpoint);
		}
		protected string Stash(string command, string key)
		{
			string resource = string.Format("xScheduleStash?Command={0}&Key={1}", WebUtility.UrlEncode(command), WebUtility.UrlEncode(key));
			return XlightsACNBridge.Shared.RestSharp.RestfulGET(resource, BaseEndpoint);
		}
		 
		#region Private Methods
		private static string GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					return ip.ToString();
				}
			}
			throw new Exception("Local IP Address Not Found!");
		}
		#endregion	
	}

}
