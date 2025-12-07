namespace Day05

module Program =


    [<EntryPoint>]
    let main argv =
        let file = argv[0]
        let db = file |> Common.parse 

        db
        |> PartOne.findFresh
        |> Array.length
        |> printfn "%d of the available ingredient IDs are fresh."

        db
        |> _.Ranges
        |> PartTwo.consolidate 
        |> PartTwo.sumRangeMembers
        |> printfn "%d ingredient IDs are considered to be fresh according to the fresh ingredient ID ranges."

        0