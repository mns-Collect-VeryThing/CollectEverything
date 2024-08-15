# ABP Microservice Template

This project is created with ABP Template. You can find the everything in this repo explained [here](https://blog.antosubash.com/posts/abp-microservice-series). 
There is also a [YouTube Video](https://www.youtube.com/watch?v=PFFNHQUn74A) for this project.

## Prérequis :
- .NET 8 : https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- .NET 6 : https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Docker : https://www.docker.com/products/docker-desktop/
- ABP CLI : ``dotnet tool install -g volo.abp.cli --version "8.0.2"``

## Comment lancer le projet

1) Se placer à la racine du projet
2) ~~``abp install-libs`` pour installer les dépendances NPM~~
3) Se placer dans le dossier ./docker
4) ``docker compose -f .\docker-compose.yaml up -d --build`` pour lancer tous les services

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

| Service          | Port        | Username     | Password     |
|------------------|-------------|--------------|--------------|
| Authentification | 7600 + 7601 | admin        | 1q2w3E*      |
| Postgre          | 5432        | postgres     | postgres     |
| Redis            | 6379        |              |              |
| Gateway          | 7500 + 7501 |              |              |
| Administration   | 7001 + 7101 |              |              |
| Identity         | 7002 + 7102 |              |              |
| Saas             | 7003 + 7103 |              |              |
| Product          | 7004 + 7104 |              |              |
| Commandes        | 7005 + 7105 |              |              |
| Shops            | 7006 + 7106 |              |              |
| Front Blazor     | 5000 + 5001 |              |              |
