using System.Collections.Generic;

namespace ObservableListLib
{
    public class ObservableList
    {
        #region Variable

        private List<int> _list;

        #endregion

        #region Constructor

        public ObservableList()
        {
            _list = new List<int>();
        }

        public ObservableList(IEnumerable<int> list)
        {
            _list = new List<int>(list);
        }

        public ObservableList(ObservableList list)
        {
            _list = list.ToList();
        }

        #endregion

        #region ExportMethod

        public ObservableList CopyTo()
        {
            return new ObservableList(_list);
        }

        public List<int> ToList()
        {
            return _list;
        }

        #endregion
    }
}