using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLibrary
{
    public static class LinqExtension
    {
        public static IEnumerable<string> WhereContains(this IEnumerable<string> source, string substring)
        {
            foreach (var item in source)
            {
                if (item.Contains(substring))
                {
                    yield return item;
                }
            }
        }


        public static IEnumerable<TResult> Select<TSource, TResult>(
                                           this IEnumerable<TSource> sources,
                                           Func<TSource, int, TResult> selector) 
        {
            int index = 0;
            foreach (var item in sources)
            {
                yield return selector(item, index);
                index++;
            }

        }
    }
}
