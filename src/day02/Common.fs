namespace Day02

module Common =

    open System.IO
    open System
    open System.Text.RegularExpressions

    type Range = {
        First: int64
        Last: int64
    }
       

    module Range = 
        let From (source: string) : Range[] =
            source
            |> _.Split(',')
            |> Array.map (fun (x:string) -> 
                    let parts = x.Split('-')
                    {   First = int64 <| parts[0]
                        Last = int64 <| parts[1] })
            
    let parse file = 
        file
        |> File.ReadAllText
        |> Range.From
