using System;
using Gtk;

namespace XlightsACNBridge
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			XScheduleAPI api = new XScheduleAPI("http://localhost:8080");
			api.Authenticate("Password123!");
			//var  pl = api.GetPlayLists();
			//api.GetPlayListSteps(pl.Playlists[0].Name);
			//api.GetQueuedSteps();
			//api.GetMatrices();
			//var sched = api.GetPlayListSchedules(pl.Playlists[0].Name);
			//api.GetPlayListSchedule(pl.Playlists[0].Name,sched.Schedules[0].Name);
			//api.GetPlayingStatus();
			api.GetButtons();
//Application.Init();
//			MainWindow win = new MainWindow();
//			win.Show();
//			Application.Run();
		}
	}
}
