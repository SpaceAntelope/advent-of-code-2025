namespace Day01.Tests

open Xunit
open Day01
open System.IO


type TransitionData() =
    inherit TheoryData<int, Rotation, int>()
    do
        base.Add(11, R 8, 19)
        base.Add(19, L 19, 0)
        base.Add(0, L 1, 99)
        base.Add(99, R 1, 0)
        base.Add(5, L 10, 95)
        base.Add(95, R 5, 0)
        base.Add(66, R 100, 66)
        base.Add(66, L 100, 66)

        base.Add(11, R 500, 11)
        base.Add(11, L 500, 11)
        base.Add(19, L 119, 0)
        base.Add(0, L 1001, 99)
        base.Add(99, R 1001, 0)
        base.Add(5, R 370, 75)
        base.Add(75, L 370, 5)

module TransitionTests = 
   
    [<Theory>]
    [<ClassData(typeof<TransitionData>)>]
    let TransitionDial start rotation expected =
        let actual = Day01.Rotation.Transition rotation start
        Assert.Equal(expected, actual)
   
