namespace Day02

module PartOne =

    open System.IO
    open System
    open System.Text.RegularExpressions
    open Day02.Common

    let findSillyNumbersInRange (range: Range) = 
        [|range.First..range.Last|]
        |> Array.map string
        |> Array.filter (fun str -> str.Length % 2 = 0)
        |> Array.filter (fun str ->
            let halfLength = str.Length / 2
            let left = str.Substring(0,halfLength)
            let right = str.Substring(halfLength)
            left = right )
        |> Array.map int64


 