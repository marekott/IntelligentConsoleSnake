using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.Extensions
{
    public static class RandomExtensions
    {
        public static int Next(this Random r, int minValue, int maxValue, HashSet<int> exclude)
        {
            var range = Enumerable.Range(minValue, maxValue - 1).Where(i => !exclude.Contains(i)).ToList();
            var index = r.Next(0, maxValue - exclude.Count - 1);
            return range.ElementAt(index);
        }
    }
}
