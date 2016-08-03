param( 
    [Parameter(Mandatory=$true)]
	[string] $outputRootDir,
    [Parameter(Mandatory=$true)]
    [string]$nsbLicensePath,
	[string] $configuration = "Release" 			
)

function Test-XMLFile {
    <#
    .SYNOPSIS
    Test the validity of an XML file
    #>
    [CmdletBinding()]
    param (
    [parameter(mandatory=$true)][ValidateNotNullorEmpty()][string]$xmlFilePath
    )
    
    # Check the file exists
    if (!(Test-Path -Path $xmlFilePath)){
        throw "$xmlFilePath is not valid. Please provide a valid path to the .xml fileh"
    }
    # Check for Load or Parse errors when loading the XML file
    $xml = New-Object System.Xml.XmlDocument
    try {
        $xml.Load((Get-ChildItem -Path $xmlFilePath).FullName)
        return $true
    }
    catch [System.Xml.XmlException] {
        Write-Verbose "$xmlFilePath : $($_.toString())"
        return $false
    }
}

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

& (Resolve-Path "C:\Program Files (x86)\MSBuild\*\Bin\MSBuild.exe") .\WebApp\WebApp.csproj /t:WebPublish /p:Configuration=$configuration /p:WebPublishMethod=FileSystem /p:publishUrl=$outputRootDir\WebApp

if (Test-Path $nsbLicensePath) {
	if (Test-XMLFile $nsbLicensePath) {
		Copy-Item $nsbLicensePath .\PingApi\NSBLicense.xml
		Copy-Item $nsbLicensePath .\PingService\NSBLicense.xml
		Copy-Item $nsbLicensePath .\PongApi\NSBLicense.xml
		Copy-Item $nsbLicensePath .\PongService\NSBLicense.xml
		
		#Copy-Item $nsbLicensePath .\WebApp\NSBLicense.xml
	}
	else {
		throw "NService license found at $nsbLicensePath is not valid XML"
	}			
}
else {
	throw "NService license not found at $nsbLicensePath"
}

$pcfPushScriptPath = "$outputRootDir\pcf-push.ps1"

If (Test-Path $pcfPushScriptPath) { Remove-Item -Force $pcfPushScriptPath }

Copy-Item .\pcf-push.ps1 $pcfPushScriptPath