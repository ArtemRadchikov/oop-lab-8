using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_8
{
    
    abstract partial class Goods: IGoods,IOwner
    {
        
        private int price;
        private string producingCountry;
        private string name;

        public int Price { get => price; set => price = value; }
        public string ProducingCountry { get => producingCountry; set => producingCountry = value; }
        public string Name { get => name; set => name = value; }

        public Goods(string name, string producingCountry,  int price):this()
        {
            this.Name = name;
            this.ProducingCountry = producingCountry;
            this.Price = price;
        }

        //реализация интерфейсов
        public virtual float Discount()
        {
            //переопределил в технике
            float resolt;
            if(price>1000000)
            {
                resolt = (float)(0.85 * price);
            }
            else
            {
                resolt = (float)(0.9 * price);
            }
            return resolt;
        }

        public virtual string Manufacturer { get { return producingCountry ;} set { throw new GoodsException("Поипытка изменения производителя у товара!"); } }

        //public string Manufacturer => throw new NotImplementedException();

        abstract public void Print();

        public override int GetHashCode()
        {
            return Price;
        }

        public override bool Equals(object obj)
        {
            if (Price > obj.GetHashCode())
            {
                return true;
            }
            else
            { 
            return false;
            }

        }
        public abstract override string ToString();
        public virtual bool allowed()
        {
            return true;
        }
    }

    [Serializable]
    class Table : Goods
    {
        private string material;
        public Table(string name, string producingCountry, int prise, string material) : base (name,producingCountry,prise)
        {
            this.Material = material;    
        }

        public override void Print()
        {
            Console.WriteLine("Имя товара: {0}\tСтрона-производитель:{1}\tЦена:{2}\t", Name, ProducingCountry, Price);
        }

        public string Material { get => material; set => material = value; }

        public override string ToString()
        {
            return GetType() + "\n" + Name + "\n" + ProducingCountry + "\n" + Price;
        }
    }

    [Serializable]
    sealed class Screan:Goods
    {
        private int height;
        private int width;

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        public Screan(string name, string producingCountry, int prise, int height,int width) : base(name, producingCountry, prise)
        {
            this.Height = height;
            this.Width = width;
        }

        public override void Print()
        {
            Console.WriteLine("Имя товара: {0}\tСтрона-производитель:{1}\tЦена:{2}\tРазрешение:{3}x{4}", Name, ProducingCountry, Price,Height,Width);
        }

        public override string ToString()
        {
            return "Type: " + GetType() + "Имя товара: " + Name + "\t Строна-производитель:" + ProducingCountry + "\t Цена: " + Price;
        }
    }

    [Serializable]
    class Technique : Goods
    {
        private string operationPeriod;
        private string owner;
        public Technique(string name, string producingCountry, int prise, string operationPeriod) : base(name, producingCountry, prise)
        {
            this.OperationPeriod = operationPeriod;
            Console.WriteLine("Введите название компании-производителя:");
            string input = Console.ReadLine();
            if (input == null)
            {
                throw new NullTechniqueException("Пустое имя при создание владельца Technique");
            }
            else
            {
                this.Owner = input;
            }
        }

        public override string ToString()
        {
            return "\n" +GetType() + "\n" + Name + "\n" + Owner + "\n" + Price;
        }


        public override void Print()
        {
            Console.WriteLine("Имя товара: {0}\tСтрона-производитель:{1}\tЦена:{2}\t", Name, ProducingCountry, Price);
        }

        //sealed - запрет переопределения метода(и свойсв_
        //base- дайт доступ к членам базового класса
        public override sealed float Discount()
        {
            float resolt;
            if (base.Price > 1000000 && ProducingCountry!="China")
            {
                resolt = (float)(0.8 * base.Price);
            }
            else
            {
                resolt = (float)(0.9 * Price);
            }
            return resolt;
        }
        
        
        public override string Manufacturer { get { return owner; } set { throw new TechniqueException("Поипытка изменения производителя у техники!"); } }

        public string OperationPeriod { get => operationPeriod; set => operationPeriod = value; }
        public string Owner { get => owner; set => owner = value; }

        // new fun
        public int Installment()
        {
            int result;
            int input;
            string consoleInput;

            Console.WriteLine("Введитеколичество выплат, которое вы бы зотели совершить: ");
            consoleInput = Console.ReadLine();
            if (!int.TryParse(consoleInput, out input))
            {
                throw new FormatException("Не верное преобразование");
            }
            result = this.Price / input;
            return result;
        }
    }

    [Serializable]
    class Monitor:Technique
    {
        private int diagonal;

        public Monitor(string name, string producingCountry, int prise, string operationPeriod,int diagonal):base(name, producingCountry, prise, operationPeriod)
        {
            this.Diagonal = diagonal;
        }

        public int Diagonal { get => diagonal; set => diagonal = value; }
    }

    class Headphones:Technique
    {
        private ConsoleColor color;

        public Headphones(string name, string producingCountry, int prise, string operationPeriod, ConsoleColor color) : base(name, producingCountry, prise, operationPeriod)
        {
            this.Color = color;
        }

        public new void Print()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Имя товара: {0}\tСтрона-производитель:{1}\tЦена:{2}\t", Name, ProducingCountry, Price);
            Console.ForegroundColor =ConsoleColor.Gray;
        }

        public ConsoleColor Color { get => color; set => color = value; }
    }
    //Композиция
    class PC : Technique
    {
        private Monitor monitorPC;
        internal Headphones HeadphonesPS {get;set;}

        public PC(string name, string producingCountry, int prise, string operationPeriod) : base(name, producingCountry, prise, operationPeriod)
        {
            this.MonitorPC=new Monitor("MonitorPC","Chine",0,"2года",20);
            this.HeadphonesPS = new Headphones("HeadphonesPC", "Chine", 0, "2года", ConsoleColor.Red);
        }

        internal Monitor MonitorPC { get => monitorPC; set => monitorPC = value; }
    }
    //Агрегация
    class Projector :Technique
    {
        private bool wirelessCommunication;
        private Screan screan;

        public Projector(string name, string producingCountry, int prise, string operationPeriod, bool wirelessCommunication,Screan screan) : base(name, producingCountry, prise,operationPeriod)
        {
            this.WirelessCommunication = wirelessCommunication;
            this.Screan = screan;
        }

        public override bool allowed()
        {
            return false;
        }

        public bool WirelessCommunication { get => wirelessCommunication; set => wirelessCommunication = value; }
        internal Screan Screan { get => screan; set => screan = value; }
    }

    //class TestForSealed : Screan{}//не может быть производным от запечатанного типа 
    [Serializable]
    abstract class Phone:Technique
    {
        public long Number { get; set; }
        abstract public void Call();
        public Phone(string name, string producingCountry, int prise, string operationPeriod,long number) : base(name, producingCountry, prise, operationPeriod)
        {
            this.Number = number;
        }

        
    }
    [Serializable]
    class Smartphone : Phone, ICommonFunctionsForPhones, ICommonFunctionsForSmartphones
    {
        public Smartphone(string name, string producingCountry, int prise, string operationPeriod, long number,bool wifiConnection) : base(name, producingCountry, prise, operationPeriod, number)
        {
            this.WiFiConnection = wifiConnection;
        }

        public bool WiFiConnection { get; set; }

        void ICommonFunctionsForPhones.Call()
        {
            Console.WriteLine("Звонки доступны по номеру{0}", base.Number);
        }
        public override void Call()
        {
            Console.WriteLine("Для получения подробной информации о функции Call, обратитесь по номеру *141*3*1#");
        }

        void ICommonFunctionsForSmartphones.Call()
        {
            //Console.WriteLine("Звонки доступны по номеру{0}", base.Number);

            if (WiFiConnection)
            {
                Console.WriteLine("Возможны звонки через интернет");
            }
            else
            {
                Console.WriteLine("Интернет соединение отсутствует");
            }
        }

        public override bool allowed()
        {
            return false;
        }
    }
    [Serializable]
    class Printer
    {
        public virtual void IAmPrinting(Goods goods)
        {
            Console.WriteLine(goods.GetType());
            Console.WriteLine(goods.ToString());
        }
    }
}
