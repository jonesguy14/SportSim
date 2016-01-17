using System;

namespace SportSim
{
	public class Team
	{
		public string name;
		public int prestige;
		public int wins;
		public int losses;
		public bool userControlled;
		public Team (string tName, int tPrestige, bool isUserControlled)
		{
			name = tName;
			prestige = tPrestige;
			userControlled = isUserControlled;
			wins = 0;
			losses = 0;
		}
	}
}

