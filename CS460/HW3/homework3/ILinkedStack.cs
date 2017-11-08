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
        /// <summary>
        /// Templated declaration for Pop function
        /// </summary>
        /// <returns>Templated element on top of stack</returns>
        T Pop();

        //peek
        /// <summary>
        /// Templated declaration for Peek function
        /// </summary>
        /// <returns>Value on top of the stack if stack is not empty</returns>
        T Peek();

        //push
        /// <summary>
        /// Templated declaration for Push function, pushes T item to top of stack
        /// </summary>
        /// <param name="item"></param>
        void Push(T item);

        //clear
        /// <summary>
        /// Clears the stack, turns top node null
        /// </summary>
        void Clear();

        //is empty
        /// <summary>
        /// Checks if stack is empty
        /// </summary>
        /// <returns>returns true if stack is empty, otherwise returns false</returns>
        bool IsEmpty();
    }
}
