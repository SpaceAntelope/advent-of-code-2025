namespace Day01 

module Program =

    open System.IO

    [<EntryPoint>]
    let main argv =
        let file = argv[0]
        let rotations = file |> Day01.Common.parse 
        
        
        rotations
        |> PartOne.calculateZeroClicks 
        |> _.zeroCount 
        |> printfn "Part 1: The actual password to open the door is %d."
        
        rotations
        |> PartTwo.calculateZeroClicks 
        |> _.zeroCount 
        |> printfn "Part 1: Using password method 0x434C49434B, the password to open the door is %d."
        0
