namespace Day07

module Common =
    
    open System.IO
    open System.Text.RegularExpressions

    type CellTypes = Empty | Split | Start
        with static member Parse (c: char) = 
                match c with 
                | '.' -> Empty 
                | '^' -> Split 
                | 'S' -> Start 
                | x -> failwithf "Unknown cell content %A" x
        
    
    let parse file =
        file
        |> File.ReadAllLines
        |> Array.map _.ToCharArray()
        |> array2D
        |> Array2D.map (CellTypes.Parse)