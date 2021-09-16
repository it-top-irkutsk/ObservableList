using System;
using ObservableListLib;

namespace TestObservableListLib
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ObservableList();
            
            list.Add(5);
            list.Add(3);
            list.Add(7);
            
            list.ForEach(Console.WriteLine);
            list.ForEach(x=> x + 10);
            list.ForEach(Console.WriteLine);
        }
    }
}