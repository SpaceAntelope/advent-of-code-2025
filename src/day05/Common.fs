namespace Day05

module Common =
    
    open System.IO

    let isNullOrWhitespace x = System.String.IsNullOrWhiteSpace(x)

    type Range = 
        { Start: int64; End: int64 }     
            with 
                member x.Contains(value: int64) = value >= x.Start && value <= x.End
                override x.ToString() = $"{x.Start}-{x.End}"
    module Range =
        let Contains value (range: Range) = value >= range.Start && value <= range.End

    type ElfDataBase = {
        Ranges: Range[]
        Ingredients: int64[]
    }
    

    let parseRange (s: string) : Range =
        let parts = s.Split('-')
        { Start = int64 parts.[0]; End = int64 parts.[1] }

    let parse file =
        let lines =
            file
            |> File.ReadAllLines
        
        {   Ranges = lines
                        |> Array.takeWhile (isNullOrWhitespace>>not)
                        |> Array.map parseRange
            Ingredients = lines 
                            |> Array.skipWhile (isNullOrWhitespace>>not) 
                            |> Array.skip 1 
                            |> Array.map int64 }

