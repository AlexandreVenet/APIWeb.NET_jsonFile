# APIWeb.NET_jsonFile

API de type ASP.NET Core minimale avec gestion de fichier json.

Cette application .NET 6 C# est de type **ASP.NET Core API minimale**. 

Pour être minimale, lors de la création de solution, la case à cocher `Utiliser des contrôleurs` a été décochée.

Références utilisées :
- [Microsoft Docs - Web API minimale](https://docs.microsoft.com/fr-fr/learn/modules/build-web-api-minimal-api/4-advanced-commands "Microsoft Learn - Web API minimale"),
- [Microsoft Docs - ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio "ASP.NET Core").

Au lancement du programme, le navigateur s'ouvre. Par défaut, Swagger est activé et s'ouvre à cette adresse : 
```
https://localhost:<port>/swagger
```

Pour tester les routes GET en dehors de Swagger, il suffit d'entrer les routes directement dans la barre d'adresse du navigateur. 

Le fichier de projet est modifié (double-clic sur son nom dans l'Explorateur de solution). 
```xml
<Nullable>disable</Nullable>
```

Le fichier de données est au format JSON. Ce fichier est toujours modifié lorsque l'application est lancée, y compris à partir de Visual Studio.

