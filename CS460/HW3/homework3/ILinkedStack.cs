using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    interface ILinkedStack<T>
    {
        //pop
        T Pop();

        //peek
        T Peek();

        //push
        void Push(T item);

        //clear
        void Clear();

        //is empty
        bool IsEmpty();
    }
}
