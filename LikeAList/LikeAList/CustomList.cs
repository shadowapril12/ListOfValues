using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LikeAList
{
    class CustomList<T> : IEnumerable, ICustomList<T>
    {
        /// <summary>
        /// Коллекция collection для хранения элементов
        /// </summary>
        List<T> collection = new List<T>();

        /// <summary>
        /// Свойство Count - возвращает количество элементов в коллекции
        /// </summary>
        public int Count
        {
            get
            {
                return collection.Count();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }
       

        /// <summary>
        /// Метод Add добавляет в массив collection новый массив параметров
        /// </summary>
        /// <param name="mass">Массив параметров</param>
        public void Add(params T[] mass)
        {
            collection.AddRange(mass);
        }

        /// <summary>
        /// Метод RemoveAt служит для удаления элемента из массива находящегося под индексом index
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента</param>
        public void RemoveAt(int index)
        {
            try
            {
                if(collection.Count > 0)
                {
                    collection.RemoveAt(index);
                }
                else
                {
                    throw new ArgumentException("Удаление - невозможно. Коллекция пустая. Добавьте элементы и попробуйте еще раз.");
                }
                
            }
            catch(ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            
        }

    }
}
