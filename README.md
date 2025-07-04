# all-language-hello-world
One executable integrated to say hello world in as many languages as possible

## Main project
This repository contains one main driver project in C# under all-language-hello-world

A hello world interface is made with the main method GetHelloWorld() to return a string and an IsEnabled() method to disable any languages not desired to run. Each new language that gets added to this project will implement this interface and call code for that language to receive the "Hello World - {language}" string 

## Sub projects
A languages directory has been made to split out every side project for the various languages. All relevant code for a new language should be under its respective directory. For example, C++ code is under the cpp directory.

Every language directory should have a build_and_install.ps1 script inside of it. This script will be responsible for building code for the particular language and then copying it to the destination folder provided as an argument. For example, the script for C++ will run CMake to build and install a shared library. It will then copy the built dll to the destination folder.

## Prerequisites
- C# uses .NET 8.0
- C/C++ uses CMake 3.10 and expects it to be available in environment path for building
- Rust uses Cargo and expects it to be available in environment path for building
- Python requires python in the environment path at runtime
- Assembly 
  - Built for x64 only
  - Build script uses visual studio community path to ml64.exe and link.exe which will vary by installation, but would have to be manually changed at the moment
- Java requires Java SDK and a Javonet API Key in the environment variable JavonetApiKey
  - JAVA_HOME env variable must be set and the JAVA_HOME/bin folder must be in the path for building
  - If api key is missing, java will be skipped at runtime with a warning
- Perl requires the perl.exe to be in the environment path which can be installed with Strawberry perl
- JavaScript also uses Javonet similar instructions on the API key as in java
- Php requires php.exe to be in environment path
- R requires RScript to be in environment path
- Go requires go installation in environment path

## How to run
- Open the all-languages-hello-world.sln and build the main project
  - Before the build target is built, build-and-install-all-languages.ps1 will be run in powershell which will recursively run all the particular language build scripts and place relevant binaries into the dependencies folder of the main project.
- Run!