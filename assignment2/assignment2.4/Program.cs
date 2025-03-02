using System;
namespace assignment4
{
    class IsToplitz
    {
        static void Main()
        {
            bool flag = true;//在任何环节输入有误，标志位改为false，不再继续进行

            int M = 0, N = 0;
            getMN(ref M, ref N, ref flag);//从控制台读入行数列数

            int[,] arr = new int[M, N];
            if (flag == true)
                createarr(ref M, ref N, ref arr, ref flag);//根据输入数据创建二维数组

            if (flag == true)
            {
                bool result = Istoplitz(arr, M, N);
                Console.WriteLine(result);
            }
        }

        //从控制台读入行数列数
        static void getMN(ref int M,ref int N,ref bool flag)
        {
            Console.Write("请输入二维数组的行数：");
            string m0 = Console.ReadLine();
            bool Isintm = int.TryParse(m0, out M);//判断输入数据是否为整数，是则传给M
            
            if (!Isintm || M <= 0)//若不是整型或数字小于零，则输入的数字有误
            {
                Console.WriteLine("输入行数有误！");flag = false;
                return;
            }

            Console.Write("请输入二维数组的列数：");
            string n0 = Console.ReadLine();
            bool Isintn = int.TryParse(n0, out N);//同理
            
            if (!Isintn || N <= 0)//同理
            {
                Console.WriteLine("输入列数有误！"); flag = false;
                return;
            }
        }

        //根据控制台输入创建二维数组
        static void createarr(ref int M, ref int N,ref int[,] arr, ref bool flag)
        {
            for (int i = 0; i < M; i++)
            {
                Console.WriteLine("请输入第{0}行数据（整数），并以空格分隔：", i + 1);
                string input = Console.ReadLine();
                string[] strarr = input.Split(new[] { ' ' });

                int length = strarr.Length;
                if (length != N)//如果输入的一行的数据个数与列数不匹配
                {
                    Console.WriteLine("输入数据个数有误!"); flag = false;
                    return;
                }

                int[] intarr = new int[length];
                for (int j = 0; j < length; j++)
                {
                    //将每个字符转为整型，判断是否为整数
                    if (!int.TryParse(strarr[j], out intarr[j]))
                    {
                        Console.WriteLine("输入数据类型有误!"); flag = false;
                        return;
                    }
                }

                for (int j = 0; j < N; j++)//一行一行的创建
                    arr[i, j] = intarr[j];
            }
        }
        
        //判断是否是托普利茨数组
        static bool Istoplitz(int[,] arr, int m, int n)
        {
            for (int i = 0; i+1 < m; i++)
            {
                for (int j = 0; j+1 < n; j++)
                {
                    if (arr[i,j] != arr[i+1,j+1])//将每一个数与它对角线上的下一个数进行比较
                        return false;  //只要有一对数据不相等，就不是托普利茨数组，返回false
                }
            }
            return true;
        }
    }
}
