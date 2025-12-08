namespace Day06.Tests

module PuzzleTests =
    open Faqt
    open Xunit
    open Day06
    open Day06.Common
    open System.IO

    let tee x =
        printfn "%A" x
        x

    let expected =
        [| { Operands = [| 123; 45; 6 |]
             Operator = Times }
           { Operands = [| 328; 64; 98 |]
             Operator = Plus }
           { Operands = [| 51; 387; 215 |]
             Operator = Times }
           { Operands = [| 64; 23; 314 |]
             Operator = Plus } |]

    [<Fact>]
    let ``Parse input example correctly`` () =
        let actual = "./data/input.example" |> parse

        printfn "%A" actual

        actual.Should().Be(expected)

    [<Fact>]
    let ``Calculate results for example dataset correctly`` () =
        let expected = [| 33210L; 490L; 4243455L; 401L |]

        let actual =
            "./data/input.example"
            |> parse
            |> Array.map Cephaloperation.calculate

        actual.Should().Be(expected) |> ignore

        let expectedSum = 4277556
        let actualSum = actual |> Array.sum

        actualSum.Should().Be(expectedSum)

    let advancedExpected =
        [| { Operands = [| 4; 431; 623 |]
             Operator = Plus }
           { Operands = [| 175; 581; 32 |]
             Operator = Times }
           { Operands = [| 8; 248; 369 |]
             Operator = Plus }
           { Operands = [| 356; 24; 1 |]
             Operator = Times } |]

    [<Fact>]
    let ``Parse advanced cephalopod math correctly`` () =

        let actual =
            "./data/input.example" 
            |> Day06.PartTwo.parse

        actual.Should().Be(advancedExpected)

    let ``Calculate advanced results for example dataset correctly`` () =
        let expected = [| 1058L; 3253600L; 625L; 8544L|]

        let actual =
            "./data/input.example"
            |> Day06.PartTwo.parse
            |> Array.map Cephaloperation.calculate

        actual.Should().Be(expected) |> ignore

        let expectedSum = 3263827
        let actualSum = actual |> Array.sum

        actualSum.Should().Be(expectedSum)