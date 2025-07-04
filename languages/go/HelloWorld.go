package main

import "C"

//export GetHelloWorldGo
func GetHelloWorldGo() *C.char {
    message := "Hello World - Go"
    return C.CString(message)
}

func main() {}