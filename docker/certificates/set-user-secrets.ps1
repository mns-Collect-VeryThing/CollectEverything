dotnet user-secrets init -p ../../services/administration/host/CollectEverything.Administration.HttpApi.Host/CollectEverything.Administration.HttpApi.Host.csproj
dotnet user-secrets -p ../../services/administration/host/CollectEverything.Administration.HttpApi.Host/CollectEverything.Administration.HttpApi.Host.csproj set "Kestrel:Certificates:Development:Password" "123"

dotnet user-secrets init -p ../../gateway//CollectEverything.Gateway/CollectEverything.Gateway.csproj
dotnet user-secrets -p ../../gateway//CollectEverything.Gateway/CollectEverything.Gateway.csproj set "Kestrel:Certificates:Development:Password" "123"

