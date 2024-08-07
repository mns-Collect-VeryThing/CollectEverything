$serviceNameInput = $args[0]
$solutionName = "CollectEverything"
$folder = $serviceNameInput.ToLower()
abp new "$solutionName.$serviceNameInput" -t module --no-ui -o services\$folder -v 8.0.2
dotnet sln ".\$solutionName.sln" add (Get-ChildItem -Path "services\$folder" -Recurse -Include *.csproj)