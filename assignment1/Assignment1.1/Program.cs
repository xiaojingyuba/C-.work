// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Please input the first number: ");//输入数字1
            string a = Console.ReadLine();
            Console.Write("Please input the operater: ");//输入运算符
            string c = Console.ReadLine();
            Console.Write("Please input the second number: ");//输入数字2
            string b = Console.ReadLine();

            double d2 = 0;//保存计算结果

            //将输入的数转为double类型
            double a2 = Convert.ToDouble(a);
            double b2 = Convert.ToDouble(b);

            //通过运算符匹配操作
            if (c == "+")  d2 = a2 + b2; 
            if (c == "-")  d2 = a2 - b2; 
            if (c == "*")  d2 = a2 * b2; 
            if (c == "/")  d2 = a2 / b2; 
            if (c == "%")  d2 = a2 % b2;

            //将结果转为string类型输出
            string d = Convert.ToString(d2);

            Console.WriteLine($"The answer of {a} {c} {b} is: {d}");
        }
    }
}
    
