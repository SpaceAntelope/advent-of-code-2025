namespace Day02.Tests

open Xunit
open Day02.Common
open System.IO


module ParsingTests = 
    
    [<Fact>]
    let ``Parse sample ranges from string`` () =
        let expected = 
            TestData() 
            |> Seq.map (fun x -> 
                let struct (r,exp) = x.Data; 
                r)
            |> Seq.toArray
        
        let actual = 
            "./data/input.example"
            |> File.ReadAllText
            |> Range.From

        expected 
        |> Array.zip actual 
        |> Array.iter (fun (e, a) -> Assert.Equal(e, a))


  