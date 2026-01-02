namespace Day08.Tests

open System.Collections.Generic

module PuzzleTests =
    open Faqt
    open Xunit
    open Day08
    open Day08.Common
    open System.IO
    open Day08.PartOne

    let tee x =
        printfn "%A" x
        x

    type EdgeLite = { From : Coord; To: Coord}
        with static member FromEdge (source: Edge) =  { From = source.From; To = source.To }

    let example = 
        "./data/input.example"
        |> parse
        |> List.ofArray

    [<Fact>]
    let ``Sorted example edges by distance``() =
        let expected = [
            { From = { X = 162; Y = 817; Z = 812 }; To = {X = 425; Y = 690; Z = 689} }
            { From = { X = 162; Y = 817; Z = 812 }; To = {X = 431; Y = 825; Z = 988} }
            { From = { X = 906; Y = 360; Z = 560 }; To = {X = 805; Y = 96;  Z = 715} }
            { From = { X = 431; Y = 825; Z = 988 }; To = {X = 425; Y = 690; Z = 689} }
        ]

        let actual = 
            example 
            |> PartOne.Circuit.toSortedEdges 
            |> List.take 4 
            |> List.map EdgeLite.FromEdge

        actual.Should().Be(expected)
        

    let edges = [|
            { From = { X = 162; Y = 817; Z = 812 }; To = {X = 425; Y = 690; Z = 689}; Distance = 0 }
            { From = { X = 162; Y = 817; Z = 812 }; To = {X = 431; Y = 825; Z = 988}; Distance = 0 }
            { From = { X = 906; Y = 360; Z = 560 }; To = {X = 805; Y = 96;  Z = 715}; Distance = 0 }
            { From = { X = 431; Y = 825; Z = 988 }; To = {X = 425; Y = 690; Z = 689}; Distance = 0 }
        |]

    type ConnectableData() =
        inherit TheoryData<Set<Edge>, Edge>()
        do
            base.Add(Set.ofList [edges.[0]], edges.[2])



    // [<Fact>]
    // let ``isConnectable should allow connections correctly``() =
    //     let mergedToList merged = 
    //         match merged with
    //         | Circuit.MergeResult.Merged m -> m |> Set.toList
    //         | _ -> []

    //     let mergeResult1 = Circuit.merge [edges.[0]] [edges.[1]]
    //     let junctionCount1 = 
    //         mergeResult1 
    //         |> function 
    //         | Circuit.MergeResult.Merged m -> m |> Circuit.toCoords |> Seq.distinct |> Seq.length 
    //         | _ -> 0

    //     mergeResult1
    //         .Should()
    //         .Be(Circuit.MergeResult.Merged (Set.ofList [edges.[0]; edges.[1]]))
    //     |> ignore
        
    //     junctionCount1.Should().Be(3)
    //     |> ignore

    //     let mergeResult2 = Circuit.merge (mergedToList mergeResult1) [edges.[2]]

        
  
    [<Fact>]
    let ``Calculate results for example dataset correctly`` () =
        let expected = 40
        let actual =
            "./data/input.example"
            |> parse
            |> List.ofArray
            |> PartOne.findCircuits
            |> PartOne.circuitCollectionHash
        actual.Should().Be(expected)

