using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LikeAList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            //Добавление в коллекцию элементов
            list.Add(1);
            list.Add(2, 3);
            list.Add(4, 5, 6);

            //Удаление из коллекции первого элемента
            list.RemoveAt(0);

            list.Count();

            //Вывод всех элементов в коллекции с помощью цикла foreach
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }
            Console.ReadLine();
        }
    }
}
