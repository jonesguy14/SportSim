using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;

namespace SportSim
{
	[Activity (Label = "SportSim", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		string userTeam;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//League league = new League ();
			Spinner chooseTeamSpinner = FindViewById<Spinner> (Resource.Id.chooseTeamSpinner);
			chooseTeamSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (chooseTeamSpinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.teams_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			chooseTeamSpinner.Adapter = adapter;

			// Get our button from the layout resource,
			// and attach an event to it
			Button beginSeasonButton = FindViewById<Button> (Resource.Id.beginSeasonButton);
			beginSeasonButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(SeasonActivity));
				intent.PutExtra("userTeam", userTeam);
				StartActivity(intent);
			};
		}

		private void chooseTeamSpinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			userTeam = (string)spinner.GetItemAtPosition (e.Position);
			string toast = string.Format ("Your team is {0}", userTeam);
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}

	}
}


