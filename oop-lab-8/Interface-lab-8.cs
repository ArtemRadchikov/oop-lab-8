using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_8
{
    interface Interface_lab_8<T>
    {
        void Enqueue(T value);
        T Dequeue();
        T Peek();
    }
}
