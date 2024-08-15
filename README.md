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

## Comment ajouter un nouveau microservice

Basé sur le tutoriel là : https://blog.antosubash.com/posts/netcore-microservice-with-abp-add-new-service-part-11

Pourun exemple, voir la pull request là : https://github.com/mns-Collect-VeryThing/CollectEverything/pull/15

1) Exécuter le script ``create-new-service.ps1`` avec le nom du service en paramètre. Exemple : ``./create-new-service.ps1 Shops``
2) Supprimer les projets créés inutiles : AuthServer, Installer, MongoDB, MongoDB.Tests 
3) Mettre à jour les dépendences du nouveau service (HttpApiHostModule)
4) Configurer le service pour qu'il utilise un format de date compatible avec PostgreSQL
5) Désactiver les CORS (ou les configurer correctement)
6) Enlever l'ancienne conf de connection à la base de données
7) Activer les "Auto-APIs" (Appservice = Controller)
8) Désactiver les fichiers phyisiques dans le container
9) Retirer les dossiers EfCore et Migrations du service
10) Mettre à jour le appsettings.json du service
11) Créer le Dockerfile
12) Activer les repositories par défaut
13) Créer la classse DbContextFactory et installer le package PostGreSQL requis
14) Retirer le package nuget SQL Server
15) Installer le package nuget EfCore.Tools 8.0.1
16) Ajouter le nom du nouveau service aux DNS autorisés dans la configuration du certificat auto-signé
17) Générer le nouveau certificat depuis un cmd OpenSSL ``openssl req -x509 -new -nodes -key myprivatekey.key -sha256 -days 365 -out certificate.crt -config openssl.cnf`` puis ``openssl pkcs12 -export -out certificate.pfx -inkey myprivatekey.key -in certificate.crt -certfile intermediate.crt``
18) Ajouter le nouveau service au docker-compose
19) Ajouter le nouveau service à la gateway
20) Ajouter le nouveau service au DbMigrator : appsettings.json, Dockerfile, classes DbMigratorService, DbMigratorModule
21) Ajouter le nouveau service au AdministrationHttpApiHostModule
