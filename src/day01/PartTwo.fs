namespace Day01

module PartTwo =

    open System.IO
    open System
    open System.Text.RegularExpressions
    open Day01.Common

    let calculateZeroClicks (rotations: Rotation[]) =
        rotations
        |> Array.fold (fun (state:{|dial:int; zeroCount:int|}) current -> 
            let nextDial = Rotation.Transition current state.dial
            let remainderSteps = current.Steps % 100
            let zeroTouches =
                state.zeroCount +
                (if nextDial = 0 then 1 else 0) +
                (current.Steps/100) +
                match current with
                | L _ -> if remainderSteps > state.dial && state.dial <> 0 then 1 else 0
                | R _ -> if remainderSteps > (100 - state.dial) && state.dial <> 0 then 1 else 0
            // Console.WriteLine($"{current}: {state.dial} -> {nextDial} Zero: {state.zeroCount - zeroTouches <> 0}")
            {| dial = nextDial; zeroCount = zeroTouches |}
        ) {| dial=50; zeroCount=0 |}