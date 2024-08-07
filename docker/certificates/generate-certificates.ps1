dotnet dev-certs https -ep .\CollectEverything.Administration.HttpApi.Host\CollectEverything.Administration.HttpApi.Host.pfx -p 123 --trust
dotnet dev-certs https -ep .\CollectEverything.Gateway\CollectEverything.Gateway.pfx -p 123 --trust
dotnet dev-certs https -ep .\CollectEverything.AuthServer\CollectEverything.AuthServer.pfx -p 123 --trust
dotnet dev-certs https -ep .\CollectEverything.Product.HttpApi.Host\CollectEverything.Product.HttpApi.Host.pfx -p 123 --trust