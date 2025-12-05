namespace Day03


module PartTwo =
    open System

    let findHighestValueDozen (bank: int[])=
        let revBank = bank |> Array.rev

        let dozen = revBank |> Array.take 12 |> Array.rev

        for n in revBank |> Array.skip 12 do
            let mutable carried = n
            let mutable i = 0

            while i <= 11 do
                if carried >= dozen.[i] 
                then 
                    let temp = dozen.[i]
                    dozen.[i] <- carried
                    carried <- temp
                else i <- 1000

                i <- i + 1
               
        dozen |> Array.map string |> Array.reduce(+) |> Convert.ToInt64