using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LikeAList
{
    class CustomList<T> : IEnumerable, ICustomList<T>
    {
        //collection - пустой многомерный массив, служит для хранения добавляемых элементов
        public T[][] collection = new T[0][];

        /// <summary>
        /// В дальнейшем многомерный массив collection, преобразуется в одномерный массив arr,
        /// для возможности перебора в цикле foreach
        /// </summary>
        public T[] arr;

        /// <summary>
        /// Здесь происходит обращение к перечислителю массива arr. 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();
        }

        /// <summary>
        /// Метод Parse - служит для элементов из зубчатого массива collection в одномерный массив arr
        /// </summary>
        private void Parse()
        {
            //idx - первый индекс массива arr
            int idx = 0;

            ///Переменная commonLength является счетчиком, который вследствии прохождения циклом по массиву
            ///collection, будет хранит число общего количества элементов в массиве
            int commonLength = 0;

            for (int i = 0; i < collection.GetLength(0); i++)
            {
                for (int j = 0; j < collection[i].Length; j++)
                {
                    commonLength++;
                }
            }

            ///в arr присваивается ссылка на пока еще пустой массив, той же размерностью что и зубчатый
            ///массив collection
            arr = new T[commonLength];

            ///Далее в цикле происходит копирование элементов массива collection в одномерный массив arr
            for (int i = 0; i < collection.GetLength(0); i++)
            {
                for (int j = 0; j < collection[i].Length; j++)
                {
                    ///Если индекс idx меньше общей длинны маcсива collection
                    if (idx < commonLength)
                    {
                        ///То в массив arr присваивается элемент из массива collection
                        arr[idx] = collection[i][j];

                        //и счетчик массива arr увеличивается на единицу
                        idx++;
                    }

                }
            }
        }

        /// <summary>
        /// Метод Add добавляет в массив collection новый массив параметров
        /// </summary>
        /// <param name="mass">Массив параметров</param>
        public void Add(params T[] mass)
        {
            //Перменная length хранит значение длины массива collection
            int length = collection.GetLength(0);

            ///newArr - новый массив, длинной на один элемент больше чем массив collection,
            ///вследствии как раз в него будет добавляться новый элемент
            T[][] newArr = new T[length + 1][];

            //Все элементы массива collection копируются в массив newArr
            for (int i = 0; i < collection.GetLength(0); i++)
            {
                newArr[i] = collection[i];
            }

            //А в конце добавляется массив параметров, которые передаются на вход в функцию
            newArr[length] = mass;

            //Переменной collection присваивается ссылка на массив arr
            collection = newArr;
            
            ///Вызывается метод Parse для копирования элементов из зубчатого массива collection в
            ///одномерный массив arr
            Parse();
        }

        /// <summary>
        /// Метод RemoveAt служит для удаления элемента из массива находящегося под индексом index
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента</param>
        public void RemoveAt(int index)
        {
            //Преобразования массива в обобщенную коллекцию newList
            List<T> newList = arr.ToList();

            //Удаление из коллекции элемента под индексом index
            newList.RemoveAt(index);

            //И обратное преобразование коллекции в массив
            arr = newList.ToArray();
        }

        /// <summary>
        /// Дополнитедьная функция ShowList, служит для вывода всех элементов зубчатого массива collection
        /// </summary>
        public void ShowList()
        {
            for (int i = 0; i < collection.GetLength(0); i++)
            {
                for (int j = 0; j < collection[i].Length; j++)
                {
                    Console.Write(collection[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
