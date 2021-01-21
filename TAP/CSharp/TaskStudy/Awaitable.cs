using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy
{
    public static class CustomAwaiter
    {
        public static async Task<long> TryAwaitCustomType(CancellationToken token)
        {
            MyAwaitable test = new MyAwaitable(token);
            var ret = await test;
            Console.WriteLine($"Awaitable type calculated {ret} value from long-running job!");
            return ret;
        }

        public static Task<long> TryTCSAwaiter()
        {
            var tcs = new TaskCompletionSource<long>();
            Task<long> t1 = tcs.Task;
            Task.Run(() =>
            {
                var ret = LongRunningJob.CalcSum();
                Console.WriteLine($"Awaitable type calculated {ret} value from long-running job!");
                tcs.SetResult(ret);
            });
            return t1;
        }
    }

    //https://stackoverflow.com/questions/51375326/how-to-implement-the-oncompleted-method-of-a-custom-awaiter-correctly
    public struct MyAwaitable
    {
        private volatile bool _finished ;
        public bool IsFinished => _finished;
        public event Action Finished;

        public void Finish()
        {
            if (_finished) return;
            _finished = true;
            Finished?.Invoke();
        }

        public MyAwaitable(CancellationToken token)
        {
            _token = token;
            _finished = false;
            Finished = null;
        }

        public CancellationToken _token;
        public MyAwaiter GetAwaiter()
        {
            return new(this);
        }
    }

    public class MyAwaiter : INotifyCompletion
    {
        private readonly MyAwaitable _awaitable;
        private long _result;

        public MyAwaiter(MyAwaitable awaitable)
        {
            _awaitable = awaitable;
            Task.Run(SetResult).ContinueWith(_ => awaitable.Finish());
        }

        public bool IsCompleted => _awaitable.IsFinished;

        public long GetResult()
        {
            if (IsCompleted) return _result;

            var wait = new SpinWait();
            while (!IsCompleted)
                wait.SpinOnce();
            return _result;
        }

        public void OnCompleted(Action continuation)
        {
            if (IsCompleted)
            {
                continuation();
                return;
            }

            var capturedContext = SynchronizationContext.Current;
            _awaitable.Finished += () =>
            {
                if (capturedContext != null)
                    capturedContext.Post(_ => continuation(), null);
                else
                    continuation();
            };
        }

        private void SetResult()
        {
            _result = LongRunningJob.CalcSum(_awaitable._token);
        }
    }
}