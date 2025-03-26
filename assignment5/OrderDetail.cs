using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDetailclass
{
    //订单明细类
    public class OrderDetails
    {
        public string productname { get; set; }//商品名称
        public decimal singleprice { get; set; }//商品单价
        public int quantity { get; set; }//商品数量
        public decimal totalprice//单种商品总额
        {
            get { return singleprice * quantity; }
        }

        //重写Equal方法
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            OrderDetails other = (OrderDetails)obj;
            //商品名称及数量，单价都相同才返回true
            return productname == other.productname
                   && quantity == other.quantity
                   && singleprice == other.singleprice;
        }

        //重新ToString方法
        public override string ToString()
        {
            return $"Product: {productname}, Quantity: {quantity}, SinglePrice: {singleprice:C}, TotalPrice: {totalprice:C}";
        }
    }
}
