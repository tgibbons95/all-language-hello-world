param (
    [string]$Destination
)

### Build the Go output files
echo "Building Go..."
go build -buildmode=c-shared -o HelloWorldGo.dll HelloWorld.go

# Remove the header generated for Go
$filePath = "HelloWorldGo.h"
if (Test-Path $filePath) {
    Remove-Item $filePath -Force
    Write-Host "File removed successfully."
} else {
    Write-Host "File not found at path: $filePath"
}

### Install the Go output files
echo "Installing Go..."
$destinationFolder = "${Destination}Go"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorldGo.dll" -Destination $destinationFolder -Force
