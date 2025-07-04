param (
    [string]$Destination
)

### Build the Rust output files
echo "Building Rust..."
cargo build --release

### Install the Rust output files
echo "Installing Rust..."
$destinationFolder = "${Destination}Rust"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "target\release\HelloWorldRust.dll" -Destination $destinationFolder -Force
