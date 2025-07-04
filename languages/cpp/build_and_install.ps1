param (
    [string]$Destination
)

### Build the C++ output files
echo "Building Cpp..."
$folderPath = "build"
if (-not (Test-Path $folderPath)) {
    New-Item -Path $folderPath -ItemType Directory
}

$installPath = "install"
cd $folderPath
cmake .. -DCMAKE_INSTALL_PREFIX="$installPath"
cmake --build . --config Release
cmake --install . --config Release

### Install the C++ output files
echo "Installing Cpp..."
$destinationFolder = "${Destination}Cpp"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

echo $destinationFolder
echo $installPath\bin\HelloWorldCpp.dll
Copy-Item -Path "$installPath\bin\HelloWorldCpp.dll" -Destination $destinationFolder -Force
