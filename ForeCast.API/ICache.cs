using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeCast.API
{
    public interface ICache<K, V>
    {
        V GetValue(K key);
        bool Contains(K key);
        void AddValue(K key, V value);
        void UpdateValue(K key, V value);
        void RemoveValue(K key);
    }
}
