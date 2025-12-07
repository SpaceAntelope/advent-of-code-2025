namespace Day05

module PartOne =
    open Common
    
    let findFresh (db: ElfDataBase) =
        db.Ingredients
        |> Array.filter (fun ing -> db.Ranges |> Array.exists (Range.Contains ing))
