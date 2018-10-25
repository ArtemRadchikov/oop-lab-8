using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_8
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Program-lab-4 Task 1-2, без ограничений 
           
             CollectionType<int> CollectionType = new CollectionType<int>();
            CollectionType<string> StringQueue = new CollectionType<string>();
            //CollectionType<int>.Owner owner = new CollectionType<int>.Owner(111, "Artem", "BSTU");
            //CollectionType<int>.Date date = new CollectionType<int>.Date();
            //Console.WriteLine(date.DataOfCreation.DayOfWeek);

            //Print(" Создать заданный в варианте класс. Определить в классе необходимые методы, конструкторы, индексаторы и заданные перегруженные операции.");
            Print("Работа с очередью типа int /n добавление:");
            
            CollectionType.Enqueue(1);
            CollectionType.Enqueue(2);
            CollectionType.Enqueue(3);
            CollectionType.Enqueue(4);

            Console.WriteLine($"Вывод размера : {CollectionType.Size}");
            CollectionType.Print();

            Print("Удаление элемента:");
            Console.WriteLine(CollectionType.Dequeue());
            CollectionType.Print();

            Print("Вывод элемента:");
            Console.WriteLine(CollectionType.Peek());
            CollectionType.Print();


            int resolt = (int)CollectionType;
            Console.WriteLine(resolt);

            if (CollectionType)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);
           
            

        //Print(" Создайте статический класс MathOperation, содержащий 3 метода для работы с вашим классом (по варианту п.1): поиск максимального, минимального, подсчет количества элементов. ");
        //Console.WriteLine(MathOperation.FindMax(CollectionType));
        //    Console.WriteLine(MathOperation.FindMin(CollectionType));
        //    Console.WriteLine(MathOperation.Size(CollectionType));

        //    Print("Добавьте к классу MathOperation методы расширения для типа string и  вашего типа из задания№1. См. задание по вариантам.");

        
            try
            {
                Print("Работа с очередью типа стринг");
                StringQueue.Enqueue("df123dfs");
                StringQueue.Enqueue("452454s");
                //int number = StringQueue.Peek().TheFirstNumberInTheString();
                //Console.WriteLine($"{StringQueue.Peek()} \nПервое число: {number}\n\n");

                if (StringQueue)
                {
                    Console.WriteLine(true);
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                
            }
            //    CollectionType = CollectionType / -23;
            //    CollectionType = CollectionType / -75;
            //    CollectionType.Print();
            //    CollectionType.ZeroingOfNegativeItemsInTheQueue();
            //    CollectionType.Print();

            void Print(string str)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine('\n' + str);
                Console.ForegroundColor = ConsoleColor.Gray;
            }




            #endregion

            #region Task 2-3-доп

            QueueForGoods<Goods> queueForGoods = new QueueForGoods<Goods>();
            Goods goodsExample = new Technique("Товар-техника", "РФ", 498500, "5 year");
            Technique tecniqueExample = new Technique("Техника", "РБ", 23333, "2 year");
            Technique headphones = new Headphones("Наушники", "РБ", 44444, "1 года", ConsoleColor.Blue);
            Printer printer = new Printer();

            queueForGoods.Enqueue(goodsExample);
            queueForGoods.Enqueue(tecniqueExample);
            queueForGoods.Enqueue(headphones);

            queueForGoods.Print();
            #endregion

            SmaleBDInFiles<Goods> smaleBDInFiles = new SmaleBDInFiles<Goods>();

            smaleBDInFiles.Writing(queueForGoods.MasOfValue[0]);
            smaleBDInFiles.Writing(queueForGoods.MasOfValue[1]);
            Console.ForegroundColor = ConsoleColor.Green;

            queueForGoods.Print();

            smaleBDInFiles.Reading(queueForGoods);

            Console.ForegroundColor = ConsoleColor.Blue;
            queueForGoods.Print();


        }
    }
}
