namespace Day03.Tests

open Xunit
open Day04
open System.IO
open Faqt

module PuzzleTests = 
    
    [<Theory>]
    [<InlineData(0,0,2)>]
    [<InlineData(0,1,4)>]
    [<InlineData(0,9,3)>]
    let ``Count nearby rolls correctly`` row col count= 
        let grid = 
            "./data/input.example"
            |> Common.parse

        let expected = count
        let actual = 
            grid 
            |> Common.neighbourhood (row,col)
            |> Array.filter (fun x -> x = '@') |> Array.length

        actual.Should().Be(expected)   


    [<Fact>]
    let ``Count rolls with at most 3 nearby rolls successfully`` () =
        let expected = 13

        let actual = 
            "./data/input.example"
            |> Common.parse
            |> PartOne.filterCellsByOccupiedNeighborCount 3
            |> Array.length

        actual.Should().Be(expected)