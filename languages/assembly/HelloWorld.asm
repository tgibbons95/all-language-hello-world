.data
    helloStr db "Hello World - Assembly", 0

.code
PUBLIC GetMessage
GetMessage PROC
    mov rax, OFFSET helloStr
    ret
GetMessage ENDP

END