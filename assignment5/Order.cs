using OrderDetailclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderclass
{
    //订单类
    public class Order
    {
        public int orderid;//订单编号
        public string custmername { get; set; }//客户名称
        public List<OrderDetails> orderdetails { get; set; } = new List<OrderDetails>();//订单明细
        public decimal TotalAmount => orderdetails.Sum(od => od.totalprice);//订单总额

        //重写Equal方法
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Order other = (Order)obj;
            return orderid == other.orderid;
        }

        //重新ToString方法
        public override string ToString()
        {
            string details = string.Join("\n  ", orderdetails.Select(od => od.ToString()));
            return $"OrderId:{orderid},Custmer:{custmername},Total:{TotalAmount:C}\n Detail:\n{details}";
        }
    }
}
