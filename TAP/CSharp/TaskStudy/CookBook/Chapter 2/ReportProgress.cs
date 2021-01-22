using System;
using System.Threading.Tasks;

namespace TaskStudy
{
    public static partial class CustomAwaiter
    {
        /// <summary>
        /// 2.3 way to report progress from task
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public static Task<long> Progress(IProgress<int> progress = null)
        {
            //also IProgress can be used for non-async code too
            var tcs = new TaskCompletionSource<long>();
            Task<long> t1 = tcs.Task;
            Task.Run(() =>
            {
                long ret = 0;
                for (int i = 0; i < 10; i++)
                {
                    ret+= LongRunningJob.CalcSum(1000);
                    progress?.Report(i);
                }
                tcs.SetResult(ret);
            });
            return t1;
        }
    }
}