Param(
   [Parameter(Mandatory=$true)]
   [string]$nsbLicensePath
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

if (Test-Path $nsbLicensePath) {
	if (Test-XMLFile $nsbLicensePath) {
		Copy-Item $nsbLicensePath .\PingApi\NSBLicense.xml
		Copy-Item $nsbLicensePath .\PingService\NSBLicense.xml
		Copy-Item $nsbLicensePath .\PongApi\NSBLicense.xml
		Copy-Item $nsbLicensePath .\PongService\NSBLicense.xml
		#Copy-Item $nsbLicensePath .\WebApp\NSBLicense.xml

		& cd .\PingApi
		& cf push
		& cd ..\PingService
		& cf push
		& cd ..\PongApi
		& cf push
		& cd ..\PongService
		& cf push
		
		#& cd ..\WebApp
		#& cf push

		& cd ..
	}
	else {
		throw "NService license found at $nsbLicensePath is not valid XML"
	}			
}
else {
	throw "NService license not found at $nsbLicensePath"
}