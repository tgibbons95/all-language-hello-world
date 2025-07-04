cmake_minimum_required(VERSION 3.10)
project(HelloWorld)

# Set the output to a DLL
add_library(HelloWorldC SHARED HelloWorld.c)

# Optionally specify C++ standard
set_target_properties(HelloWorldC PROPERTIES
    CXX_STANDARD 17
    CXX_STANDARD_REQUIRED YES
)

# Install the DLL and import library
install(TARGETS HelloWorldC
    RUNTIME DESTINATION bin    # .dll on Windows
    ARCHIVE DESTINATION lib    # .lib (import library)
    LIBRARY DESTINATION lib    # .so/.dylib on Unix-like systems
)
