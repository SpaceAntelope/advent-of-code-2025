namespace Day04

module Program =

    open System.IO

    [<EntryPoint>]
    let main argv =
        let file = argv[0]
        let grid = file |> Common.parse 

        grid
        |> PartOne.filterCellsByOccupiedNeighborCount 3
        |> Array.length
        |> printfn "%d rolls of paper can be accessed by a forklift."

        grid
        |> PartTwo.removeAllPossibleRolls
        |> printfn "%d rolls of paper in total can be removed by the Elves and their forklifts."
        0
