$serviceNameInput = $args[0]
$solutionName = "CollectEverything"
$folder = $serviceNameInput.ToLower()
abp new "$solutionName.$serviceNameInput" -t module --no-ui -o services\$folder
dotnet sln ".\$solutionName.sln" add (Get-ChildItem -Path "services\$folder" -Recurse -Include *.csproj)