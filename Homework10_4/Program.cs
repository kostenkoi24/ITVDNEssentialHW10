using System;
using System.Diagnostics;

namespace Homework10_4
{
    interface IReadOnlyCollection<out T>
    {
        T GetElement(int index);
    }


    class MyList<T> : IReadOnlyCollection<T>
    {

        T[] _items;
        int _size;

        public MyList(int capacity)
        {
            _items = new T[capacity];
        }


        public void Add(T item)
        {
            T[] array = _items;
            int size = _size;
            if ((uint)size < (uint)array.Length)
            {
                _size = size + 1;
                array[size] = item;
            }
            else
            {
                AddWithResize(item);
            }
        }
        private void AddWithResize(T item)
        {
            Debug.Assert(_size == _items.Length);
            int size = _size;
            _size = size + 1;
            _items[size] = item;
        }

        public T GetElement(int index)
        {
            return _items[index];
        }

        public int Length { get => _items.Length; }


    }


    static class MyExtensions
    {
        public static T[] GetArray<T>(this MyList<T> list, MyList<T> myList)
        {
            T[] ts = new T[myList.Length];
            
            for (int i = 0; i < myList.Length; i++)
            {
                ts[i] = myList.GetElement(i);
            }
            
            return ts;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Використовуючи Visual Studio, створіть проект за шаблоном Console 
             * Application. Створіть метод, що розширює:
             * public static T[ ] GetArray(this MyList list) 
             * Застосуйте розширюючий метод до екземпляра типу MyList, 
             * розробленого в домашньому завданні 2 для даного уроку. 
             * Виведіть на екран значення елементів масиву, який повернув метод GetArray(),
             * що розширює метод.*/

            MyList<int> myList = new MyList<int>(3);

            myList.Add(1);
            myList.Add(2);
            myList.Add(-1);

            var r = myList.GetArray<int>(myList);

            Console.WriteLine(string.Join(",", r));
           
        }
    }
}
