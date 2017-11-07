using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class LinkedStack<T> : ILinkedStack<T>
    {
        /// <summary>
        /// Top element (head of linked list)
        /// </summary>
        private Node<T> top;

        /// <summary>
        /// Stack constructor
        /// </summary>
        public LinkedStack()
        {
            top = null;
        }

        /// <summary>
        /// Stack constructor
        /// </summary>
        /// <param name="newTop"> new node name</param>
        public LinkedStack(Node<T> newTop)
        {
            top = newTop;
        }

        //pop
        /// <summary>
        /// Removes the top element on the stack and makes the next element top
        /// </summary>
        /// <returns>the top element on the stack</returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            T value = top.Data;
            top = top.Next;
            return value;
        }

        //peek
        /// <summary>
        /// Looks at the first element of the stack
        /// </summary>
        /// <returns>returns the top of the stack if it's not empty</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            return Top.Data;
        }

        //push
        /// <summary>
        /// Pushes a new node to top of stack
        /// </summary>
        /// <param name="item">node type and name to build</param>
        public void Push(T item)
        {
            Node<T> node = new Node<T>(item, top);
            top = node;
        }


        //IsEmpty
        /// <summary>
        /// Checks if there are no nodes at the top of the stack
        /// </summary>
        /// <returns>boolean value, true if it's empty (no items in the stack)</returns>
        public bool IsEmpty()
        {
            if (top == null)
            {
                return true;
            }
            else
            {
                return false;
                // return (top == null) ? true : false;
                // return (top == null);
            }
        }

        //clear
        /// <summary>
        /// resets the stack to empty
        /// </summary>
        public void Clear()
        {
            top = null;
        }


        //Properties
        /// <summary>
        /// The head of the linked list on the stack
        /// </summary>
        public Node<T> Top
        {
            get { return top; }
            set { top = value; }
        }
    }
}
