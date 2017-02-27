	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;

	namespace XlightsACNBridge.Shared
	{
		public class PlayListQueryResult
		{
			[JsonProperty("playlists", Required = Required.Default)]
			public List<QueryListItem> Playlists
			{
				get;
				set;
			}
		}
		public class PlaylistStepsQueryResult
		{
			[JsonProperty("steps", Required = Required.Default)]
			public List<QueryListItem> Steps
			{
				get;
				set;
			}
		}
		public class GetMatricesResult
		{

			[JsonProperty("matrices", Required = Required.Default)]
			public List<string> Matrices
			{
				get;
				set;
			}
		}
	public class GetButtonsResult
	{

		[JsonProperty("buttons", Required = Required.Default)]
		public List<string> Buttons
		{
			get;
			set;
		}
	}

	public class GetSchedulesResult
		{
			
			[JsonProperty("schedules", Required = Required.Default)]
			public List<ScheduleListItem> Schedules
			{
				get;
				set;
			}

		}
	public class GetPlayingStatusResult { 
		[JsonProperty("outputtolights", Required = Required.Default)]
		public bool	 OutputToLights
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
		[JsonProperty("time", Required = Required.Default)]
		public DateTime Time
		{
			get;
			set;
		}
		[JsonProperty("volume", Required = Required.Default)]
		public int Volume
		{
			get;
			set;
		}
		[JsonProperty("queuelength", Required = Required.Default)]
		public int QueueLength
		{
			get;
			set;
		}
		[JsonProperty("version", Required = Required.Default)]
		public string Version
		{
			get;
			set;
		}
		[JsonProperty("nextstepid", Required = Required.Default)]
		public string NextStepId
		{
			get;
			set;
		}
		[JsonProperty("nextstep", Required = Required.Default)]
		public string NextStep
		{
			get;
			set;
		}
		[JsonProperty("scheduleid", Required = Required.Default)]
		public string ScheduleId
		{
			get;
			set;
		}
		[JsonProperty("scheduleend", Required = Required.Default)]
		public string ScheduleEnd
		{
			get;
			set;
		}
		[JsonProperty("schedulename", Required = Required.Default)]
		public string ScheduleName
		{
			get;
			set;
		}
		[JsonProperty("trigger", Required = Required.Default)]
		public string Trigger
		{
			get;
			set;
		}

		[JsonProperty("status", Required = Required.Default)]

	public string Status
		{
			get;
			set;
		}

		[JsonProperty("playlist", Required = Required.Default)]

		public string Playlist
		{
			get;
			set;
		}
	 [JsonProperty("playlistid", Required = Required.Default)]

		public string PlayListId
		{
			get;
			set;
		}

		[JsonProperty("playlistlooping", Required = Required.Default)]
		public bool PlayListLooping
		{
			get;
			set;
		}

		[JsonProperty("playlistloopsleft", Required = Required.Default)]

		public int PlayListLoopsLeft
		{
			get;
			set;
		}
		[JsonProperty("random", Required = Required.Default)]
		public bool Random
		{
			get;
			set;
		}
		[JsonProperty("step", Required = Required.Default)]

		public string Step
		{
			get;
			set;
		}
		[JsonProperty("stepid", Required = Required.Default)]

		public string StepId
		{
			get;
			set;
		}
		[JsonProperty("steplooping", Required = Required.Default)]
		public bool StepLooping
		{
			get;
			set;
		}

		[JsonProperty("steploopsleft", Required = Required.Default)]

		public int StepLoopsLeft
		{
			get;
			set;
		}
		[JsonProperty("length", Required = Required.Default)]

		public string Length
		{
			get;
			set;
		}
		[JsonProperty("position", Required = Required.Default)]

		public string Position
		{
			get;
			set;
		}
		[JsonProperty("left", Required = Required.Default)]

		public string Left
		{
			get;
			set;
		}
	}
			public class QueryListItemBase
			{

				[JsonProperty("name", Required = Required.Default)]

				public string Name
				{
					get;
					set;
				}

				[JsonProperty("id", Required = Required.Default)]
				public string Id
				{
					get;
					set;
				}

			}
			public class QueryListItem : QueryListItemBase
			{


				[JsonProperty("length", Required = Required.Default)]
				public string Length
				{
					get;
					set;
				}
			}

			public class ScheduleListItem : QueryListItemBase
			{
				[JsonProperty("enabled", Required = Required.Default)]
				public bool Enabled
				{
					get;
					set;
				}
				[JsonProperty("active", Required = Required.Default)]
				public bool Active
				{
					get;
					set;
				}
				[JsonProperty("looping", Required = Required.Default)]
				public bool Looping
				{
					get;
					set;
				}
				[JsonProperty("random", Required = Required.Default)]
				public bool Random
				{
					get;
					set;
				}
				[JsonProperty("loops", Required = Required.Default)]
				public int Loops
				{
					get;
					set;
				}
				[JsonProperty("nextactive", Required = Required.Default)]
				public string NextActive
				{
					get;
					set;
				}
				[JsonProperty("scheduleend", Required = Required.Default)]
				public string ScheduleEnd
				{
					get;
					set;
				}
			}
		}
	 
