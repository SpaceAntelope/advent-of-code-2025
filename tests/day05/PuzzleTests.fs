namespace Day05.Tests

module PuzzleTests =
    open Faqt
    open Xunit
    open Day05
    open Day05.Common

    let tee x = printfn "%A" x; x

    [<Fact>]
    let ``Parse input example correctly`` () = 
        let expected = {
            Ranges = [|
                { Start = 3; End = 5}
                { Start = 10; End = 14}
                { Start = 16; End = 20}
                { Start = 12; End = 18}
            |]
            Ingredients = [|
                1;5;8;11;17;32
            |]
        }

        let actual = 
            Common.parse "./data/input.example"

        actual.Should().Be(expected)

    [<Fact>]
    let ``Calculate correct freshness for example db`` () = 
        let expected = 3

        let actual = 
            "./data/input.example"
            |> Common.parse 
            |> PartOne.findFresh
            |> Array.length

        actual.Should().Be(expected)

    [<Fact>]
    let ``Calculate correct amount of unique fresh indices``() =
        let expected = 14

        let actual = 
            "./data/input.example"
            |> Common.parse 
            |> _.Ranges
            |> PartTwo.consolidate             
            |> PartTwo.sumRangeMembers

        actual.Should().Be(expected)