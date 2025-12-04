namespace Day02

module PartTwo =

    open System.IO
    open System
    open System.Text.RegularExpressions
    open Day02.Common

    let allSubstringComparisons (str: string) =
        [1..str.Length / 2]
        |> List.exists(fun length -> Regex.Match(str, @$"^({str.Substring(0,length)})+$").Success)

    let findSillyNumbersInRange (range: Range) = 
        [|range.First..range.Last|]
        |> Array.map string
        |> Array.filter allSubstringComparisons
        |> Array.map int64
