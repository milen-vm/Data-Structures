using System;
using System.Collections.Generic;
using System.Linq;

public static class DictionaryExtensions
{
    public static void AppendValueToKey<TKey, TCollection, TValue>(
        this IDictionary<TKey, TCollection> dict, TKey key, TValue value)
        where TCollection : ICollection<TValue>, new()
    {
        TCollection collection;
        if (!dict.TryGetValue(key, out collection))
        {
            collection = new TCollection();
            dict.Add(key, collection);
        }

        collection.Add(value);
    }

    public static IEnumerable<TValue> GetValuesForKey<TKey, TValue>(
        this IDictionary<TKey, List<TValue>> dict, TKey key)
    {
        List<TValue> collection;
        if (dict.TryGetValue(key, out collection))
        {
            return collection;
        }

        return Enumerable.Empty<TValue>();
    }
}
