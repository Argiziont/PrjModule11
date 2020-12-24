using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ModuleLibrary
{
    public class MyDict<TKey,TValue>:IEnumerable<KeyValuePair<TKey, TValue>>,IDictionary<TKey, TValue>
    {
        private const int _size = 10;
        private const double _sizeBuffer = 0.6;
        private LinkedList<KeyValuePair<TKey, TValue>>[] _entries;

        public MyDict()
        {
            _entries = new LinkedList<KeyValuePair<TKey, TValue>>[_size];
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _entries = new LinkedList<KeyValuePair<TKey, TValue>>[_size];
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) =>
            ContainsKey(item.Key) && Find(item.Key).Equals(item.Value);

        
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }


        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);

        public int Count { get; private set; }
        public bool IsReadOnly { get; }

        public int Capacity => _entries.Length;

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var hash = HashKey(key);
            
            _entries[hash] ??= new LinkedList<KeyValuePair<TKey, TValue>>();
            
            //Refuse similar keys
            if (_entries[hash].Any(e => e.Key.Equals(key)))
                throw new OperationCanceledException("Key duplicate");
            _entries[hash].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            
            Count++;

            if (Count>=Capacity*_sizeBuffer)
                Resize();

        }

        private void Add(TKey key, TValue value, bool add)
        {
            if (add)
            {
                Remove(key);
            }

            Add(key, value);
        }

        public TValue Find(TKey key)
        {
            var hash = HashKey(key);
            if (_entries[hash]==null)
            {
                return default;
            }

            var collection = _entries[hash];
            return collection.First(p => p.Key.Equals(key)).Value;
        }
        public ICollection<TKey> Keys { get; }
        public ICollection<TValue> Values { get; }

        public bool ContainsKey(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var hash = HashKey(key);
            if (_entries[hash] == null)
            {
                return false;
            }

            var collection = _entries[hash];
            return collection.Any(p => p.Key.Equals(key));
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            
            if (!ContainsKey(key)) return false;
            var hash = HashKey(key);
            _entries[hash].RemoveFirst();
            return true;

        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (ContainsKey(key))
            {
                value = Find(key);
                return true;
            }

            value = default;
            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                var value = Find(key);
                return !Unsafe.IsNullRef(ref value) ? value : default;
            }
            set
            {
                value = Find(key);
                Add(key, value,true);
            }
        }

        private int HashKey(TKey key)=> Math.Abs(key.GetHashCode()) %Capacity;

        private void Resize()
        {
            var cachedEntries = _entries;
            _entries = new LinkedList<KeyValuePair<TKey, TValue>>[Count*2];
            Count = 0;
            
            foreach (var linkList in cachedEntries)
            {
                if (linkList == null) continue;
                foreach (var (key, value) in linkList)
                {
                    Add(key, value);
                }

            }

        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _entries.Where(linkList => linkList!=null).SelectMany(linkList => linkList).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}