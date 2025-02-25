using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1._2
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(num1.Text);//输入的第一个操作数
            double b = Convert.ToDouble(num2.Text);//第二个操作数
            string c = comboBox1.Text;//选择的操作符
            double d = 0; //用于记录计算结果

            //根据选择的操作符进行对应计算
            if (c == "+") d = a + b;
            if (c == "-") d = a - b;
            if (c == "*") d = a * b;
            if (c == "/") d = a / b;
            if (c == "%") d = a % b;

            //显示出结果
            result.Text = Convert.ToString(d);
        }
    }
}
