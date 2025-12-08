namespace Day06

module PartTwo =
    open Common
    open System.IO

    let parse file = 
        let grid = 
            file
            |> File.ReadAllLines
            |> Array.map _.ToCharArray()
            |> array2D
        
        let colCount = grid |> Array2D.length2

        let buffer = ResizeArray<char[]>()

        [|  for col in colCount - 1 .. -1 .. 0 do
                match grid[*,col] with
                | col when col |> Array.forall(fun x -> x = ' ') -> 
                    yield buffer |> Array.ofSeq
                    buffer.Clear()
                | col -> buffer.Add(col)

            yield buffer |> Array.ofSeq
        |]
        |> Array.map(fun slice -> 
            {
                Operands = slice |> Seq.map (fun chars -> new System.String(chars)) |> Seq.map _.Trim([|'+';'*';' '|]) |> Seq.map int64 |> Seq.toArray
                Operator = slice |> Seq.collect id |> Seq.filter (fun c -> c = '*' || c = '+') |> Seq.head |> CephOp.Parse
            })

