using System;
using System.Threading;

namespace OSRSBarrowsChestSimulator
{
    // from https://stackoverflow.com/a/11473510
    public static class RandomHelper
    {
        private static int seed;

        private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
            (() => new Random(Interlocked.Increment(ref seed)));

        static RandomHelper()
        {
            seed = Environment.TickCount;
        }

        public static Random Instance => threadLocal.Value;
    }
}
