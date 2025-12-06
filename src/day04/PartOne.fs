namespace Day04

module PartOne =

    let filterCellsByOccupiedNeighborCount desireMaxCount (grid : char array2d) =        
        let countNearbyRolls (row, col) = Common.countNearbyRolls (row,col) grid
        grid
        |> Common.indices
        |> Array.filter (fun (row,col) -> grid.[row,col] = '@' && countNearbyRolls (row,col) <= desireMaxCount)
        