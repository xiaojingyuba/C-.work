using Orderclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceclass
{
    //订单服务
    public class OrderService
    {
        private List<Order> Orders { get; set; } = new List<Order>();

        //添加订单
        public void addorder(Order order)
        {
            if (Orders.Contains(order))
                throw new ArgumentException("Add failed, The order already exists!");
            Orders.Add(order);
        }

        //删除订单
        public void deleteorder(int orderId)
        {
            // 定义匹配条件的委托方法
            bool findorder(Order od)
            {
                return od.orderid == orderId;
            }

            // 使用委托方法作为参数
            var order = Orders.FirstOrDefault(findorder);
            if (order == null)
            {
                throw new ArgumentException($"Delete failed, order{orderId} is not found!");
            }
            Orders.Remove(order);
        }

        //修改订单
        public void modifyorder(Order newOrder)
        {
            bool findorder(Order od)
            {
                return od.orderid == newOrder.orderid;
            }
            var oldorder = Orders.FirstOrDefault(findorder);
            if (oldorder == null)
            {
                throw new ArgumentException($"Modify failed, order to modify is not found!");
            }
            oldorder.custmername = newOrder.custmername;
            oldorder.orderdetails = newOrder.orderdetails;
        }

        //根据订单号查询订单
        public List<Order> checkbyorderid(int orderId)
        {
            var check = from order in Orders
                        where order.orderid == orderId
                        orderby order.TotalAmount
                        select order;
            return check.ToList();
        }

        //根据商品名称查询订单
        public List<Order> checkbyproductname(string productName)
        {
            var check = from order in Orders
                        where order.orderdetails.Any(od => od.productname.Contains(productName))
                        orderby order.TotalAmount
                        select order;
            return check.ToList();
        }

        //根据客户名称查询订单
        public List<Order> checkbycustmername(string custmerName)
        {
            var check = from order in Orders
                        where order.custmername.Contains(custmerName)
                        orderby order.TotalAmount
                        select order;
            return check.ToList();
        }

        //根据订单金额范围查询订单
        public List<Order> checkbytotalamount(decimal maxAmount, decimal minaAount)
        {
            var check = from order in Orders
                        where order.TotalAmount >= minaAount && order.TotalAmount <= maxAmount
                        orderby order.TotalAmount
                        select order;
            return check.ToList();
        }

        //按订单号排序
        public void sortbyorderid()
        {
            Orders = Orders.OrderBy(order => order.orderid).ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var orderService = new OrderService();
            var order = new Order();

            orderService.addorder(order);
            orderService.deleteorder(1);
            orderService.modifyorder(order);
            orderService.checkbyorderid(1);
            orderService.checkbyproductname("Apple");
            orderService.checkbycustmername("Alice");
            orderService.checkbytotalamount(10, 50);
            orderService.sortbyorderid();
        }
    }
}
