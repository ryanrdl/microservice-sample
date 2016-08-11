param( 
    [Parameter(Mandatory=$true)]
	[string] $outputRootDir,
    [Parameter(Mandatory=$true)]
    [string] $nsbLicensePath,
	[string] $configuration = "Release" 			
)

# Check the file exists
if (!(Test-Path -Path $nsbLicensePath)){
	throw "$nsbLicensePath is not valid. Please provide a valid path to the .xml NServiceBus license file"
}
# Check for Load or Parse errors when loading the XML file
$xml = New-Object System.Xml.XmlDocument
try {
	$xml.Load((Get-ChildItem -Path $nsbLicensePath).FullName)
	Write-Host "Successfully validated $nsbLicensePath as a valid XML"
}
catch [System.Xml.XmlException] {
	throw "$nsbLicensePath is not valid. Please provide a valid path to the .xml NServiceBus license file"
}

$pingApiDir = "$outputRootDir\PingApi"
$pingServiceDir = "$outputRootDir\PingService"
$pongApiDir = "$outputRootDir\PongApi"
$pongServiceDir = "$outputRootDir\PongService"
$webAppDir = "$outputRootDir\WebApp"
$webApp2Dir = "$outputRootDir\WebApp2"

If (Test-Path $pingApiDir) { Remove-Item -Recurse -Force $pingApiDir }
If (Test-Path $pingServiceDir) { Remove-Item -Recurse -Force $pingServiceDir }
If (Test-Path $pongApiDir) { Remove-Item -Recurse -Force $pongApiDir }
If (Test-Path $pongServiceDir) { Remove-Item -Recurse -Force $pongServiceDir }

dotnet publish .\PingApi -o $pingApiDir -c $configuration -r win7-x64
dotnet publish .\PingService -o $pingServiceDir -c $configuration -r win7-x64
dotnet publish .\PongApi -o $pongApiDir -c $configuration -r win7-x64
dotnet publish .\PongService -o $pongServiceDir -c $configuration -r win7-x64

$msbuild = (Resolve-Path "C:\Program Files (x86)\MSBuild\*\Bin\MSBuild.exe")

& $msbuild .\WebApp\WebApp.csproj /t:WebPublish /p:Configuration=$configuration /p:WebPublishMethod=FileSystem /p:publishUrl=$outputRootDir\WebApp
& $msbuild .\WebApp\WebApp2.csproj /t:WebPublish /p:Configuration=$configuration /p:WebPublishMethod=FileSystem /p:publishUrl=$outputRootDir\WebApp2

Copy-Item $nsbLicensePath $pingApiDir\NSBLicense.xml 
Copy-Item $nsbLicensePath $pingServiceDir\NSBLicense.xml 
Copy-Item $nsbLicensePath $pongApiDir\NSBLicense.xml 
Copy-Item $nsbLicensePath $pongServiceDir\NSBLicense.xml 
Copy-Item $nsbLicensePath $webAppDir\NSBLicense.xml 
Copy-Item $nsbLicensePath $webAppDir2\NSBLicense.xml 

$pcfPushScriptPath = "$outputRootDir\pcf-push.ps1"

If (Test-Path $pcfPushScriptPath) { Remove-Item -Force $pcfPushScriptPath }

Copy-Item .\pcf-push.ps1 $pcfPushScriptPath