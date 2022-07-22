using System.Text.Json;
using APIWebNET_jsonFile.ClassesData;

namespace APIWebNET_jsonFile.ClassesControllers;

public class TempsController
{
	#region Fields

	private static string pathTemps = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Temps.json");

	#endregion



	#region Methods sync

	// Routes

	public static TempsListReturn GetAll()
	{
		// Lire le fichier
		List<Temps> listeTemps = ReadFile();

		// Renvoyer l'info
		return new($"Nombre d'entrées : {listeTemps.Count}", listeTemps);
	}

	public static TempsReturn GetOne(int entier)
	{
		// Obtenir la liste
		List<Temps> listeTemps = ReadFile();

		// Y chercher l'item (v1)
		//Temps obj = null;
		//for (int i = 0; i < listeTemps.Count; i++)
		//{
		//	if (listeTemps[i].Entier == entier)
		//	{
		//		obj = listeTemps[i];
		//		break;
		//	}
		//}

		// Y chercher l'item (v2)
		Temps obj = listeTemps.Find((el) => el.Entier == entier);

		// Renvoyer l'info
		return new("Objet trouvé", obj);
	}

	public static TempsReturn PostOne(Temps temps)
	{
		// Obtenir toute la liste
		List<Temps> listeTemps = ReadFile();

		// Si la liste contient déjà un tel Entier, erreur - v1
		//for (int i = 0; i < listeTemps.Count; i++)
		//{
		//	if (listeTemps[i].Entier == temps.Entier)
		//	{
		//		return new("Erreur",null);
		//	}
		//}

		// Si la liste contient déjà un tel Entier, erreur - v2
		if (listeTemps.Find((el) => el.Entier == temps.Entier) != null) return new("Erreur",null);

		// Ici, ok. On peut ajouter l'objet à la liste
		listeTemps.Add(temps);

		// Enregistrer le fichier
		WriteFile(listeTemps);

		// Renvoyer l'info
		return new("Objet envoyé", temps);
	}

	public static TempsReturn PutOne(Temps temps)
	{
		// On passe un objet Temps. Il possède une propriété Entier.
		// Avec ça, chercher si l'objet à modifier dans lel fichier existe.
		
		// Obtenir toute la liste
		List<Temps> listeTemps = ReadFile();

		// Y chercher l'item.
		bool ok = false;
		for (int i = 0; i < listeTemps.Count; i++)
		{
			if (listeTemps[i].Entier == temps.Entier)
			{
				listeTemps[i] = temps; // Remplacer par celui passé en paramètre
				ok = true;
				break;
			}
		}

		// Si rien n'est trouvé, alors erreur
		if(!ok)	return new("Erreur", null);

		// Ici, ok.
		
		// Enregistrer le fichier avec la liste modifiée 
		WriteFile(listeTemps);

		// Renvoyer l'info
		return new("Objet modifié", temps);
	}

	public static TempsReturn DeleteOne(int entier)
	{
		// Obtenir toute la liste
		List<Temps> listeTemps = ReadFile();

		// Chercher par entier - v1
		Temps obj = null;
		for (int i = 0; i < listeTemps.Count; i++)
		{
			if (listeTemps[i].Entier == entier)
			{
				obj = listeTemps[i]; // Conserver
				listeTemps.Remove(listeTemps[i]); // Supprimer de la liste
				break;
			}
		}

		// Si pas ok, renvoyer erreur
		if (obj == null) return new("Valeur introuvable", null);

		// Ici ok
		
		// Enregistrer le fichier avec la liste modifiée précédemment
		WriteFile(listeTemps);

		// Renvoyer l'info
		return new("Objet supprimé", obj);
	}

	// File 

	private static List<Temps> ReadFile()
	{
		// Lire le fichier de données
		using (StreamReader r = new StreamReader(pathTemps))
		{
			// En faire un json
			string jsonString = r.ReadToEnd();

			// Convertir en liste d'objets
			var listeTemps = JsonSerializer.Deserialize<List<Temps>>(jsonString);

			// Renvoyer
			return listeTemps;
		}
	}

	private static void WriteFile(List<Temps> listTemps)
	{
		// Enregistrer le fichier avec la liste 
		using (StreamWriter r = new StreamWriter(pathTemps))
		{
			// Sérialiser le contenu
			string toWrite = JsonSerializer.Serialize(listTemps);

			// Ecrire
			r.Write(toWrite);
		}
	}

	#endregion
}
