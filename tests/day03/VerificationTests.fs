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
        