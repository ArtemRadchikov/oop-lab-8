using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace oop_lab_8
{
    internal class SmaleBDInFiles<T> where T : Goods
    {
        
        //FileStream file = new FileStream("SmaleBDInFiles.txt", FileMode.Open);

        public void Writing(T element) 
        {
          
            using (TextWriter write = File.CreateText("OnlyOneElement.txt"))
            {
                write.Write(element.Name+' ');
                write.Write(element.ProducingCountry + ' ');
                write.Write(element.Price);
                write.Close();
            }
        }

        public void Reading(QueueForGoods<Goods> queueForGoods)
        {
            String name, producingCountry;
            int price;
            using (TextReader read = File.OpenText("OnlyOneElement.txt"))
            {
                name = read.ReadLine();
                producingCountry = read.ReadLine();
                price = Convert.ToInt32(read.ReadLine());
                
            }
            Technique technique = new Technique(name, producingCountry, price, "2");
            queueForGoods.Enqueue(technique);
        }

    }
}
