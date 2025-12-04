namespace Day01

module PartOne =

    open System.IO
    open System
    open System.Text.RegularExpressions
    open Day01.Common

    let calculateZeroClicks (rotations: Rotation[]) =
        rotations
        |> Array.fold (fun (state:{|dial:int; zeroCount:int|}) current -> 
            let nextDial = Rotation.Transition current state.dial
            let zeroCount = if nextDial = 0 then state.zeroCount + 1 else state.zeroCount
            {| dial = nextDial; zeroCount = zeroCount |}
        ) {| dial=50; zeroCount=0 |}