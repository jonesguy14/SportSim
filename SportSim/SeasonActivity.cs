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
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Season);
			
			//Create your application here
			String userTeam = "ha";
			userTeam = Intent.Extras.GetString ("userTeam");

			League simLeague = new League (userTeam);

			TextView userTeamText = FindViewById<TextView> (Resource.Id.userTeamText);
			userTeamText.Text = userTeam;
		}
	}
}

