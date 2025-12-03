namespace Day01.Tests

open Xunit
open Day01
open System.IO

module PasswordCalculationTest =  
      
    [<Fact>]
    let CalculateZeroClicks_Works() =

        let expected = 3

        let actual =
            "./data/input.example"
            |> File.ReadAllLines
            |> Array.map Rotation.From
            |> Day01.calculateZeroClicks
            |> _.zeroCount
        
        Assert.Equal(expected, actual)