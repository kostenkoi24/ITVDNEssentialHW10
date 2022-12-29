using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Homework10_2
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

    class Program
    {
        static void Main(string[] args)
        {
            
            /*
             Використовуючи Visual Studio, створіть проект за шаблоном Console Application. 
            Створіть клас MyList. Реалізуйте у найпростішому наближенні можливість 
            використання його екземпляра аналогічно екземпляру класу List. 
            Мінімально необхідний інтерфейс взаємодії з екземпляром повинен включати метод додавання елемента, 
            індексатор для отримання значення елемента за вказаним індексом і 
            властивість тільки для читання для отримання загальної кількості елементів.
             */

            MyList<int> myList = new MyList<int>(3);

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);


            Console.WriteLine("Get element with index 1: {0}",myList.GetElement(1));
            Console.WriteLine("Get lenght by property: {0}",myList.Length);

            Console.ReadKey();
        }
    }
}
