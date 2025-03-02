using System;

namespace assignment3
{
    class GetPrime
    {
        static void Main()
        {
            //用prime数组存放2-100是否为素数的bool结果，并全部初始化为true
            bool[] prime = new bool[101];
            for(int i = 0; i < 101; i++)
            {
                prime[i] = true;
            }

            //去掉所有素数i的倍数
            for (int i = 2; i < 101; i++)
            { 
                if (prime[i] == true)//判断i是否为素数
                {
                    int j = i * i;//从i的平方开始寻找
                    while ((j <= 100) && (j % i == 0))
                    {
                        prime[j] = false;//去掉所有素数i的倍数
                        j += i;
                    }    
                }
            }
            Console.Write("2~100以内的素数有： ");
            for (int i = 2; i <= 100; i++)
            {
                if (prime[i] == true)
                    Console.Write("{0} ", i);//打印所有素数
            }
        }
    }
}