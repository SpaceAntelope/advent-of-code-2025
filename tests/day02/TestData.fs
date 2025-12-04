namespace Day02.Tests

open Xunit
open Day02.Common
open System.IO

type TestData() =
    inherit TheoryData<Range, int64 list>()
    do
        base.Add({ First = 11; Last = 22 }, [11L;22L])
        base.Add({ First = 95; Last = 115 }, [99L] )
        base.Add({ First = 998; Last = 1012 }, [1010L])
        base.Add({ First = 1188511880; Last = 1188511890 }, [1188511885L])
        base.Add({ First = 222220; Last = 222224 }, [222222L])
        base.Add({ First = 1698522; Last = 1698528 }, [])
        base.Add({ First = 446443; Last = 446449 }, [446446L])
        base.Add({ First = 38593856; Last = 38593862 }, [38593859L])
        base.Add({ First = 565653; Last = 565659 }, [])
        base.Add({ First = 824824821; Last = 824824827 }, [])
        base.Add({ First = 2121212118; Last = 2121212124 }, [])
