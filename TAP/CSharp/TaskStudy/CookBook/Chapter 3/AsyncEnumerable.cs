using System.Collections.Generic;

namespace TaskStudy.CookBook.Chapter_3
{
    public class AsyncEnumerable
    {
        /// <summary>
        /// 3.1 - we can do async work once in a while; but on each foreach call process result from it call
        /// like, return some part of webpage until we need to download next one
        /// </summary>
        /// <returns></returns>
        public async IAsyncEnumerable<string> GetValues()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i%2==0)
                    yield return $"On {i}-s iteration loop decided to have a rest";
                var ret = await LongRunningJob.GetYandexPageContent();
                yield return $"On {i}-s iteration yandex responded with {ret} count of bytes";
            }
        }
    }
}