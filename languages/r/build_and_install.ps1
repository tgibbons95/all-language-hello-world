param (
    [string]$Destination
)

### Install the R output files
echo "Installing R..."
$destinationFolder = "${Destination}R"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorld.r" -Destination $destinationFolder -Force
