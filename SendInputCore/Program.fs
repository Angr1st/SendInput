// Learn more about F# at http://fsharp.org

open System
open SendInputLib.SendInputBindings

[<EntryPoint>]
let main argv =
    pressKey(KeyCodes.KEY_A)
    printfn "Hello World from F#!"

    0 // return an integer exit code
