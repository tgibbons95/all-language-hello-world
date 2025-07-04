param (
    [string]$Destination
)

### Install the Python output files
echo "Installing Python..."
$destinationFolder = "${Destination}Python"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorldPython.py" -Destination $destinationFolder -Force
