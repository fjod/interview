// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
open TaskStudy.Basic
open TaskStudy.Sleep

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
   
   let rand = System.Random()
   let pickNumAsync = async { return rand.Next(10) }
   let create =
       let workFlows = [1..50] |> Seq.map (fun _ -> pickNumAsync)
       async{
           let! numbs = workFlows |> Async.Parallel
           printf "%d" (numbs |> Array.sum)
       }
   create |> Async.Start
   FiveSecondsSleep
   0 // return an integer exit code