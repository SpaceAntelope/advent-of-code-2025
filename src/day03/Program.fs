namespace Day03

module Program =

    open System.IO

    [<EntryPoint>]
    let main argv =
        let file = argv[0]
        let banks = file |> Common.parse 
        
        banks
        |> Array.map PartOne.findHighestValuePair
        |> Array.sum
        |> printfn "Part 1: the total output joltage is %d"
        
        banks
        |> Array.map PartTwo.findHighestValueDozen
        |> Array.sum
        |> printfn "Part 2: the new total output joltage is %d"
        
        0
