namespace Day04

module Program =

    open System.IO

    [<EntryPoint>]
    let main argv =
        let file = argv[0]

        file
        |> Common.parse 
        |> PartOne.filterCellsByOccupiedNeighborCount 3
        |> Array.length
        |> printfn "%d rolls of paper can be accessed by a forklift."
        0
