namespace Day07

module PartTwo =
    open Common
    open System.IO

    let countTheRoutes (grid: CellTypes[,]) =
        let rowCount = grid |> Array2D.length1
        let colCount = grid |> Array2D.length2
        let indexes = grid |> PartOne.allIndexes
        let startIndex = indexes |> Array.find (fun (r,c) -> grid.[r,c] = Start)
        let isInGrid r c = r >= 0 && r < rowCount && c >= 0 && c < colCount
        let cache = System.Collections.Generic.Dictionary<(int*int), int64>()

        let expand (row,col) =
            if row = rowCount-1 then [||]
            elif not (isInGrid row col)
            then [||]
            elif grid.[row+1, col] = Split 
            then [|(row+1,col-1);(row+1,col+1)|]
            else [|(row+1,col)|]
            |> Array.filter (fun (r,c ) ->isInGrid r c)

        let rec dfs row col =

            match expand (row,col) with
            | _ when cache.ContainsKey(row,col) -> cache.[row,col]
            | [||] -> 1
            | x -> 
                let result = Array.sumBy (fun (r,c) -> dfs r c ) x
                cache.Add((row,col), result)
                result

        startIndex ||> dfs 
