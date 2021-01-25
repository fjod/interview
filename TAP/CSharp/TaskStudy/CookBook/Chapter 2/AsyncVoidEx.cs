using System;
using System.Net;
using System.Threading.Tasks;


namespace TaskStudy.CookBook.Chapter_2
{
    public static class AsyncVoidEx
    {
        public static async void Invoke()
        {
            WebClient wc = new WebClient();
            var ret = await  wc.DownloadDataTaskAsync("http://ya.ru");
            Console.WriteLine("ret from async void = " + ret.Length);
            throw new Exception("hello from async void!"); //I cant see this exception
        }
        //so if I must use async void, use try-catch block inside
        //or if there is SyncronizationContext -> there is some exception handler inside 
    }

    public static class AsyncVoidWrap
    {
        public static Task Invoke()
        {
            try
            {
                AsyncVoidEx.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //even here
            }

            return Task.CompletedTask;
        }
    }
    
    
}