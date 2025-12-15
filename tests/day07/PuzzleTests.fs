namespace Day07.Tests

module PuzzleTests =
    open Faqt
    open Xunit
    open Day07
    open Day07.Common
    open System.IO

    let tee x =
        printfn "%A" x
        x

    let expected =
        [|
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Start; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Split; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Split; Empty; Split; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Split; Empty; Split; Empty; Split; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Split; Empty; Split; Empty; Empty; Empty; Split; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Split; Empty; Split; Empty; Empty; Empty; Split; Empty; Split; Empty; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Empty; Split; Empty; Empty; Empty; Split; Empty; Empty; Empty; Empty; Empty; Split; Empty; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
            [| Empty; Split; Empty; Split; Empty; Split; Empty; Split; Empty; Split; Empty; Empty; Empty; Split; Empty; |]
            [| Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; |]
        |] |> array2D

    [<Fact>]
    let ``Parse input example correctly`` () =
        let actual = "./data/input.example" |> parse

        printfn "%A" actual

        actual.Should().Be(expected)

    [<Fact>]
    let ``Calculate results for example dataset correctly`` () =
        let expected = 21
        let actual =
            "./data/input.example"
            |> parse
            |> PartOne.countTheSplits

        actual.Should().Be(expected)

    [<Fact>]
    let ``Calculate route count for example dataset correctly`` () =
        let expected = 40
        let actual =
            "./data/input.example"
            |> parse
            |> PartTwo.countTheRoutes

        actual.Should().Be(expected)
