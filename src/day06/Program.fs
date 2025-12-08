namespace Day06

module Program =

    open Day06.Common

    [<EntryPoint>]
    let main argv =
        let file = argv[0]
        
        file
        |> parse
        |> Array.map Cephaloperation.calculate
        |> Array.sum
        |> printfn "The grand total found by adding together all of the answers to the individual problems is %d"

        file
        |> PartTwo.parse
        |> Array.map Cephaloperation.calculate
        |> Array.sum
        |> printfn "The grand total found by adding together all of the answers to the individual problems is %d"

        0