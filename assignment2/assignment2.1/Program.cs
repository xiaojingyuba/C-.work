// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
namespace assignment
{
    class DispPrime
    {
        static List<int> getprime(int a)
        {
            List<int> primelist = new List<int>();//用列表来存储素数因子    

            int i = 2;//记录因子
            int b = a;//记录被i整除一次前的a
            while(i<=b)
            {
                //当i能整除a，则b记录被i整除一次前的a，a除以i
                if (a % i == 0) 
                { 
                    b = a; 
                    a /= i; 
                }
                //i不再能整除a时
                else if (b % i == 0)
                {
                    primelist.Add(i); //将i添加到列表中，并且不会重复
                    i++; 
                    b = a; 
                }
                else i++; 
            }
            return primelist;
        }
        static void Main()
        {
            //读入输入的数字
            Console.Write("请输入一个大于2的整数数据：");
            string strnum = Console.ReadLine();

            //判断输入数据是否为整数
            int intnum;
            bool Isint= int.TryParse(strnum, out intnum);//是整数则传给intnum

            //输入的数字有误
            if (!Isint || intnum < 2)
                {
                    Console.WriteLine("输入数据有误！");
                    return;
                }

            List<int> primelist = getprime(intnum);//计算素数因子
            Console.Write("{0}的所有素数因子为：", intnum);
            Console.WriteLine(string.Join(" ", primelist));//打印素数因子
        }
    }
}