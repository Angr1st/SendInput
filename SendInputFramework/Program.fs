// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.

open SendInputLib.SendInputBindings
open System

[<EntryPoint>]
let main argv =
    pressKey(KeyCodes.KEY_A)
    printfn "%A" argv
    Console.ReadLine() |> ignore
    0 // return an integer exit code
