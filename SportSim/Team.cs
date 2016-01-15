using System;

namespace SportSim
{
	public class Team
	{
		public string name;
		public int prestige;
		public bool userControlled;
		public Team (string tName, int tPrestige, bool isUserControlled)
		{
			name = tName;
			prestige = tPrestige;
			userControlled = isUserControlled;
		}
	}
}

