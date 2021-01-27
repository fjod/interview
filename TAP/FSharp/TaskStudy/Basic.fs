module TaskStudy.Basic

open System


let testSyncSleep =
    printfn "StartSync"
    System.Threading.Thread.Sleep 3000
    printfn "After sync sleep"
    printfn "Exit sync"
    ()
    
let testASyncSleep =
    async{
        printfn "StartAsync"
        System.Threading.Thread.Sleep 3000
        printfn "After async sleep"    
    } |> Async.Start
    printfn "Exit async" 
    ()
    

    
