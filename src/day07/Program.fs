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
       

        0