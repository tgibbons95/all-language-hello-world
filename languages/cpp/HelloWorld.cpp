extern "C" {
    // Exported function that returns a string
    __declspec(dllexport) const char* GetHelloWorldCpp() {
        return "Hello World - C++";
    }
}
