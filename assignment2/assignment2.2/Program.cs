using System;
using System.ComponentModel.DataAnnotations;

namespace assignment2
{
    class ArrOpr
    {
        static void Main()
        {
            Console.WriteLine("请输入整数数组的数据，以空格分隔：");
            string input = Console.ReadLine();
            // 将输入字符串按空格分割成字符数组
            string[] strarr = input.Split(new[] { ' ' });
            //若标志位为假即输入有误，就不调用相关计算函数
            bool flag = true;

            int length = strarr.Length;
            int[] intarr = new int[length];
            for (int i = 0;i<length;i++)
            {
                //将每个字符转为整型，判断是否为整数
                if (!int.TryParse(strarr[i], out intarr[i]))
                {
                    Console.WriteLine("输入的{0}不是整数", strarr[i]);
                    flag = false;
                }
            }
            if (flag == true)
            {
                //计算最大值
                int max = GetMaxNum(intarr);
                Console.WriteLine("该整数数组的最大值为：" + max);
                //计算最小值
                int min = GetMinNum(intarr);
                Console.WriteLine("最小值为：" + min);
                //计算平均值
                double average = GetArg(intarr);
                Console.WriteLine("平均值为：" + average);
                //计算平均值
                int sum = GetSum(intarr);
                Console.WriteLine("所以数组元素的和为：" + sum);
            }
        }

        //计算最大值
        static int GetMaxNum(int[] arr)
        {
            int max = arr[0];
            for(int i = 0;i<arr.Length;i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        //计算最小值
        static int GetMinNum(int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        //计算平均值
        static double GetArg(int[] arr)
        {
            int length = arr.Length;
            int sum = 0;
            for (int i = 0; i < length; i++)
                sum+= arr[i];
            double average = (double)sum / length;
            return average;
        }

        //计算数据总和
        static int GetSum(int[] arr)
        {
            int length = arr.Length;
            int sum = 0;
            for (int i = 0; i < length; i++)
                sum += arr[i];
            return sum; 
        }
    }
}