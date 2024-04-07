# ABP Microservice Template

This project is created with ABP Template. You can find the everything in this repo explained [here](https://blog.antosubash.com/posts/abp-microservice-series). 
There is also a [YouTube Video](https://www.youtube.com/watch?v=PFFNHQUn74A) for this project.

## Prérequis :
- .NET 8 : https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- .NET 6 : https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Tye : ``dotnet tool install -g Microsoft.Tye --version "0.11.0-alpha.22111.1"``
- Docker : https://www.docker.com/products/docker-desktop/

## Comment lancer le projet

1) Lancer Docker
2) Ouvrir un shell/powershell dans le dossier ``./docker``
3) ``docker-compose up -d`` pour lancer les services de base de données (Postgres) et de cache (Redis)
4) Lancer le projet ``shared.CollectEverything.DbMigrator``, par IDE (plante sur Rider la première fois) ou 
par ``dotnet run`` 
5) ``tye run`` à la racine du projet pour lancer l'intégralité des micro-services

## Comment développer sur le projet

Si travail sur un micro-service en particulier, il est possible de le sortir du process Tye.
Pour le faire, commenter ses lignes de configuration dans le fichier ``tye.yaml`` et le lancer par l'IDE de 
manière classique.

## Comment utiliser le project

1. Le lancer comme dans la section précédente.
2. Utiliser les projets fronts (il n'y en a pas pour le moment) ou appeler les micro-services directement.

La gateway intercepte toutes les requêtes envoyées aux micro-services. Il n'est pas possible d'en appeler 
un directement.
Par contre, ce comportement est transparent, exemple :
- J'appelle le service administration sur le port 7001.
- La gateway, sur le port 7500, intercepte la requête et la renvoie sur le service administration, port 7001 
(reverse-proxy).
- Je reçois ma réponse qui elle aussi passe par la gateway.

De manière similaire, si j'appelle un webservice quelconque sur le port de la gateway, ma requête est reçue 
et interceptée par la gateway, et renvoyée vers le bon service. <br>
Si, dans un autre cas, j'appelle le micro-service B alors que je voulais l'API du micro-service A, 
la gateway redirige aussi ma requête correctement.

## Configs

### En dev

| Service          | Port   | Username     | Password     |
|------------------|--------|--------------|--------------|
| Tye Dashboard    | 8000   |              |              |
| Authentification | 7600   | admin        | 1q2w3E*      |
| Postgre          | 5432   | postgres     | postgres     |
| Redis            | 6379   |              |              |
| Gateway          | 7500   |              |              |
| Administration   | 7001   |              |              |
| Identity         | 7002   |              |              |
| Saas             | 7003   |              |              |
| Front Blazor     | 5000   |              |              |
| Front Angular    | 4200   |              |              |
|                  | 44307  |              |              |
|                  | 44346  |              |              |

