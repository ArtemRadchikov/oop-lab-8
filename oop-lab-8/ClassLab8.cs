using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace oop_lab_8
{
    internal static class SmaleBDInFiles<T> where T : Goods
    {   
    public static void Writing(T element) 
        {
            TextWriter write = null;
            try
            {
                using (write = File.CreateText("OnlyOneElement.txt"))
                {
                    write.WriteLine(element.Name);
                    write.WriteLine(element.ProducingCountry);
                    write.WriteLine(element.Price);
                    write.Close();
                }
            }
            catch
            {
                Debug.Assert(false, "Возникла ошибка при записи в файл");
            }
            finally
            {
                write.Close();
            }
        }

        public static void Reading(QueueForGoods<Goods> queueForGoods) 
        {
            String name="", producingCountry="";
            int price=0;
            TextReader read = null;
            try
            {
                using (read = File.OpenText("OnlyOneElement.txt"))
                {
                    name = read.ReadLine();
                    producingCountry = read.ReadLine();
                    price = Convert.ToInt32(read.ReadLine());

                }
            }
            catch
            {
                Debug.Assert(false, "Возникла ошибка при чтении из файла");
            }
            finally
            {
                Technique technique = new Technique(name, producingCountry, price, "2");
                queueForGoods.Enqueue(technique);
            }
        }

    }
}
