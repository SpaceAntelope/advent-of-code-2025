namespace Day04

module Common = 
    open System.IO

    let parse file = 
        file
        |> File.ReadAllLines
        |> Array.map _.ToCharArray()
        |> array2D

    let neighbourhoodIndices (row: int,col: int)  =
        [|  row-1,col-1; row-1,col;  row-1,col+1
            row,  col-1;(*row,col*)  row  ,col+1
            row+1,col-1; row+1,col;  row+1,col+1 |]
        
    

    let neighbourhood (row: int,col: int) (grid : 'T array2d) =
        let rowCount = grid |> Array2D.length1
        let colCount = grid |> Array2D.length2
        (row,col)
        |> neighbourhoodIndices
        |> Array.filter (fun (row,col) -> row >= 0 && col >= 0 && row < rowCount && col < colCount)
        |> Array.map (fun (row,col) -> grid.[row,col])

    let indices<'T> (grid : 'T array2d) =
        let rows = grid |> Array2D.length1
        let cols = grid |> Array2D.length2
        [|
            for row in 0 .. rows-1 do
                for col in 0 .. cols-1 do
                    yield row,col
        |]