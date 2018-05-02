using System;
using System.Collections.Generic;
using System.Text;

namespace LikeAList
{
    interface ICustomList<T>
    {
        /// <summary>
        /// Add - метод добавления в коллекцию элементов
        /// </summary>
        /// <param name="mass"></param>
        void Add(params T[] mass);

        /// <summary>
        /// RemoveAt - метод удаления элемента из коллекции по индексу
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента из коллекции</param>
        void RemoveAt(int index);

        void Count();
    }
}
