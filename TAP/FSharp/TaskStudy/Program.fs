// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
open System
open TaskStudy
open TaskStudy.Basic
open TaskStudy.Sleep
open TaskStudy.HttpGetter
// Define a function to construct a message to print


[<EntryPoint>]
let main argv =
      
    
//   let Hello : Async<string> =
//        async {
//            return "Hello from async!"
//        }  
//  
//   let printHello =
//       async {
//           let! text  = Hello
//           return printf "%s" text
//       }
//   printHello |> Async.Start
//   FiveSecondsSleep
   
//   let rand = System.Random()
//   let pickNumAsync = async { return rand.Next(10) }
//   let create =
//       let workFlows = [1..50] |> Seq.map (fun _ -> pickNumAsync)
//       async{
//           let! numbs = workFlows |> Async.Parallel
//           printf "%d" (numbs |> Array.sum)
//       }
//   create |> Async.Start
//   FiveSecondsSleep
   
   ["http://www.fsharp.org"; "http://microsoft.com"; "http://fsharpforfunandprofit1.com"; "http://fsharpforfunandprofit.com"]
   |> List.map downloadString
   |> Async.Parallel
   |> Async.RunSynchronously //this line waits for all tasks to finish
   |> Array.map (fun i ->
                 match i with
                 | Some i -> i.Length.ToString()
                 | _ -> "some error happened"
                 )
   |> Array.iter Console.WriteLine
    
   0 // return an integer exit code