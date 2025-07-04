param (
    [string]$Destination
)

### Build the Assembly output files
$masmLocation = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Tools\MSVC\14.28.29333\bin\Hostx64\x64"
echo "Building Assembly..."
Start-Process -FilePath "${masmLocation}\ml64.exe" -ArgumentList "/c", "HelloWorld.asm" -Wait -NoNewWindow
Start-Process -FilePath "${masmLocation}\link.exe" -ArgumentList "/DLL", "/NOENTRY", "/INCREMENTAL:NO", "/DEBUG:NONE", "/DEF:HelloWorld.def", "/OUT:HelloWorldAssembly.dll", "HelloWorld.obj" -Wait -NoNewWindow

### Install the Assembly output files
echo "Installing Assembly..."
$destinationFolder = "${Destination}Assembly"
if (-not (Test-Path $destinationFolder)) {
  New-Item -Path $destinationFolder -ItemType Directory | Out-Null
}

Copy-Item -Path "HelloWorldAssembly.dll" -Destination $destinationFolder -Force
