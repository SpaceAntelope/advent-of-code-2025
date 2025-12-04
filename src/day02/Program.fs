namespace Day02

module Program =

    open System.IO

    [<EntryPoint>]
    let main argv =
        let file = argv[0]
        let ranges = file |> Common.parse 
        
        ranges
        |> Array.collect PartOne.findSillyNumbersInRange
        |> Array.sum
        |> printfn "Part 1: If you add up all of the invalid IDs you get %d."
        
        ranges
        |> Array.collect PartTwo.findSillyNumbersInRange
        |> Array.sum
        |> printfn "Part 2: If you add up all of the invalid IDs using these new rules you get %d."
        
        0
