using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_3
{
    /// <summary>
    /// 3.3 System.Linq.Async
    /// </summary>
    public class LinqWithAsyncStream
    {

        public async void Test()
        {
            //we want to do async stuff inside where clause in LINQ
            AsyncEnumerable asyncEnumerable = new AsyncEnumerable();
            var test = asyncEnumerable.GetValues().WhereAwait(async valueTask =>
            {
                //PULL-based
                await Task.Delay(100);
                return valueTask.Length > 100;
            });
            await foreach (var variable in test)
            {
                Console.WriteLine(variable);
            }
        }
    }
}