param (
    [string]$Destination
)

### Build the C output files
echo "Building C..."
$folderPath = "build"
if (-not (Test-Path $folderPath)) {
    New-Item -Path $folderPath -ItemType Directory
}

$installPath = "install"
cd $folderPath
cmake .. -DCMAKE_INSTALL_PREFIX="$installPath"
cmake --build . --config Release
cmake --install . --config Release

### Install the C output files
echo "Installing C..."
$destinationFolder = "${Destination}C"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "$installPath\bin\HelloWorldC.dll" -Destination $destinationFolder -Force
