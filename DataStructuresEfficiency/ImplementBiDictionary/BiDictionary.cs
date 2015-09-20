using System;
using System.Collections.Generic;

public class BiDictionary<K1, K2, T>
{
    private Dictionary<K1, List<T>> valuesByFirstKey = new Dictionary<K1,List<T>>();
    private Dictionary<K2, List<T>> valuesBySecondKey = new Dictionary<K2,List<T>>();
    private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys = new Dictionary<Tuple<K1,K2>,List<T>>();

    public void Add(K1 key1, K2 key2, T value)
    {
        this.valuesByFirstKey.AppendValueToKey(key1, value);
        this.valuesBySecondKey.AppendValueToKey(key2, value);
        this.valuesByBothKeys.AppendValueToKey(new Tuple<K1, K2>(key1, key2), value);
    }

    public IEnumerable<T> Find(K1 key1, K2 key2)
    {
        return this.valuesByBothKeys.GetValuesForKey(new Tuple<K1, K2>(key1, key2));
    }

    public IEnumerable<T> FindByKey1(K1 key1)
    {
        return this.valuesByFirstKey.GetValuesForKey(key1);
    }

    public IEnumerable<T> FindByKey2(K2 key2)
    {
        return this.valuesBySecondKey.GetValuesForKey(key2);
    }

    public bool Remove(K1 key1, K2 key2)
    {
        var doubleKey = new Tuple<K1, K2>(key1, key2);
        if (this.valuesByBothKeys.ContainsKey(doubleKey))
        {
            var values = this.valuesByBothKeys[doubleKey];
            this.valuesByBothKeys.Remove(doubleKey);
            foreach (var dist in values)
            {
                this.valuesByFirstKey[key1].Remove(dist);
                this.valuesBySecondKey[key2].Remove(dist);
            }

            return true;
        }

        return false;
    }
}
