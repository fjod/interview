module TaskStudy.HttpGetter

open System
open System.Net.Http

let client = new HttpClient()
let downloadString (uri:string)  =
    let GoodUri = new Uri(uri)
    async{
       try
        let! data = client.GetStringAsync(GoodUri) |> Async.AwaitTask
        return Some data    
       with
       | :? System.Exception  -> return None        
       
    }
    