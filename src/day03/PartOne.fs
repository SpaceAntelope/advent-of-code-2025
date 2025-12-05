namespace Day03


module PartOne =


    let findHighestValuePair (bank: int[])=
        let revBank = bank |> Array.rev

        let pair = revBank |> Array.take 2 |> Array.rev

        for n in revBank |> Array.skip 2 do
            if n > pair.[0] 
            then 
                if pair.[0] > pair.[1] 
                then 
                    pair.[1] <- pair.[0]
                
                pair.[0] <- n
            else 
                if n = pair.[0] && n > pair.[1]
                then pair.[1] <- n

        pair.[0] * 10 + pair.[1]