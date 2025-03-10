using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
namespace assignment
{
    interface IShape
    {
        double GetArea();//计算面积
        bool IsLegal();//判断形状是否合法
    }

    class Rectangle : IShape//长方形
    {
        public double Length, Width;//长和宽
        public Rectangle(double len, double wid)
        {
            this.Length = len;
            this.Width = wid;
        }
        public double GetArea()
        {
            return this.Length * this.Width;//面积=长*宽
        }
        public bool IsLegal()
        {
            if (this.Length <= 0 || this.Width <= 0)//边长>0
                return false;
            return true;
        }
    }

    class Square : IShape//正方形
    {
        public double Sidelength;//边长
        public Square(double sidelen)
        {
            this.Sidelength = sidelen;
        }
        public double GetArea()
        {
            return this.Sidelength * this.Sidelength;//面积=边长*边长
        }
        public bool IsLegal()
        {
            if (this.Sidelength <= 0)//边长>0
                return false;
            return true;
        }
    }

    class Triangle : IShape//三角形
    {
        public double Baselen, Height;//底边和高
        public Triangle(double baselen, double height)
        { 
            this.Baselen = baselen;
            this.Height = height;
        }
        public double GetArea()
        {
            return 0.5 * this.Baselen * this.Height; ;//面积=1/2*底边*高
        }
        public bool IsLegal()
        {
            if (this.Baselen <= 0 || this.Height <= 0)//边长>0
                return false;
            return true;
        }
    };

    //创建图形
    class Createshape
    {
        //根据输入创建单个形状
        public static double SingleShape(string name, params double[] sides)
        {
            //合法则返回面积
            if (name == "Rectangle")
            {
                Rectangle Rect = new Rectangle(sides[0], sides[1]);
                if (Rect.IsLegal())
                    return Rect.GetArea();
            }
            else if (name == "Square")
            {
                Square Squ = new Square(sides[0]);
                if (Squ.IsLegal())
                    return Squ.GetArea();
            }
            else if (name == "Triangle")
            {
                Triangle Tri = new Triangle(sides[0], sides[1]);
                if (Tri.IsLegal())
                    return Tri.GetArea();
            }
            return -1;//不合法返回-1
        }
        //随机创建单个形状
        public static double RandomShape()
        {
            Random rand = new Random();

            int shape;
            shape = rand.Next(0, 2);//记录是什么形状
            if (shape == 0)
            {
                Rectangle Rect = new Rectangle(rand.Next(1, 100), rand.Next(1, 100));
                if (Rect.IsLegal())
                    return Rect.GetArea();
            }
            else if (shape == 1)
            {
                Square Squ = new Square(rand.Next(1, 100));
                if (Squ.IsLegal())
                    return Squ.GetArea();
            }
            else if (shape == 2)
            {
                Triangle Tri = new Triangle(rand.Next(1, 100), rand.Next(1, 100));
                if (Tri.IsLegal())
                    return Tri.GetArea();
            }
            return -1;
        }
    }

    class CMain
    {
        public static void Main()
        {
            double res;//临时记录单个形状的面积
            double sum = 0;//记录面积总和
            for (int i = 0; i < 10; i++)//创建10个对象
            {
                res = Createshape.RandomShape();//随即创建
                if(res==-1)
                {
                    Console.WriteLine("创建的形状不合法！");
                        return;
                }
                Console.WriteLine("第{0}个形状的面积为：{1}" , i+1 , res);
                sum += res;//面积累加
            }
            Console.WriteLine("这10个形状的面积总和为： " + sum);

            //创建一个正方形
            double res2 = Createshape.SingleShape("Square", [12]);
            if (res2 == -1)
                Console.WriteLine("创建的Square形状不合法！");
            else
                Console.WriteLine("创建的Square形状的面积为：" + res2);

            //创建一个三角形（不合法）
            double res3 = Createshape.SingleShape("Triangle", [7.5, -3]);
            if (res3 == -1)
                Console.WriteLine("创建的Triangle形状不合法！");
            else
                Console.WriteLine("创建的Triangle形状的面积为：" + res3);
        }
    }
}
