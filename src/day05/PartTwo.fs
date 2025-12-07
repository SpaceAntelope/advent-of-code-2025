namespace Day05

module PartTwo =
    open Common

    // let merge (range1: Range) (range2: Range) =
    //     match range1, range2 with
    //     | r1,r2 when r1.Start > r2.Start -> failwith "Unsorted ranges"
    //     | r1, r2 when r1.Start <= r2.Start && r1.End >= r2.End -> [|r1|]
    //     | r1, r2 when r2.Start <= r1.Start && r2.End >= r1.End -> [|r2|]
    //     | r1, r2 when r1.End >= r2.Start -> [|{ Start = r1.Start; End = r2.End }|]
    //     | r1, r2 when r1.End < r2.Start -> [|r1;r2|]
    //     | r -> failwithf "Not sure what to do with %A" r
    let sprintRanges (r: Range[]) = r |> Array.fold(fun state current -> sprintf "%O %O" (state.Trim()) current) "" 
    let printRanges (r: Range[]) = r |> sprintRanges |> printfn "%s"

    let isSubsetTo (range: Range) (possibleSubset: Range) =
        range.Start <= possibleSubset.Start && range.End >= possibleSubset.End

    let isNotOverlapping (r1 : Range) (r2: Range) =
        r1.End < r2.Start || r1.Start > r2.End

    let isOverlapping (r1 : Range) (r2: Range) =
        (r1.Start < r2.Start && r1.End >= r2.Start) 
        || (r2.End >= r1.Start && r2.Start < r1.Start)

    let (|FstIsSuperset|SndIsSuperset|Overlapping|Equal|Separate|) ((r1:Range), (r2:Range)) =
        if r1 |> isSubsetTo r2 then SndIsSuperset
        elif r2 |> isSubsetTo r1 then FstIsSuperset
        elif r1 |> isOverlapping r2 then Overlapping
        elif r1 = r2 then Equal
        else Separate

    let merge (range1: Range) (range2: Range) =
        match range1, range2 with
        | FstIsSuperset -> [|range1|]
        | SndIsSuperset -> [|range2|]
        | Overlapping when range1.End >= range2.Start -> [|{ Start = range1.Start; End = range2.End}|]
        | Overlapping when range2.End >= range1.Start -> [|{ Start = range2.Start; End = range1.End}|]
        | Equal -> [|range1|]
        | Separate -> [|range1;range2|]
        | x -> failwithf "Don't know what %A are supposed to be to each other" x

    let consolidate (ranges: Range[]) = 
        let sorted = ranges |> Array.sortBy _.Start

        let mutable result = sorted
        let mutable lastResult = [||]
        //let mutable rangeLength = sorted.Length
        //let mutable prevLength = -1

        while result <> lastResult do
            lastResult <- result
            result 
                <- result
                    |> Array.fold (fun state current -> 
                        //printRanges state
                        let lastMergedRange = 
                            match state with
                            | [||] -> current
                            | _ -> Array.last state
                        
                        let newRanges = merge lastMergedRange current
                        //printfn "(%O) + (%O) = %s" lastMergedRange current (sprintRanges newRanges)
                        state
                        |> Array.take (System.Math.Max(state.Length - 1, 0))
                        |> Array.append newRanges
                        |> Array.distinct
                        |> Array.sortBy _.Start) [||]
            
            //printRanges result
        
        result

    let sumRangeMembers (ranges: Range[]) =
        ranges |> Array.fold (fun state current -> state + (current.End + 1L - current.Start)) 0L
        
    // let calculateUniqueFreshIngredientCount(db: ElfDataBase) =
