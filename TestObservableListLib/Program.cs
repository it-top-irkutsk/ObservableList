using System;
using System.Collections.Generic;
using ObservableListLib;

namespace TestObservableListLib
{
    class Program
    {
        private static void Main(string[] args)
        {
            var list2 = new List<int>();
            
            var list = new ObservableList<int>();
            list.Changed += ShowObservableList;
            list.Changed += observableList => list2 = observableList.ToList();
            
            list.Add(5);
            foreach (var i in list2)
            {
                Console.Write($"{i}\t");
            }
            list.Add(3);
            foreach (var i in list2)
            {
                Console.Write($"{i}\t");
            }
            list.Add(7);
            foreach (var i in list2)
            {
                Console.Write($"{i}\t");
            }
            
            list.ForEach(Console.WriteLine);
            list.ForEach(x=> x + 10);
            list.ForEach(Console.WriteLine);

            list.Remove(13);

            foreach (var i in list2)
            {
                Console.Write($"{i}\t");
            }
        }

        private static void ShowObservableList(ObservableList<int> list)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            list.ForEach(x => Console.Write($"{x}\t"));
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}