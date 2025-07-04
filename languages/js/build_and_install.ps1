param (
    [string]$Destination
)

### Install the Js output files
echo "Installing Js..."
$destinationFolder = "${Destination}Js"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorld.js" -Destination $destinationFolder -Force
