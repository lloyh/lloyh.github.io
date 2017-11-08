using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("POSTFIX CALCULATOR");
            Console.WriteLine("Please enter postfix expression(s) to be evaluated. Press 'q' to quit.");
            LinkedStack<double> stack = new LinkedStack<double>();
            bool playAgain = true;
            string[] operators = { "+", "-", "/", "*" };
            while (playAgain)
            {
                stack.Clear();
                //get input from the user
                //string[] input = Console.ReadLine().Split(' ');
                string tempInput = Console.ReadLine();
                tempInput = tempInput.Trim();
                string[] input = new Regex(@"\s+").Split(tempInput);
                //exit if q is pressed
                if (input[0] == "q")
                {
                    playAgain = false;
                }
                else
                {
                    //do the calculation
                    foreach (string s in input)
                    {
                        //check if the input iteration is an operand
                        if (IsOperand(s))
                        {
                            try
                            {
                                stack.Push(Convert.ToDouble(s));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: Invalid character entered!!");
                                stack.Clear();
                                break;
                            }
                        }
                        else
                        {
                            int location = -1;
                            for (int i = 0; i < operators.Length; i++)
                            {
                                if (operators[i] == s)
                                {
                                    location = i;
                                }
                            }
                            if (location == -1)
                            {
                                Console.WriteLine("Invalid input detected");
                                stack.Clear();
                                break;
                            }

                            //valid operator 
                            double a = double.NegativeInfinity;
                            double b = double.NegativeInfinity;
                            //0 == +
                            if (location == 0)
                            {
                                if (stack.IsEmpty() == false)
                                {
                                    b = stack.Pop();
                                }
                                if (stack.IsEmpty() == false)
                                {
                                    a = stack.Pop();
                                }
                                if (a == double.NegativeInfinity || b == double.NegativeInfinity)
                                {
                                    Console.WriteLine("Error: The stack is currently empty, please enter a valid postfix expression");
                                    stack.Clear();
                                    break;
                                }
                                stack.Push(a + b);
                            }
                            //1 == -
                            else if (location == 1)
                            {
                                if (stack.IsEmpty() == false)
                                {
                                    b = stack.Pop();
                                }
                                if (stack.IsEmpty() == false)
                                {
                                    a = stack.Pop();
                                }
                                if (a == double.NegativeInfinity || b == double.NegativeInfinity)
                                {
                                    Console.WriteLine("The stack is currently empty!!!");
                                    stack.Clear();
                                    break;
                                }
                                stack.Push(a - b);
                            }
                            //2 == /
                            else if (location == 2)
                            {
                                if (stack.IsEmpty() == false)
                                {
                                    b = stack.Pop();
                                }
                                if (stack.IsEmpty() == false)
                                {
                                    a = stack.Pop();
                                }
                                if (a == double.NegativeInfinity || b == double.NegativeInfinity)
                                {
                                    Console.WriteLine("The stack is currently empty! Please enter a correct postfix expression.");
                                    stack.Clear();
                                    break;
                                }
                                if (b == 0)
                                {
                                    Console.WriteLine("Error: Cannot divide by 0!");
                                    stack.Clear();
                                    break;
                                }
                                                       
                                stack.Push(a / b);
                                
                                
                            }
                            //3 == *
                            else
                            {
                                if (stack.IsEmpty() == false)
                                {
                                    b = stack.Pop();
                                }
                                if (stack.IsEmpty() == false)
                                {
                                    a = stack.Pop();
                                }
                                if (a == double.NegativeInfinity || b == double.NegativeInfinity)
                                {
                                    Console.WriteLine("The stack is currently empty! Please enter a correct postfix expression.");
                                    break;
                                }
                                stack.Push(a * b);
                            }
                        }
                    }
                    //if input was valid, there should only be one item to pop from the stack, if not the input was invalid
                    if (!stack.IsEmpty())
                    {
                        Console.WriteLine("      = " + stack.Pop().ToString());
                    }              

                }

            }

        }
        /// <summary>
        /// Checks if the input is an operand
        /// </summary>
        /// <param name="value">string to be checked</param>
        /// <returns>true if input is operand</returns>
        static bool IsOperand(string value)
        {
            return new Regex(@"^(?:\d*.)?\d+$").Match(value).Success;

        }
    }
}
