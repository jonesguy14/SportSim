using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SportSim
{
	[Activity (Label = "SeasonActivity")]			
	public class SeasonActivity : Activity
	{
		Team currentTeam;
		League simLeague;
		int currTab;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Season);

			//Create your application here
			String userTeam = "ha";
			userTeam = Intent.Extras.GetString ("userTeam");

			simLeague = new League (userTeam);
			currentTeam = simLeague.leagueTeams.ElementAt (0);
			currTab = 0;

			TextView currentTeamText = FindViewById<TextView> (Resource.Id.currentTeamText);
			currentTeamText.Text = simLeague.userTeam.name;

			//Set up spinner with all teams
			Spinner examineTeamSpinner = FindViewById<Spinner> (Resource.Id.examineTeamSpinner);
			examineTeamSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (examineTeamSpinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.teams_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			examineTeamSpinner.Adapter = adapter;

			//Set up "Simulate Game" button
			Button simGameButton = FindViewById<Button> (Resource.Id.simGameButton);
			simGameButton.Click += (sender, e) =>
			{
				simLeague.simGame();
				updateCurrTeam();
			};

			//Set up "Team Stats" button
			Button teamStatsButton = FindViewById<Button> (Resource.Id.teamStatsButton);
			teamStatsButton.Click += (sender, e) =>
			{
				currTab = 0;
				updateTeamStats();
			};

			//Set up "Player Stats" button
			Button playerStatsButton = FindViewById<Button> (Resource.Id.playerStatsButton);
			playerStatsButton.Click += (sender, e) =>
			{
				currTab = 1;
				updatePlayerStats();
			};

			//Set up "Team Schedule" button
			Button teamScheduleButton = FindViewById<Button> (Resource.Id.teamScheduleButton);
			teamScheduleButton.Click += (sender, e) =>
			{
				currTab = 2;
				updateSchedule();
			};
		}

		private void examineTeamSpinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			String selTeam = (string)spinner.GetItemAtPosition (e.Position);
			currentTeam = simLeague.leagueTeams.Find (t => t.name == selTeam);
			updateCurrTeam ();
		}
			
		private void updateCurrTeam() 
		{
			TextView currentTeamText = FindViewById<TextView> (Resource.Id.currentTeamText);
			currentTeamText.Text = currentTeam.name + " (" + currentTeam.wins + "-" + currentTeam.losses + ")";
			if (currTab == 0) {
				updateTeamStats ();
			} else if (currTab == 1) {
				updatePlayerStats ();
			} else {
				updateSchedule ();
			}
		}

		private void updateTeamStats(){
			TextView textTabDescription = FindViewById<TextView> (Resource.Id.textTabDescription);
			textTabDescription.Text = currentTeam.name + " Team Stats:";
			TextView textArea = FindViewById<TextView> (Resource.Id.textAreaSeason);
			textArea.Text = "Here are team stats lol.\nHere are team stats lol.\nHere are team stats lol.\nHere are team stats lol.";
		}

		private void updatePlayerStats(){
			TextView textTabDescription = FindViewById<TextView> (Resource.Id.textTabDescription);
			textTabDescription.Text = currentTeam.name + " Player Stats:";
			TextView textArea = FindViewById<TextView> (Resource.Id.textAreaSeason);
			textArea.Text = "Here are player stats lol.\nHere are player stats lol.\nHere are player stats lol.\nHere are player stats lol.";
		}

		private void updateSchedule(){
			TextView textTabDescription = FindViewById<TextView> (Resource.Id.textTabDescription);
			textTabDescription.Text = currentTeam.name + " Team Schedule:";
			TextView textArea = FindViewById<TextView> (Resource.Id.textAreaSeason);
			textArea.Text = "Game 1\nGame 1\nGame 1\nGame 1\nGame 1\nGame 1\nGame 1\nGame 1\nGame 1\nGame 1\n";
		}

	}
}

