$rootDirectory = (Get-Location).Path

# Iterate through all language folders and build and install each language Hello World project
Get-ChildItem -Path . -Recurse -Filter build_and_install.ps1 | ForEach-Object {
    Push-Location (Split-Path $_.FullName)
    try {
        & $_.FullName -Destination "$rootDirectory\all-language-hello-world\dependencies\"
    } finally {
        Pop-Location
    }
}