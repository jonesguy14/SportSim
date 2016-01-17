using System;
using System.Collections.Generic;

namespace SportSim
{
	public class League
	{
		public List<Team> leagueTeams;
		public Team userTeam;
		public League (string userTeamStr)
		{
			leagueTeams = new List<Team> ();
			leagueTeams.Add (new Team ("Alabama", 95, false));
			leagueTeams.Add (new Team ("Auburn", 90, false));
			leagueTeams.Add (new Team ("Florida", 90, false));
			leagueTeams.Add (new Team ("Georgia", 90, false));
			leagueTeams.Add (new Team ("LSU", 90, false));

			userTeam = leagueTeams.Find (t => t.name == userTeamStr);
		}

		public void simGame() {
			Random random = new Random ();
			foreach (Team t in leagueTeams) {
				int wl = random.Next (0, 2);
				if (wl == 1) {
					t.wins++;
				} else {
					t.losses++;
				}
			}
		}
	}
}

