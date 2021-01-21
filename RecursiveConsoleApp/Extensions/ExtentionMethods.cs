using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursiveConsoleApp.Extensions
{
    public static class ExtentionMethods
    {
        // https://entityframework.net/knowledge-base/20974248/recursive-hierarchy---recursive-query-using-linq
        public static IEnumerable<T> Traverse<T>(this IEnumerable<T> items,
            Func<T, IEnumerable<T>> childSelector)
        {
            var stack = new Stack<T>(items);
            while (stack.Any())
            {
                var next = stack.Pop();
                yield return next;
                foreach (var child in childSelector(next))
                    stack.Push(child);
            }
        }
    }
}
