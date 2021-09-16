using System;
using System.Collections;
using System.Collections.Generic;

namespace ObservableListLib
{
    public class ObservableList : ICloneable, ICollection<int>
    {
        #region Variable

        private List<int> _list;

        public event Action<ObservableList> Changed; 

        public int Count { get; private set; }
        public bool IsReadOnly { get; init; }

        #endregion

        #region Constructor

        public ObservableList()
        {
            _list = new List<int>();
            Count = 0;
            IsReadOnly = false;
        }

        public ObservableList(IEnumerable<int> list)
        {
            _list = new List<int>(list);
            Count = _list.Count;
            IsReadOnly = false;
        }

        public ObservableList(ObservableList list)
        {
            _list = list.ToList();
            Count = list.Count;
            IsReadOnly = false;
        }

        #endregion

        #region ExportMethod

        public void CopyTo(int[] array, int arrayIndex)
        {
            //TODO Сделать проверки
            for (int i = arrayIndex, j = 0; i < array.Length; i++, j++)
            {
                array[i] = _list[j];
            }
        }
        
        public object Clone()
        {
            return new ObservableList(_list);
        }

        public List<int> ToList()
        {
            return _list;
        }

        #endregion

        #region Methods

        public void Add(int item)
        {
            _list.Add(item);
            Count++;
            Changed?.Invoke(new ObservableList(_list));
        }
        
        public bool Remove(int item) 
        {
            var res = _list.Remove(item);
            Count--;
            Changed?.Invoke(new ObservableList(_list));
            return res;
        }

        public void Clear()
        {
            _list.Clear();
            Count = 0;
            Changed?.Invoke(new ObservableList());
        }

        public bool Contains(int item) => _list.Contains(item);

        #endregion
        
        public IEnumerator<int> GetEnumerator()
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

        public void ForEach(Action<int> action)
        {
            foreach (var i in _list)
            {
                action(i);
            }
        }

        public void ForEach(Func<int, int> func)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i] = func(_list[i]);
            }
        }

        #endregion
    }
}