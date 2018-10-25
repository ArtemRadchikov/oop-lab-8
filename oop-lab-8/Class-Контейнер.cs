using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_8
{
    class computerLab
    {
        private Goods[] arrayOfGoods = new Goods[0];

        #region property
        public Goods[] ArrayOfGoods
        {
            get
            {
                return arrayOfGoods;
            }
            set
            {
                if (value.GetType() == typeof(Goods[]))
                {
                    Console.WriteLine("Хотите приобрести все элементы(0) или только 1(1)");
                    string input;

                    do
                    {
                        Console.WriteLine("Некорректный ввод, попробуйте ещё раз");
                        input = Console.ReadLine();

                    } while (input != "1" || input != "0");

                    bool anser = bool.Parse(input);

                    if (anser)
                    {
                        if (!Int32.TryParse(input, out int choice))
                        {
                            do
                            {
                                Console.WriteLine("Некорректный ввод, попробуйте ещё раз");
                                input = Console.ReadLine();

                            } while (!Int32.TryParse(input, out choice));
                        }
                        this.Add(value[choice]);
                    }
                    else
                    {
                        arrayOfGoods = value;
                    }
                }
                else
                {
                    Console.WriteLine("Несоответствие типов");
                }
            }
        }
        #endregion

        bool counterOfProjector = true;


        #region methods
        public void Add(Goods element)
        {
            

            if (!(element is Smartphone) || (/*element.allowed()*/element is Projector && counterOfProjector))
            {
                if (/*!element.allowed()*/ element is Projector && counterOfProjector)
                {
                    counterOfProjector = false;
                }

                Array.Resize(ref arrayOfGoods, arrayOfGoods.Length + 1);
                arrayOfGoods[arrayOfGoods.Length - 1] = element;
            }
            else
            {
                if (!counterOfProjector)
                {
                    Console.WriteLine("В классе не может быть больше одного проэктора.");
                }
                else
                {
                    Console.WriteLine("Детям не нужны телефоны.");
                }
            }

        }

        public void Delete(Goods allElements = null, int numberOfElement = -1)
        {
            if (allElements != null)
            {
                int counter = 0;
                if (/*allElements.allowed()*/ allElements is Projector && !counterOfProjector)
                {
                    counterOfProjector = true;
                }
                for (int i = 0; i < arrayOfGoods.Length; i++)
                {
                    if (allElements == arrayOfGoods[i])
                    {
                        counter++;
                        for (int j = i; j < arrayOfGoods.Length - 1; j++)
                        {
                            arrayOfGoods[j] = arrayOfGoods[j + 1];
                        }
                    }
                }
                Array.Resize(ref arrayOfGoods, arrayOfGoods.Length - counter);

            }
            if (numberOfElement >= 0 && numberOfElement < arrayOfGoods.Length)
            {
                for (int i = numberOfElement; i < arrayOfGoods.Length - 1; i++)
                {
                    arrayOfGoods[i] = arrayOfGoods[i + 1];
                }
                Array.Resize(ref arrayOfGoods, arrayOfGoods.Length - 1);
            }
        }

        public void Print()
        {
            Console.WriteLine();
            foreach (Goods i in arrayOfGoods)
            {
                Console.Write(i.GetType() + "   ");
            }
            Console.WriteLine();

        }
        #endregion
    }
}

