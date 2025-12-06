namespace Day04

module PartTwo =

    let removeAllPossibleRolls (grid: char array2d) =
        let mutable sentinel = true
        let mutable removedCount = 0
        while sentinel do
            let accessibleCellsIndices = PartOne.filterCellsByOccupiedNeighborCount 3 grid
            accessibleCellsIndices |> Array.iter (fun (row,col) -> grid.[row,col] <- '_')
            removedCount <- removedCount + accessibleCellsIndices.Length
            sentinel <- accessibleCellsIndices.Length > 0

        removedCount