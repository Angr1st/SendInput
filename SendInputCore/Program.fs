// Learn more about F# at http://fsharp.org

open System
open SendInputLib.SendInputBindings
open System.Runtime.InteropServices
open System.ComponentModel

[<EntryPoint>]
let main argv =
    pressKey(KeyCodes.KEY_A)
    let error = Win32Exception(Marshal.GetLastWin32Error())
    let errorMsg = error.Message
    printfn "%s; Error Code: %i" errorMsg error.NativeErrorCode

    0 // return an integer exit code
