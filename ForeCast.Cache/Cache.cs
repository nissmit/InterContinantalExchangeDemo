using System.Collections.Generic;
using ForeCast.API;

namespace ForeCast.Cache
{
    public class Cache<K, V> : ICache<K,V>
    {
        private Dictionary<K, V> valuesDictionary = new Dictionary<K, V>();
        public bool Contains(K key)
        {
            return valuesDictionary.ContainsKey(key);
        }

        public void AddValue(K key, V value)
        {
            valuesDictionary[key] = value;
        }

        public V GetValue(K key)
        {
            return valuesDictionary[key];
        }

        public void UpdateValue(K key, V value)
        {
            valuesDictionary[key] = value;
        }

        public void RemoveValue(K key)
        {
            valuesDictionary.Remove(key);
        }
    }
}