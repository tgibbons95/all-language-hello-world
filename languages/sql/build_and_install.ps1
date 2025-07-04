param (
    [string]$Destination
)

### Install the Sql output files
echo "Installing Sql..."
$destinationFolder = "${Destination}Sql"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorld.db" -Destination $destinationFolder -Force
Copy-Item -Path "HelloWorldQuery.sql" -Destination $destinationFolder -Force
