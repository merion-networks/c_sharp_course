using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsLibrary.Helpers
{
    public static class DictionaryExtensions
    {
        public static TValue GetSorterValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default)
        {

            return dictionary.OrderBy(d => d.Value).ToDictionary().TryGetValue(key, out TValue value) ? value : defaultValue;
        }
    }
}
