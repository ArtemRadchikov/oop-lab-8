using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_8
{
    /*Класс - очередь CollectionType. 
     * Дополнительно перегрузить следующие операции: 
     * / - добавить элемент; ++ - извлечь элемент; false - проверка, на содержание четных элементов в очереди;
     * явный int() количество положительных элементов в очереди 
     * Методы расширения: 
1) Выделение первого числа, содержащегося в строке  
2) Обнуление отрицательных элементов очереди */
    #region
    public class CollectionType<T>:Interface_lab_8<T> 
    {
        internal Queue<T> queue = new Queue<T>();
        public List<string> listOfBags = new List<string>();
        private int size = 0;
        private T[] masOfValue;

        public class Owner
        {
            private int id;
            private string name;
            private string organization;

            public Owner(int id, string name, string organization)
            {
                this.Id = id;
                this.Name = name;
                this.Organization = organization;
            }
            public string Organization { get => organization; set => organization = value; }
            public string Name { get => name; set => name = value; }
            public int Id { get => id; set => id = value; }
        }

        public class Date
        {
            private readonly DateTime dataOfCreation = new DateTime();

            public Date()
            {
                dataOfCreation = DateTime.Now;
            }

            public DateTime DataOfCreation => dataOfCreation;
        }
        //public CollectionType(int id, string name,string organization)
        //{
        //    Owner owner = new Owner(id, name, organization);
        //}

        //dequeue: извлекает и возвращает первый элемент очереди
        public T Dequeue()
        {
            var value = MasOfValue[0];
            for (int i = 0; i < size - 1; i++)
            {
                MasOfValue[i] = MasOfValue[i + 1];
            }
            Array.Resize(ref masOfValue, --size);
            Console.WriteLine("\nDequeue for Collections.Generic "+queue.Dequeue());
            return value;
        }

        //enqueue: добавляет элемент в конец очереди
        public void Enqueue(T value)
        {
            Array.Resize(ref masOfValue, ++size);
            MasOfValue[size - 1] = value;
            queue.Enqueue(value);
        }

        //peek: просто возвращает первый элемент из начала очереди без его удаления
        public T Peek()
        {
            var value = MasOfValue[0];
            Console.WriteLine("\n Peek for Collections.Generic " + queue.Peek());
            return value;
        }

        public void Print()
        {
            foreach (var i in masOfValue)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("\n For Collections.Generic Size:");
                Console.WriteLine(queue.Count);
        }

        //   / - добавить элемент;
        public static CollectionType<T> operator /(CollectionType<T> CollectionType, T value)
        {
            CollectionType.Enqueue(value);
            return CollectionType;
        }

        //  ++ - извлечь элемент
        public static CollectionType<T> operator ++(CollectionType<T> CollectionType)
        {
            CollectionType.Dequeue();
            return CollectionType;
        }

        public static explicit operator int(CollectionType<T> CollectionType)
        {
            int counter = 0;
            for (int i = 0; i < CollectionType.Size; i++)
            {
                if (CollectionType.MasOfValue[i].GetType() == counter.GetType())
                {
                    if (Convert.ToInt32(CollectionType.MasOfValue[i]) > 0)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        //false - проверка, на содержание четных элементов в очереди;
        public static bool operator true(CollectionType<T> CollectionType)
        {
            for (int i = 0; i < CollectionType.Size; i++)
            {
                if (CollectionType.MasOfValue[i].GetType() == typeof(int))
                {
                    if (Convert.ToInt32(CollectionType.MasOfValue[i]) % 2 == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    Debug.Assert(false, "Тип элемента очереди не int");
                    throw new FormatException("Операция не подходит для типа данного элемента");
                }
            }
            return false;
        }

        public static bool operator false(CollectionType<T> CollectionType)
        {
            for (int i = 0; i < CollectionType.Size; i++)
            {
                if (CollectionType.MasOfValue[i].GetType() == typeof(int))
                {
                    if (Convert.ToInt32(CollectionType.MasOfValue[i]) % 2 != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int Size { get => size; set => size = value; }
        public T[] MasOfValue { get => masOfValue; set => masOfValue = value; }
    }
#endregion
}