namespace APIWebNET_jsonFile.ClassesData;

public class Temps
{
	#region Properties

	public DateTime BabyDate { get; set; }
	public int Entier { get; set; }
	public string Summary { get; set; }

	#endregion



	#region Overrides

	public override string ToString()
	{
		return $"{BabyDate}, {Entier}, {Summary}";
	}

	#endregion
}
