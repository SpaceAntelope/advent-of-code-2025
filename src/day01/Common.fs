namespace Day01

module Common =

    open System.IO
    open System
    open System.Text.RegularExpressions

    type Rotation =
        | L of int
        | R of int

    module Rotation = 
        let From (line: string) =
            let m: Match = Regex.Match(line, @"(\w)(\d+)")
            let steps = Convert.ToInt32(m.Groups[2].Value)
            match m.Groups[1].Value with
            | "L" -> L steps
            | "R" -> R steps
            | _ -> failwith $"I don't know how to parse {line}"

        let Transition (r: Rotation) (dial: int)=
            match r with
            | L _steps ->
                let steps = _steps % 100
                let result = dial - steps
                if result < 0 
                then 100 + result
                else result
            | R steps -> (dial + steps) % 100
            
    let parse file = 
        file
        |> File.ReadAllLines
        |> Array.map (Rotation.From)
