using System;
namespace assignment4
{
    public class Node<T>//定义结点类型
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)//构造函数
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>//泛型链表类
    {
        public Node<T> head;
        public Node<T> tail;

        //构造函数，头结点尾结点都指向空
        public GenericList()
        {
            head = tail = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        //向链表中加入元素
        public void Add(T t)
        {
            //以新加的元素新建结点
            Node<T> n = new Node<T>(t);

            //如果链表为空，头结点尾结点都指向新结点
            if (tail == null)
            {
                head = tail = n;
            }
            //不为空，则尾结点指向新结点，并更新尾结点
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        //传入一个委托作为参数
        public void Foreach(Action<T> action)
        {
            Node<T> p = head;

            //对链表中的每个元素进行操作
            while (p != null)
            {
                action(p.Data);
                p = p.Next;
            }
        }       
    }

    class Listforeach
    {
        static void Main(string[] args)
        {
            //新建链表并加入元素
            GenericList<int> intlist = new GenericList<int>();
            intlist.Add(10);
            intlist.Add(7);
            intlist.Add(15);
            intlist.Add(23);
            intlist.Add(2);

            //输出每个元素
            Console.WriteLine("该列表的元素有：");
            intlist.Foreach(x => Console.WriteLine(x));

            //求出最大值
            int max = intlist.head.Data;
            intlist.Foreach(x => { if (x > max) max = x; });
            Console.WriteLine("最大值为："+max);

            //求出最小值
            int min = intlist.head.Data;
            intlist.Foreach(x => { if (x < min) min = x; });
            Console.WriteLine("最小值为："+min);

            //求出元素总和
            int sum = 0;
            intlist.Foreach(x => sum += x);
            Console.WriteLine("总和为："+sum);
        }
    }
}
    
   