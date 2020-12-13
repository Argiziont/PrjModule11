#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ModuleLibrary
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        #region NotImplemented
        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) =>
            throw new NotImplementedException();


        #endregion

        private struct KeyTValuePairs
        {
            public TKey Key { get; set; } 
            public TValue Value { get; set; }
        }
        
        private KeyTValuePairs[]? _pairs;

        public MyDictionary()
        {
            _pairs = Array.Empty<KeyTValuePairs>();
        }

        public int Count
        {
            get
            {
                Debug.Assert(_pairs != null, nameof(_pairs) + " != null");
                return _pairs.Length;
            }
        }

        /// <summary>
        /// Adds element to Dictionary by key and value
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (_pairs == null) return;

            Array.Resize(ref _pairs, _pairs.Length + 1);

            _pairs[^1] = new KeyTValuePairs() {Key = key, Value = value};
        }

        /// <summary>
        /// Adds element to Dictionary by KeyValuePair
        /// </summary>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            var (key, value) = item;
            Add(key, value);
        }

        /// <summary>
        /// Clears Dictionary
        /// </summary>
        public void Clear() => _pairs = Array.Empty<KeyTValuePairs>();

        /// <summary>
        /// Checks if Dictionary contains KeyValuePair
        /// </summary>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            var (key, value) = item;
            return (_pairs?.Where(pair => EqualityComparer<TValue>.Default.Equals(pair.Value, value))!).Any() && ContainsKey(key);
        }

        /// <summary>
        /// Checks if Dictionary contains specific Key
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return (_pairs?.Where(pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key))!).Any();
        }

        /// <summary>
        /// Removes element from Dictionary by specific Key
        /// </summary>
        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            var newEntry= _pairs?.Where(pair => !EqualityComparer<TKey>.Default.Equals(pair.Key, key)).ToArray();
            if (newEntry!.Length == _pairs!.Length)
                return false;

            _pairs = newEntry;

            return true;
        }

        /// <summary>
        /// Removes element from Dictionary by specific Key
        /// </summary>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var (key, value) = item;
            if (!(_pairs?.Where(pair => EqualityComparer<TValue>.Default.Equals(pair.Value, value))!).Any())
                return false;

            Remove(key);
            return true;
        }
    }
}
