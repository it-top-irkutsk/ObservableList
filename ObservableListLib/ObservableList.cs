using System;
using System.Collections;
using System.Collections.Generic;

namespace ObservableListLib
{
    public class ObservableList<T> : ICloneable, ICollection<T>
    {
        #region Variable

        private readonly List<T> _list;

        public event Action<ObservableList<T>> Changed; 

        public int Count { get; private set; }
        public bool IsReadOnly { get; init; }

        #endregion

        #region Constructor

        public ObservableList()
        {
            _list = new List<T>();
            Count = 0;
            IsReadOnly = false;
        }

        public ObservableList(IEnumerable<T> list)
        {
            _list = new List<T>(list);
            Count = _list.Count;
            IsReadOnly = false;
        }

        public ObservableList(ObservableList<T> list)
        {
            _list = list.ToList();
            Count = list.Count;
            IsReadOnly = false;
        }

        #endregion

        #region ExportMethod

        public void CopyTo(T[] array, int arrayIndex)
        {
            //TODO Сделать проверки
            for (int i = arrayIndex, j = 0; i < array.Length; i++, j++)
            {
                array[i] = _list[j];
            }
        }
        
        public object Clone()
        {
            return new ObservableList<T>(_list);
        }

        public List<T> ToList()
        {
            return _list;
        }

        #endregion

        #region Methods

        public void Add(T item)
        {
            _list.Add(item);
            Count++;
            Changed?.Invoke(this);
        }
        
        public bool Remove(T item) 
        {
            var res = _list.Remove(item);
            Count--;
            Changed?.Invoke(this);
            return res;
        }

        public void Clear()
        {
            _list.Clear();
            Count = 0;
            Changed?.Invoke(this);
        }

        public bool Contains(T item) => _list.Contains(item);

        public void Sort()
        {
            _list.Sort();
        }

        #endregion
        
        public IEnumerator<T> GetEnumerator()
        {
            //TODO Реализовать GetEnumerator()
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //TODO Реализовать GetEnumerator()
            return GetEnumerator();
        }

        #region ForEach

        public void ForEach(Action<T> action)
        {
            foreach (var i in _list)
            {
                action(i);
            }
        }

        public void ForEach(Func<T, T> func)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i] = func(_list[i]);
            }
        }

        #endregion
    }
}