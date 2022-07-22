namespace APIWebNET_jsonFile.ClassesData
{
	public class TempsReturn
	{
		#region Properties

		public string Message { get; set; }
		public Temps Contenu { get; set; }

		#endregion



		#region Constructors

		public TempsReturn(string message, Temps temps)
		{
			Message = message;
			Contenu = temps;
		}

		#endregion
	}
}
