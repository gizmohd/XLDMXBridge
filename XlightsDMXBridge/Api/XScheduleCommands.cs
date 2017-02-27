using System;
namespace XlightsACNBridge
{
	public class XScheduleCommands
	{
		/// <summary>
		///Stops all playing playlists and all active schedules. If you have songs queued it will empty the queue.
		/// </summary>
		const string STOPALLNOW = "Stop All Now";
		/// <summary>
		/// Stops the currently playing playlist/schedule. If you have multiple active schedules then then next highest priority schedule will run.

		/// </summary>
		const string STOP = "Stop";

		/// <summary>
		/// 	This plays the currently selected playlist in the UI once. This really doesnt make sense to invoke from anything other than a button in the UI.
		/// </summary>
		const string PLAYSELECTEDPLAYLIST = "Play selected playlist";

		/// <summary>
		/// This plays the currently selected playlist in the UI and loops it. This really doesnt make sense to invoke from anything other than a button in the UI.
		/// </summary>
		const string PLAYSELECTEDPLAYLISTLOOPED = "Play selected playlist looped";

		/// <summary>
		///This plays the specified playlist once.
		/// </summary>
		const string PLAYSPECIFICEDPLAYLIST = "Play specified playlist";// <playlist name>

		/// <summary>
		/// This plays the specified playlist and loops it.
		/// </summary>
		const string PLAYSPECIFICEDPLAYLISTLOOPED = "Play specified playlist looped";// <playlist name>

		/// <summary>
		/// This stops the specified playlist if it is currently playing ... even if it is currently suspended because something higher priority is running.
		/// </summary>
		const string STOPSPECIFIEDPLAYLIST = "Stop specified playlist";// <playlist name>

		/// <summary>
		/// This stops the specified playlist if it is running but not until the currently running step completes. 
		/// </summary>
		const string STOPSPECIFIEDPLAYLISTATENDOFCURRENTSTEP = "Stop specified playlist at the end of the current step";// <playlist name>
																														/// <summary>
																														/// This stops the specified playlist if it is running but not until it reaches the end of the last step ... 
																														/// this will also trigger any steps which are tagged as only running once at the end of the playlist.
																														/// </summary>
		const string STOPSPECIFIEDPLAYLISTATENDOFCURRENTLOOP = "Stop specified playlist at the end of the current loop"; //<playlist name>

		/// <summary>
		/// This stops the currently playing playlist but not until the currently running step completes.
		/// </summary>
		const string STOPPLAYLISTATENDOFCURRENTSTEP = "Stop playlist at end of current step";

		/// <summary>
		/// This stops the currently playing playlist if it is running but not until it reaches the end of the last step ...
		/// this will also trigger any steps which are tagged as only running once at the end of the playlist.
		/// </summary>
		const string STOPPLAYLISTATENDOFCURRENTLOOP = "Stop playlist at end of current loop";

		/// <summary>
		/// This lets the current step complete in the currently playing playlist and then skips to any steps which are tagged to play once at the end of the playlist.
		/// </summary>
		const string JUMPTOPLAYONCEATENDOFCURRENTSTEPTHENSTOP = "Jump to play once at end at end of current step and then stop";
		/// <summary>
		/// Pauses the currently playing playlist
		/// </summary>
		const string PAUSE = "Pause";

		/// <summary>
		/// This immediately jumps to the next step in the currently playing playlist
		/// </summary>
		const string NEXTSTEPINCURRENTPLAYLIST = "Next step in current playlist";

		/// <summary>
		/// This jumps back the the beginning of the current step in the currently playing playlist
		/// </summary>
		const string RESTARTSTEPINCURRENTPLAYLIST = "Restart step in current playlist";

		/// <summary>
		/// This jumps back to the step that played prior to the current step in the currently playing playlist.
		/// </summary>
		const string PRIORSTEPINCURRENTPLAYLIST = "Prior step in current playlist";


