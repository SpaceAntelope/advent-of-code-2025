namespace Day01.Tests

open Xunit
open Day01
open System.IO

type ParseData() =
    inherit TheoryData<string, Rotation>()
    do
        base.Add("L13", Rotation.L 13)
        base.Add("R5", Rotation.R 5)
        base.Add("L0", Rotation.L 0)
        base.Add("R100", Rotation.R 100)

module ParsingTests = 
    
    [<Theory>]
    [<ClassData(typeof<ParseData>)>]
    let ``Parse sample rotations from string`` source expected =
        let actual = Day01.Rotation.From source
        Assert.Equal(expected, actual)

    [<Fact>]
    let FileParsing_Works() =
        let expected = [| 
                L 68
                L 30
                R 48
                L 5
                R 60
                L 55
                L 1
                L 99
                R 14
                L 82 |]

        let actual =
            "./data/input.example"
            |> File.ReadAllLines
            |> Array.map Rotation.From
        
        expected 
        |> Array.zip actual 
        |> Array.iter (fun (e, a) -> Assert.Equal(e, a))