param( 
    [Parameter(Mandatory=$true)]
	[string] $outputRootDir,
	[string] $configuration = "Release"
)

& (Resolve-Path "C:\Program Files (x86)\MSBuild\*\Bin\MSBuild.exe") .\WebApp\WebApp.csproj /t:WebPublish /p:Configuration=$configuration /p:WebPublishMethod=FileSystem /p:publishUrl=$outputRootDir\WebApp


$pingApiDir = "$outputRootDir\PingApi"
$pingServiceDir = "$outputRootDir\PingService"
$pongApiDir = "$outputRootDir\PongApi"
$pongServiceDir = "$outputRootDir\PongService"

If (Test-Path $pingApiDir) { Remove-Item -Recurse -Force $pingApiDir }
If (Test-Path $pingServiceDir) { Remove-Item -Recurse -Force $pingServiceDir }
If (Test-Path $pongApiDir) { Remove-Item -Recurse -Force $pongApiDir }
If (Test-Path $pongServiceDir) { Remove-Item -Recurse -Force $pongServiceDir }

dotnet publish .\PingApi -o $pingApiDir -c $configuration -r win7-x64
dotnet publish .\PingService -o $pingServiceDir -c $configuration -r win7-x64
dotnet publish .\PongApi -o $pongApiDir -c $configuration -r win7-x64
dotnet publish .\PongService -o $pongServiceDir -c $configuration -r win7-x64

$pcfPushScriptPath = "$outputRootDir\pcf-push.ps1"

If (Test-Path $pcfPushScriptPath) { Remove-Item -Force $pcfPushScriptPath }

Copy-Item .\pcf-push.ps1 $pcfPushScriptPath