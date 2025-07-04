param (
    [string]$Destination
)

### Install the Php output files
echo "Installing Php..."
$destinationFolder = "${Destination}Php"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorld.php" -Destination $destinationFolder -Force
