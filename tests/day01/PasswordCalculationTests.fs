namespace Day01.Tests

open Xunit
open Day01.Common
open Day01.PartOne
open System.IO

module PasswordCalculationTest =  
      
    [<Fact>]
    let ``Calculate all the times the dial stops at zero``() =

        let expected = 3

        let actual =
            "./data/input.example"
            |> File.ReadAllLines
            |> Array.map Rotation.From
            |> calculateZeroClicks
            |> _.zeroCount
        
        Assert.Equal(expected, actual)