module TaskStudy.Sleep

let FiveSecondsSleep =
    [1..5] |> Seq.iter (fun i -> 
    System.Threading.Thread.Sleep 1000
    printfn ".")
    ()