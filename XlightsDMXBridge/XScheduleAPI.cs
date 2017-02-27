using System;
using System.Net;
using System.Net.Sockets;
using XlightsDMXBridge.Shared;

namespace XlightsDMXBridge
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
			var authenticationResult =  XlightsDMXBridge.Shared.RestSharp.RestfulGET<Shared.AuthenticationResult>(resource, BaseEndpoint);
		 	if (authenticationResult.Result != "ok")
			{
				resource = string.Format("xScheduleLogin?Credential={0}", (authenticationResult.IpAddress + Password).GenerateMD5hash());
				authenticationResult = XlightsDMXBridge.Shared.RestSharp.RestfulGET<Shared.AuthenticationResult>(resource, BaseEndpoint);

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
			var resultstr = Query(GETPLAYINGSTATUS, null);
			var b = resultstr;
			var result = Query<GetPlayingStatusResult>(GETPLAYINGSTATUS, null);
			return result;
		}

		/*
 
	
		GetPlayingStatus
			- This API tells you all about what the scheduler is playing right now. Data includes:
				- Status - Idle, Paused, Playing
				- PlayList and PlayListId - the name and unique id of the playlist that is active. (valid for this session only)
				- PlayListLooping - an indicator that the playlist is looping
				- PlayListLoopsLeft - how many playlist loops are left is this has been specified
				- random - flag indicating if we are playing steps randomly from the playlist
				- Step and stepid - the name and unique id of the currently playing step. (valid for this session only)
				- steplooping - an indicator that this step is looping
				- steploopsleft - the number of times more that this step will loop if it has been specified
				- length - length of the current step
				- position - how far into the current step we are
				- left - how much time is left in the current step
				- trigger - why we are playing this - Manual/Queued/Scheduled
				- schedulename and scheduleid - the name and unique id of the currently active schedule (valid for this session only). While multiple schedules can be active only this one is the one that is actually playing. All others are suspended.
				- scheduleend - when the schedule will finish running - the schedule will enter its end state at this time ... not just stop suddenly.
				- nextstep and next stepid - the next step that will play (where known) (valid for this session only)
				- version - the xlights version number of the server
				- queuelength - where playing a queue how many songs are currently in the queue
				- volume - the current volume setting
				- time - the time on the server
				- ip - the ip of the client as seen by the server
				- outputtolights - an indicator of whether data is being sent to the lights
				
		GetButtons
			- This returns a list of user defined button labels which the user has setup. The UI can use the "PressButton" command to cause the scheduler to process the command as if the user had pressed it. This allows a website to show the same user defined buttons on a webpage.

		*/
		protected T Query<T>(string query, string parameters) {
			string resource = string.Format("xScheduleQuery?Query={0}&Parameters={1}", WebUtility.UrlEncode(query), WebUtility.UrlEncode(parameters));
			return XlightsDMXBridge.Shared.RestSharp.RestfulGET<T>(resource, BaseEndpoint);
		}
		protected string Query(string query, string parameters) { 
			string resource = string.Format("xScheduleQuery?Query={0}&Parameters={1}", WebUtility.UrlEncode(query), WebUtility.UrlEncode(parameters));
			return XlightsDMXBridge.Shared.RestSharp.RestfulGET(resource, BaseEndpoint);
		}
		/*

		*/
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
