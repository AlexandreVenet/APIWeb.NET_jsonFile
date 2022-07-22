namespace APIWebNET_jsonFile.ClassesData
{
	public class TempsListReturn
	{
		#region Properties

		public string Message { get; set; }
		public List<Temps> Contenu { get; set; }

		#endregion



		#region Constructors

		public TempsListReturn(string message, List<Temps> listeTemps)
		{
			Message = message;
			Contenu = listeTemps;
		}

		#endregion
	}
}
