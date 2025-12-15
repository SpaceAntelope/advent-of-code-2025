namespace Day07

module PartOne =
    open Common
    
    let allIndexes (grid: 'a array2d) =
        let rows = grid |> Array2D.length1
        let cols = grid |> Array2D.length2

        [| 
            for r in 0..rows - 1 do 
                for c in 0..cols - 1 do 
                    yield r,c 
        |]

    let countTheSplits (grid: CellTypes[,]) =
        let rowCount = grid |> Array2D.length1
        let colCount = grid |> Array2D.length2
        let indexes = grid |> allIndexes
        let startIndex = indexes |> Array.find (fun (r,c) -> grid.[r,c] = Start)
        
        let rec doTheSplits rowIndex (beamIndexes: int[]) splitCount =

            let newSplitters = 
                beamIndexes 
                |> Array.filter (fun col -> grid.[rowIndex, col] = Split)

            let newBeamIndexes = 
                newSplitters 
                |> Array.collect (fun col -> [|col-1;col+1|])
                |> Array.filter (fun col -> col >= 0 && col < colCount )
                |> Array.append beamIndexes
                |> Array.distinct
                |> Array.except newSplitters

            let newSplitCount = splitCount + newSplitters.Length

            if rowIndex < rowCount - 1
            then doTheSplits (rowIndex+1) newBeamIndexes newSplitCount
            else newSplitCount
        
        doTheSplits 0 [|startIndex |> snd|] 0