		/// <summary>
		/// This stops the current step and jumps to a randomly chosen alternative step in the playlist (excluding any steps 
		/// flagged as being only played at the beginning or end of the playlist). 
		/// Randomness requires at least 4 non play-once steps or it will not act randomly
		/// </summary>
		const string JUMPTORANDOMSTEPINCURRENTPLAYLIST = "Jump to random step in current playlist";

		/// <summary>
		/// This starts the named playlist at a random step (excluding any steps flagged as being only played at the beginning or end of the playlist). 
		/// Randomness requires at least 4 non play-once steps or it will not act randomly. At the end of the step the playlist will continue to play.
		/// </summary>
		const string JUMPTORANDOMSTEPINSPECIFIEDPLAYLIST = "Jump to random step in specified playlist";// <playlist name>

		/// <summary>
		/// This jumps to the named step in the currenly playing playlist. At the end of the step the playlist will continue to play.
		/// </summary>
		const string JUMPTOSPECIFIEDSTEPINCURRENTPLAYLIST = "Jump to specified step in current playlist";// <step name>

		/// <summary>
		/// This jumps to the named step in the currently playing playlist when the current step ends. At the end of the step the playlist will continue to play.
		/// </summary>
		const string JUMPTOSPECIFIEDSTEPINCURRENTPLAYLISTATENDOFCURRENTSTEP = "Jump to specified step in current playlist at the end of current step";// <step name>

		/// <summary>
		/// This starts the named playlist at the specified step then plays it through to the end.
		/// </summary>
		const string PLAYPLAYLISTSTARTINGATSTEP = "Play playlist starting at step"; //<playlist name>,<step name>

		/// <summary>
		/// This plays just the named step in the named playlist.
		/// </summary>
		const string PLAYPLAYLISTSTEP = "Play playlist step";// <playlist name>,<step name>

		/// <summary>
		/// This plays the named playlist looping starting with the named step
		/// </summary>
		const string PLAYPLAYLISTSTARTINGATSTEPLOOPED = "Play playlist starting at step looped";// <playlist name>,<step name>

		/// <summary>
		/// This toggles the state of the loop current step flag.
		/// </summary>
		const string TOGGLELOOPCURRENTSTEP = "Toggle loop current step";


		/// <summary>
		/// This plays the named step in the named playlist repeatedly
		/// </summary>
		const string PLAYSPECIFIEDSTEPINPLAYLISTLOOPED = "Play specified step in specified playlist looped";// <playlist name>,<step name>

		/// <summary>
		/// This extends the currently active schedule the specified number of minutes. This can extend it beyond midnight if required.
		/// </summary>
		const string ADDTOTHECURRENTSCHEDULENMINUTES = "Add to the current schedule n minutes";// <minutes>

		/// <summary>
		/// Sets the volume to the specified percentage.
		/// </summary>
		const string SETVOLUME = "Set volume to";// <volume 0-100>

		/// <summary>
		/// Adjusts the volume up or down if negative by the specified amount.
		/// </summary>
		const string ADJUSTVOLUMEBY = "Adjust volume by";// <volume -100,100>

		/// <summary>
		/// This save the current state of the scheduler. It really only makes sense in the User Interface.
		/// </summary>
		const string SAVESCHEDULE = "Save schedule";

		/// <summary>
		/// This toggles whether the scheduler is actually sending data out to the lights.
		/// </summary>
		const string TOGGLEOUTPUTTOLIGHTS = "Toggle output to lights";

		/// <summary>
		/// This toggles whether the current playing playlist is in random mode. Random mode requires at least 4 steps which are not flagged as being start of show or end of show.
		/// </summary>
		const string TOGGELCURRENTPLAYLISTRANDOM = "Toggle current playlist random";

		/// <summary>
		/// This toggles whether the currently playing playlist is in looping mode.
		/// </summary>
		const string TOGGLECURRENTPLAYLISTLOOP = "Toggle current playlist loop";

