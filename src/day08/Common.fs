namespace Day08

module Common =
    open System
    open System.IO
    open System.Text.RegularExpressions

    type Coord = { X: float; Y: float; Z: float }
        with 
            override x.ToString (): string =  $"{x.X}, {x.Y}, {x.Z}"

            static member From (str: string) = 
                let arr = str.Split(',')
                { X = float arr.[0]; Y = float arr.[1]; Z = float arr.[2] }
            

    type Edge = { From: Coord; To: Coord; Distance: float}
        with
            override x.ToString (): string = $"{x.From} -> {x.To}"
                    
            member x.ToCoords() = [x.From; x.To]

    let distance (a : Coord) (b: Coord) =
        Math.Sqrt((a.X - b.X)**2 + (a.Y - b.Y)**2 + (a.Z - b.Z)**2)

    let parse file =
        file
        |> File.ReadAllLines
        |> Array.map Coord.From