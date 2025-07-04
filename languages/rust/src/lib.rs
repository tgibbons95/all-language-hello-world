#![allow(non_snake_case)]

use std::ffi::CString;
use std::os::raw::c_char;

static mut STRING_PTR: *mut c_char = std::ptr::null_mut();

#[no_mangle]
pub extern "C" fn get_message() -> *mut c_char {
    let msg = CString::new("Hello World - Rust").unwrap();
    let ptr = msg.into_raw();
    unsafe {
        STRING_PTR = ptr;
    }
    ptr
}

#[no_mangle]
pub extern "C" fn free_message() {
    unsafe {
        if !STRING_PTR.is_null() {
            let _ = CString::from_raw(STRING_PTR);
            STRING_PTR = std::ptr::null_mut();
        }
    }
}