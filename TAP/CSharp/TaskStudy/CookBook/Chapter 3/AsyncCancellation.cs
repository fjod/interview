using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_3
{
    /// <summary>
    /// 3.4 how to pass cancellation token inside async stream
    /// </summary>
    public class AsyncCancellation
    {
        public async IAsyncEnumerable<int> CancelMe([EnumeratorCancellation]CancellationToken token = default)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(i * 1000,token);
                yield return await LongRunningJob.GetYandexPageContent(token);
            }
        }
    }
}