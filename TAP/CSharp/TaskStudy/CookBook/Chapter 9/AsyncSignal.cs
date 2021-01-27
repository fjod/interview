using System;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_9
{
    /// <summary>
    /// 12.4 to pass event between tasks once and wait for it with async
    /// </summary>
    public class AsyncSignal
    {
        private TaskCompletionSource<object> _init = new TaskCompletionSource<object>();
        private int v1;
        private int v2;

        public async Task<int> WaitForInitAsync()
        {
            Console.WriteLine("entered wait");
            await _init.Task;
            Console.WriteLine("waited ok");
            return v1 + v2;
        }

        public async Task Initialize()
        {
            Console.WriteLine("entered init");
            await Task.Delay(5555);
            v1 = 10;
            v2 = 15;
            _init.TrySetResult(null);
        }
    }
}