module Day01 

open System.IO
open System
open System.Text.RegularExpressions

type Rotation =
    | L of int
    | R of int

module Rotation = 
    let From (line: string) =
        let m: Match = Regex.Match(line, @"(\w)(\d+)")
        let steps = Convert.ToInt32(m.Groups[2].Value)
        match m.Groups[1].Value with
        | "L" -> L steps
        | "R" -> R steps
        | _ -> failwith $"I don't know how to parse {line}"

    let Transition (r: Rotation) (dial: int)=
        match r with
        | L _steps ->
            let steps = _steps % 100
            let result = dial - steps
            if result < 0 
            then 100 + result
            else result
        | R steps -> (dial + steps) % 100
        
let parse file = 
    file
    |> File.ReadAllLines
    |> Array.map (Rotation.From)

let calculateZeroClicks (rotations: Rotation[]) =
    rotations
    |> Array.fold (fun (state:{|dial:int; zeroCount:int|}) current -> 
        let nextDial = Rotation.Transition current state.dial
        let zeroCount = if nextDial = 0 then state.zeroCount + 1 else state.zeroCount
        {| dial = nextDial; zeroCount = zeroCount |}
    ) {| dial=50; zeroCount=0 |}

[<EntryPoint>]
let main argv =
    let file = argv[0]
    
    file 
    |> parse 
    |> calculateZeroClicks 
    |> _.zeroCount 
    |> printfn "The actual password to open the door is %d."
    
    0
