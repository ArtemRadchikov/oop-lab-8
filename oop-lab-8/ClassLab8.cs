using System;
//using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Diagnostics;


namespace oop_lab_8
{
    internal static class SmaleBDInFiles<T> where T : Goods
    {   
        public static void WriteObjectIntoFile(T element)
        {
            string serialized = JsonConvert.SerializeObject(element);
            TextWriter write = null;
            try
            {
                using (write = File.CreateText("OnlyOneOject.txt"))
                {
                    write.WriteLine(serialized);                    
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

        public static void ReadObjectFromFile(QueueForGoods<Goods> queueForGoods)
        {
            //String name = "", producingCountry = "";
            //int price = 0;
            TextReader read = null;
            try
            {                
                using (read = File.OpenText("OnlyOneOject.txt"))
                {
                    string serialized = read.ReadToEnd();
                    Technique technique = JsonConvert.DeserializeObject<Technique>(serialized);
                    queueForGoods.Enqueue(technique);
                }
            }
            catch
            {
               // Debug.Assert(false, "Возникла ошибка при чтении из файла");
            }
            finally
            {
                read.Close();           
            }
        }
        
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
                read.Close();
            }
        }

    }
}
