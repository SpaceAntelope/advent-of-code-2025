namespace Day03

module Common =

    open System.IO
    open System
    open System.Text.RegularExpressions
            
    let parseBank (bank: string) =
        bank.ToCharArray()
        |> Array.map (fun c -> int (c - '0'))

    let parse (path: string) = 
        path
        |> File.ReadAllLines        
        |> Array.map parseBank
