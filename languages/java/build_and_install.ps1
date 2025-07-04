param (
    [string]$Destination
)

### Build the Java output files
echo "Building Java..."
javac HelloWorldClass.java
jar cvf HelloWorld.jar HelloWorldClass.class


### Install the Java output files
echo "Installing Java..."
$destinationFolder = "${Destination}Java"
if (-not (Test-Path $destinationFolder)) {
    New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorld.jar" -Destination $destinationFolder -Force
