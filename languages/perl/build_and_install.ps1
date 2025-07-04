param (
    [string]$Destination
)

### Install the Perl output files
echo "Installing Perl..."
$destinationFolder = "${Destination}Perl"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorld.perl" -Destination $destinationFolder -Force
