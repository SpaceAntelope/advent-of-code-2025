namespace Day08

module PartOne =
    open Common
    open System.Collections.Generic
    
    // type Circuit = ResizeArray<Edge>

    let tee msg (x: 'T seq) = 
        printfn "%s %O" msg x
        x
         
    let inline teef<'T> (msg:string) (f: 'T -> unit) (x: 'T) = 
            printf "%s " msg
            f x
            x

    let printEdgeList (e: Edge Set) =
            e 
            |> Seq.map _.ToString() 
            |> Seq.chunkBySize 4 
            |> Seq.map (fun x -> System.String.Join(", ", x)) 
            |> fun x -> System.String.Join('\n', x)
            |> printfn "%s"


    [<RequireQualifiedAccess>]
    module Edge =
        let isConnectable (e1: Edge) (e2: Edge) =
            e1 <> e2 
            && (e1.From = e2.From 
                || e1.To = e2.To
                || e1.From = e2.To
                || e1.To = e2.From )
        
    [<RequireQualifiedAccess>]
    module Circuit =
        type MergeResult = 
                | Merged of Edge Set
                | Unmergable of Edge seq * Edge seq

        let toSortedEdges (junctions: Coord list) =
            let lastIndex = junctions.Length - 1 
            [for i= 0 to lastIndex do for j = i+1 to lastIndex do junctions.[i], junctions.[j]]
            |> List.map (fun (a,b) -> {From = a; To = b; Distance = distance a b})
            |> List.sortBy _.Distance
            
        let toCoords (circuit: Edge seq) =
            circuit |> Seq.map _.ToCoords()

        let isConnectable(edge: Edge) (circuit : Set<Edge>) = 
            circuit |> Seq.exists (fun e -> Edge.isConnectable edge e)

        let isMergeable (circ1 : Edge seq) (circ2 : Edge seq) =
            circ1
            |> Seq.allPairs circ2 
            |> Seq.exists (fun (a,b) -> Edge.isConnectable a b)

        let merge(circ1 : Edge seq) (circ2 : Edge seq) =
            if isMergeable circ1 circ2 
            then 
                circ1 
                |> Seq.append circ2 
                |> Set.ofSeq
                |> Merged
            else 
                Unmergable (circ1,circ2)


    let groupToCircuits (junctions : Coord list) =            
        let circuits = 
            junctions
            |> Circuit.toSortedEdges 

        (List.empty<Edge>,circuits)
        ||> Seq.scan (fun state current -> 
                state
                |> List.head
                |> Circuit.merge [current]
                |> function
                | Merged x ->  

        let circuits = 
            edges
            |> List.allPairs edges
            |> List.filter (fun (a,b) -> a <> b) 
        
        ()


    let findCircuits (junctions : Coord list) =            
        junctions
        |> Circuit.toSortedEdges 
        |> List.fold (
                fun (state: ResizeArray<Edge Set>) current -> 
                    printfn "Current edge: %O" current
                    
                    state
                    |> Seq.iteri (fun i x -> printfn "%d:" i; printEdgeList x)

                    state
                    |> Seq.map (Set.count)
                    |> List.ofSeq
                    |> printfn "Edge counts: %A"

                    state
                    |> Seq.map (Seq.collect _.ToCoords())
                    |> fun x -> 
                            printf "Coords: "
                            x |> Seq.iteri (fun i c -> 
                                   printfn "%d: %O" i (c|>Seq.map _.ToString()|>Seq.reduce(+)))
                            x
                    |> Seq.map (Seq.distinct>>Seq.length)
                    |> List.ofSeq
                    |> printfn "Distinct junction counts: %A"

                    if state.Count = 0 
                    then state.Add(Set.singleton current)
                    else 
                        let mutable sentinel = true
                        for i in 0..state.Count-1 do
                            if sentinel then
                                let circuit = state.[i]                        
                                circuit
                                |> Circuit.isConnectable current
                                |> function
                                | true -> circuit.Add current |> ignore; sentinel <- false
                                | _ -> ()
                        if sentinel = true
                        then state.Add(Set.singleton current)
                    state ) (ResizeArray<Edge Set>())
        
    let circuitCollectionHash (circuits: ResizeArray<Set<Edge>>) =
        circuits
        |> Seq.map (fun c -> c |> Seq.collect _.ToCoords() |> Seq.distinct)
        |> Seq.map Seq.length
        |> Seq.sortDescending
        |> Seq.take 3        
        |> Seq.reduce (*)
    
