namespace Day07

module Program =

    open Day07.Common

    [<EntryPoint>]
    let main argv =
        let file = argv[0]
        
        file
        |> parse
        |> PartOne.countTheSplits
        |> printfn "The beam will be split %d times."

        file
        |> parse
        |> PartTwo.countTheRoutes
        |> printfn "In total, a single tachyon particle will end up on %d different timelines."
       

        0