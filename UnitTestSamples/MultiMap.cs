using System.Collections.Generic;

namespace UnitTestSamples
{
    /// <summary>
    /// MultiMap is a dictionary that allows multiple entries per key
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class MultiMap<K, V>
    {
        #region Private data

        private readonly Dictionary<K, List<V>> _multiMap;
        #endregion

        #region Public methods
        public MultiMap()
        {
            _multiMap = new Dictionary<K, List<V>>();
        }
        public void Clear()
        {
            _multiMap.Clear();
        }
        public void Add(K key, V value)
        {
            if (_multiMap.TryGetValue(key, out var values))
            {
                values.Add(value);
            }
            else
            {
                values = new List<V> { value };
                _multiMap[key] = values;
            }
        }
        public List<V> this[K key]
        {
            get
            {
                _multiMap.TryGetValue(key, out var values);
                return values;
            }
        }
        public IEnumerable<K> Keys => _multiMap.Keys;

        public bool ContainsKey(K key)
        {
            return _multiMap.ContainsKey(key);
        }
        public bool Contains(K key, V value)
        {
            if (_multiMap.TryGetValue(key, out var values))
            {
                if (values.Contains(value))
                    return true;
            }
            return false;
        }
        #endregion
    }
}
