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

        

    // let advancedExpected =
    //     [| { Operands = [| 4; 431; 623 |]
    //          Operator = Plus }
    //        { Operands = [| 175; 581; 32 |]
    //          Operator = Times }
    //        { Operands = [| 8; 248; 369 |]
    //          Operator = Plus }
    //        { Operands = [| 356; 24; 1 |]
    //          Operator = Times } |]

    // [<Fact>]
    // let ``Parse advanced cephalopod math correctly`` () =

    //     let actual =
    //         "./data/input.example" 
    //         |> Day07.PartTwo.parse

    //     actual.Should().Be(advancedExpected)

    // let ``Calculate advanced results for example dataset correctly`` () =
    //     let expected = [| 1058L; 3253600L; 625L; 8544L|]

    //     let actual =
    //         "./data/input.example"
    //         |> Day07.PartTwo.parse
    //         |> Array.map Cephaloperation.calculate

    //     actual.Should().Be(expected) |> ignore

    //     let expectedSum = 3263827
    //     let actualSum = actual |> Array.sum

    //     actualSum.Should().Be(expectedSum)

