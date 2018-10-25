using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_8
{
    public static class MathOperation
    {
        public static int FindMin(CollectionType<int> CollectionType)
        {
            int min = CollectionType.MasOfValue[0];

            for (int i = 0; i < CollectionType.Size; i++)
            {
                if (min > CollectionType.MasOfValue[i])
                {
                    min = CollectionType.MasOfValue[i];
                }
            }
            return min;
        }
        public static int FindMax(CollectionType<int> CollectionType)
        {
            int max = CollectionType.MasOfValue[0];

            for (int i = 0; i < CollectionType.Size; i++)
            {
                if (max < CollectionType.MasOfValue[i])
                {
                    max = CollectionType.MasOfValue[i];
                }
            }
            return max;
        }
        public static int Size(CollectionType<int> CollectionType)
        {
            return CollectionType.Size;
        }

        public static int TheFirstNumberInTheString(this string str)
        {
            int number=0;
            string helpString="";
            for(int i=0;i<str.Length;i++)
            {
                if(str[i]>='0' && str[i]<='9')
                {
                    do
                    {
                        helpString += str[i];
                        i++;
                    }
                    while (str[i] >= '0' && str[i] <= '9');
                    break;
                }
                
            }
            if (int.TryParse(helpString, out number))
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

        public static void ZeroingOfNegativeItemsInTheQueue(this CollectionType<int> CollectionType)
        {
            for(int i=0;i<CollectionType.Size;i++)
            {
                if(CollectionType.MasOfValue[i]<0)
                {
                    CollectionType.MasOfValue[i] = 0;
                }
            }
        }


    }
}
