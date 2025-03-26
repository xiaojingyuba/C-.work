using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orderclass;
using OrderDetailclass;
using OrderServiceclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceclass.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        private OrderService orderService;
        private Order testOrder1;
        private Order testOrder2;
        private Order testOrder3;

        [TestInitialize]
        public void Setup()
        {
            orderService = new OrderService();

            // 初始化测试订单
            testOrder1 = new Order
            {
                orderid = 1,
                custmername = "Alice",
                orderdetails = new List<OrderDetails>
                {
                new OrderDetails { productname = "Apple", quantity = 2, singleprice = 5 },
                new OrderDetails { productname = "Banana", quantity = 3, singleprice = 2 }
                }
            };

            testOrder2 = new Order
            {
                orderid = 2,
                custmername = "Bob",
                orderdetails = new List<OrderDetails>
                {
                new OrderDetails { productname = "Orange", quantity = 4, singleprice = 3 },
                new OrderDetails { productname = "Apple",quantity = 1, singleprice = 5 }
                }
            };

            testOrder3 = new Order
            {
                orderid = 3,
                custmername = "Charlie",
                orderdetails = new List<OrderDetails>
                {
                new OrderDetails { productname = "Grape", quantity = 5, singleprice = 4 }
                }
            };

            // 添加测试订单
            orderService.addorder(testOrder1);
            orderService.addorder(testOrder2);
        }
        [TestMethod()]
        public void addorderTest()
        {
            // 添加新订单
            orderService.addorder(testOrder3);

            // 验证订单内容
            var addedOrder = orderService.checkbyorderid(3).First();
            Assert.AreEqual("Charlie", addedOrder.custmername);

            // 尝试添加重复订单ID
            orderService.addorder(new Order { orderid = 1 });
        }

        [TestMethod()]
        public void deleteorderTest()
        {
            // 删除订单
            orderService.deleteorder(1);

            // 验证订单确实被删除
            Assert.AreEqual(0, orderService.checkbyorderid(1).Count);
        }

        [TestMethod()]
        public void modifyorderTest()
        {
            // 创建修改后的订单
            var modifyorder = new Order
            {
                orderid = 1,
                custmername = "Alice Updated",
                orderdetails = new List<OrderDetails>
        {
            new OrderDetails { productname = "Apple", quantity = 5, singleprice = 5 }
        }
            };

            // 修改订单
            orderService.modifyorder(modifyorder);

            // 验证修改结果
            var result = orderService.checkbyorderid(1).First();
            Assert.AreEqual("Alice Updated", result.custmername);
            Assert.AreEqual(1, result.orderdetails.Count);
            Assert.AreEqual(25, result.TotalAmount);
        }

        [TestMethod()]
        //根据订单号查询
        public void checkbyorderidTest()
        {
            // 查询存在的订单
            var result = orderService.checkbyorderid(1);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Alice", result[0].custmername);

            // 查询不存在的订单
            result = orderService.checkbyorderid(999);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        //根据商品名称查询
        public void checkbyproductnameTest()
        {
            // 查询存在的订单
            var result = orderService.checkbyproductname("Orange");
            Assert.AreEqual(4, result.Count);

            // 查询不存在的订单
            result = orderService.checkbyproductname("Pear");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        ////根据客户名称查询
        public void checkbycustmernameTest()
        {
            // 查询存在的订单
            var result = orderService.checkbyproductname("Bob");
            Assert.AreEqual(2, result[0].orderid);

            // 模糊查询
            result = orderService.checkbyproductname("Bo");
            Assert.AreEqual(2, result[0].orderid);
        }

        [TestMethod()]
        //根据订单总额查询
        public void checkbytotalamountTest()
        {
            // 查询金额在10-20之间的订单
            var result = orderService.checkbytotalamount(10, 20);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod()]
        //按订单号排序
        public void sortbyorderidTest()
        {
            // 添加第三个订单
            orderService.addorder(testOrder3);

            // 默认按订单号升序排序
            orderService.sortbyorderid();
            var result = orderService.checkbyorderid(1);
            Assert.AreEqual(1, result.Count);
        }
    }
}