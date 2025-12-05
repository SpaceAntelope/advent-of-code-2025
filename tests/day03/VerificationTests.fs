namespace Day03.Tests

open Xunit
open Day03
open System.IO
open Faqt

module VerificationTests = 
    
    [<Fact>]
    let ``Parse banks from file`` () =
        let expected = [|
                [|9;8;7;6;5;4;3;2;1;1;1;1;1;1;1|]
                [|8;1;1;1;1;1;1;1;1;1;1;1;1;1;9|]
                [|2;3;4;2;3;4;2;3;4;2;3;4;2;7;8|]
                [|8;1;8;1;8;1;9;1;1;1;1;2;1;1;1|] |]
        
        let actual = 
            "./data/input.example"
            |> Common.parse

        actual.Should().Be(expected);

    [<Theory>]    
    [<InlineData("987654321111111", 98)>]
    [<InlineData("811111111111119", 89)>]
    [<InlineData("234234234234278", 78)>]
    [<InlineData("818181911112111", 92)>]
    let ``Find highest value pair in bank`` (bank:string) (expected:int) =
        
        let actual = 
            bank
            |> Common.parseBank
            |> PartOne.findHighestValuePair
        
        actual.Should().Be(expected)

    [<Fact>]    
    let ``Find sum of highest pairs in bank arrangement``() =
        let expected = 357
        let actual = 
            "./data/input.example"
            |> Common.parse
            |> Array.map PartOne.findHighestValuePair
            |> Array.sum
        
        actual.Should().Be(expected)
        
    [<Theory>]    
    [<InlineData("987654321111111", 987654321111L)>]
    [<InlineData("811111111111119", 811111111119L)>]
    [<InlineData("234234234234278", 434234234278L)>]
    [<InlineData("818181911112111", 888911112111L)>]
    [<InlineData("123456789000000", 456789000000L)>]
    [<InlineData("900000000000000", 900000000000L)>]
    [<InlineData("900010000000000", 910000000000L)>]
    [<InlineData("123123123123123", 323123123123L)>]
    let ``Find highest value dozen in bank`` (bank:string) (expected:int64) =
        
        let actual = 
            bank
            |> Common.parseBank
            |> PartTwo.findHighestValueDozen
        
        actual.Should().Be(expected)

    [<Fact>]    
    let ``Find sum of highest dozens in bank arrangement``() =
        let expected = 3121910778619L
        let actual = 
            "./data/input.example"
            |> Common.parse
            |> Array.map PartTwo.findHighestValueDozen
            |> Array.sum
        
        actual.Should().Be(expected)