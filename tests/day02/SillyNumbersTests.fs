namespace Day02.Tests

open Xunit
open Day02.Common
open System.IO

module SillyNumbersTests = 

    [<Theory>]
    [<ClassData(typeof<TestData>)>]
    let ``Find silly numbers in range`` range expected =
        
        let actual = Day02.PartOne.findSillyNumbersInRange range

        expected
        |> Array.ofList
        |> Array.zip actual
        |> Array.iter (fun (expected, actual) -> Assert.Equal(expected, actual))

    [<Fact>]
    let ``Sum silly numbers in range`` ()=
        let expected = 
            TestData() 
            |> Seq.collect (fun x -> 
                let struct (_,expected) = x.Data; 
                expected)
            |> Seq.sum
        
        let actual = 
            "./data/input.example"
            |> File.ReadAllText
            |> Range.From
            |> Array.collect (Day02.PartOne.findSillyNumbersInRange)
            |> Array.sum

        Assert.Equal(expected, actual)
