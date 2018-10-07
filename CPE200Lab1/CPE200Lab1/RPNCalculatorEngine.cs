﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    /// <summary>
    /// The main RPNCalculatorEngine class.
    /// Push data on display into stack.
    /// This class can check number, operator on display.
    /// This class can check type of calculate.
    /// This class send data in stack to CalculatorEngine.
    /// This class receive value from CalculatorEngine and push to stack.
    /// </summary>
    /// <returns>
    /// Value in stack.
    /// </returns>
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> numbers = new Stack<string>();
            string[] parts = str.Split(' ');
            if (parts.Length == 1)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    numbers.Push(parts[i]);
                }
                else if (thisisOperator(parts[i]))
                {
                    string st;
                    st = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(unaryCalculate(parts[i],st,8));
                }
                else if (parts[i]== "%")
                {
                    try
                    {
                        string st, nd;
                        nd = numbers.Peek();
                        numbers.Pop();
                        st = numbers.Peek();
                        numbers.Pop();
                        numbers.Push(thismodCalculator(st, nd, 8));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return "E";
                    }
                }
                else if (isOperator(parts[i]))
                {
                    try
                    {
                        string st, nd;
                        nd = numbers.Peek();
                        numbers.Pop();
                        st = numbers.Peek();
                        numbers.Pop();
                        numbers.Push(calculate(parts[i], st, nd, 8));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return "E";
                    }
                }

            }
            if (numbers.Count == 1)
            {
                return numbers.Peek();
            }
            else
            {
                return "E";
            }
            // your code here

        }
    }
}
