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
        |> printfn "Part 1: the total output joltage is  %d."
        
        // ranges
        // |> Array.collect PartTwo.findSillyNumbersInRange
        // |> Array.sum
        // |> printfn "Part 2: If you add up all of the invalid IDs using these new rules you get %d."
        
        0
