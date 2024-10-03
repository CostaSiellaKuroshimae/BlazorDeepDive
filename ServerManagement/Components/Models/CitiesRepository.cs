namespace ServerManagement.Components.Models
{
	public static class CitiesRepository
	{
		private static List<string> cities = new List<string>

		{
			"Toronto",
			"Montreal",
			"Ottawa",
			"Calgary",
			"Halifax",
			"Chicago",
			"Indianapolis"
		};

		public static List<string> GetCities { get { return cities; } }
	}
}
