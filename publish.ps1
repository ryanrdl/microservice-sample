param(
    [string] $configuration = "Release",
    [string] $outputRootDir = ""
)

& (Resolve-Path "C:\Program Files (x86)\MSBuild\*\Bin\MSBuild.exe") .\WebApp\WebApp.csproj /t:WebPublish /p:Configuration=$configuration /p:WebPublishMethod=FileSystem /p:publishUrl=$outputRootDir\WebApp


dotnet publish .\PingApi -o $outputRootDir\PingApi -c $configuration -r active
dotnet publish .\PingService -o $outputRootDir\PingService -c $configuration -r active
dotnet publish .\PongApi -o $outputRootDir\PongApi -c $configuration -r active
dotnet publish .\PongService -o $outputRootDir\PongService -c $configuration -r active

Copy-Item .\pcf-push.ps1 $outputRootDir\pcf-push.ps1