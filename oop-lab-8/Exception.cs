using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_8
{
    class GoodsException:Exception
    {
        public GoodsException(string message) : base(message)
        {
            Console.WriteLine("Вызвано исключение для Goods");
        }
        public void GetInformation()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + base.Message + '\n' + "Источник: " + base.Source+'\n'+ base.TargetSite + '\n' + base.StackTrace+ '\n');
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class TechniqueException:GoodsException
    {
        public TechniqueException(string message) : base(message)
        {
            Console.WriteLine("Вызвано исключение для Technique");
        }
    }

    class NullTechniqueException : TechniqueException
    {
        public NullTechniqueException(string message) : base(message)
        {
            Console.WriteLine("Вызвано исключение для Monitor");
        }
    }

    class YearException:TechniqueException
    {
        public YearException(string message) : base(message)
        {
            Console.WriteLine("Вызвано исключение связанное с вводом даты");
        }

    }


}