		/// <summary>
		/// This will play the named step in the named playlist and then stop.
		/// </summary>
		const string PLAYSPECIFIEDPLAYLISTSTEPONCEONLY = "Play specified playlist step once only";// <playlist name>,<step name>

		/// <summary>
		/// This will play the named playlist the specified number of times.
		/// </summary>
		const string PLAYSPECIFIEDPLAYLISTNTIMES = "Play specified playlist n times";// <playlist name>,<loops>

		/// <summary>
		/// This will play the named step in the named playlist the specified number of times.
		/// </summary>
		const string PLAYSPECIFIEDPLAYLISTSTEPNTIMES = "Play specified playlist step n times";// <playlist name>,<step name>,<loops>

		/// <summary>
		/// Adjusts the global brightness level by the specified amount. 
		/// Unless you are running a fully pixel show this is unlikely to be useful as it adjusts the value of every single output channel. 
		/// To dim selected channels/elements see the schedulers output processing settings.
		/// </summary>
		const string INCREASEBRIGHTNESSBYN = "Increase brightness by n%";// <brighness -100-100>
																		 /// <summary>
																		 /// Adjusts the global brightness level to the specified level. 
																		 /// Unless you are running a fully pixel show this is unlikely to be useful as it adjusts the value of every single output channel. 
																		 /// To dim selected channels/elements see the schedulers output processing settings.
																		 /// </summary>
		const string SETBRIGHTNESSTON = "Set brightness to n%";// <brightness 0-100>

		/// <summary>
		/// This api is designed to allow web pages to expose the user defined buttons on their UI and is sent to the scheduler when the user presses the button. 
		/// It requires that the user uniquely label their buttons.
		/// </summary>
		const string PRESSBUTTON = "PressButton";// <button label>
												 /// <summary>
												 /// This API stops and reloads the currently playing schedule using any newly defined schedule configuration. 
												 /// Play is resumed from the start of the schedule. 
												 /// This is useful to quickly restart a schedule after you have changed it and would generally only be called from a button on the GUI.
												 /// </summary>
		const string RESTARTSELECTEDSCHEDULE = "Restart selected schedule";
		/// <summary>
		/// This API restarts a schedule that has been stopped allowing it to run again.
		/// Normally when a schedule is stopped it enters a stopped state and cannot be restarted until after it was scheduled to end without shutting down and restarting the entire scheduler.
		/// </summary>
		const string RESTARTNAMEDSCHEDULE = "Restart named schedule";// <schedule name>

		/// <summary>
		/// This API mutes/unmutes the audio ... remembering the volume that it was previously set to.
		/// </summary>
		const string TOGGLEMUTE = "Toggle mute";

		/// <summary>
		/// This API adds the named step in the named playlist to the list of queued songs. Steps will not be accepted if they are already the last song in the queue.
		/// </summary>
		const string ENQUEUEPLAYLISTSTEP = "Enqueue playlist step";// <playlist name>,<step name>

		/// <summary>
		/// This API clears out the list of queued songs.
		/// </summary>
		const string CLEARPLAYLISTQUEUE = "Clear playlist queue";

		/// <summary>
		/// This API stops and reloads the currently playing playlist. Play is resumed from the start of the currently playing step (assuming this step still exists in the playlist - if it doesnt the playlist plays from the start). This is useful to quickly restart a playlist after you have changed it and would generally only be called from a button on the GUI.
		/// </summary>
		const string RefreshCurrentPlaylist = "Refresh current playlist";

		/// <summary>
		/// This API is a catchall run any other command gracefully at the end of the currently playing step.
		/// </summary>
		const string RUNCOMMANDATENDOFCURRENTSTEP = "Run command at end of current step";// <command>,<parameters>

		/// <summary>
		/// This API forces the scheduler (and all its windows) into the foreground. Why? Good question ... I was asked for it.
		/// </summary>
		const string BRINGTOFOREGROUND = "Bring to foreground";



	}
}
