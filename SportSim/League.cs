using System;
using System.Collections.Generic;

namespace SportSim
{
	public class League
	{
		public List<Team> leagueTeams;
		public League (string userTeam)
		{
			leagueTeams = new List<Team> ();
			leagueTeams.Add (new Team ("Alabama", 95, false));
			leagueTeams.Add (new Team ("Auburn", 90, false));
			leagueTeams.Add (new Team ("Florida", 90, false));
			leagueTeams.Add (new Team ("Georgia", 90, false));
			leagueTeams.Add (new Team ("LSU", 90, false));

		}
	}
}

