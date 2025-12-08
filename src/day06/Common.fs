namespace Day06

module Common =
    
    open System.IO
    open System.Text.RegularExpressions

    type CephOp = Plus | Times 
        with static member Parse (c: char) = match c with '+' -> Plus | '*' -> Times | x -> failwithf "Unknown operator %A" x
        

    type Cephaloperation = {
        Operands: int64[]
        Operator: CephOp
    }

    module Cephaloperation =
        let from (source: string[]) =
            {
                Operands = source.[0..^1] |> Array.map int64
                Operator = source.[^0].ToCharArray() |> Array.head |> CephOp.Parse
            }

        let calculate (source: Cephaloperation) = 
            match source.Operator with
            | Plus -> source.Operands |> Array.reduce (+)
            | Times -> source.Operands |> Array.reduce (*)
            

    let parse file =
        let ops = 
            file
            |> File.ReadAllLines
            |> Array.map _.Trim()
            |> Array.map (fun line -> Regex.Split(line, @"\s+"))
            |> array2D

        let colCount = ops |> Array2D.length2

        [|  for col in 0 .. colCount-1 do
                yield Cephaloperation.from ops[*, col]  |]
            