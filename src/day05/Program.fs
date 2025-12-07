namespace Day05

module Program =

    open Common
    open PartOne    
    open System.IO

    [<EntryPoint>]
    let main argv =
        let file = argv[0]
        let db = file |> Common.parse 

        db
        |> PartOne.findFresh
        |> Array.length
        |> printfn "%d of the available ingredient IDs are fresh."

        0