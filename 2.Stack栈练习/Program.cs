using System;
using System.Collections; // 必须加这一行！Stack 在这里
using System.Text;

namespace _2.Stack栈练习
{
    #region 练习一、简述栈的存储规则
    // 栈：先进后出（FILO / LIFO）
    // 只能从栈顶添加、删除、访问
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            // 测试：计算 10 的二进制
            Calc(10);
            Console.ReadLine();
        }

        #region 练习二、写一个方法计算任意一个数的二进制数，使用栈结构方式存储，之后打印出来
        static void Calc(uint num)
        {
            // 创建栈
            Stack stack = new Stack();

            // 除2取余，直到商为0
            while (num > 0)
            {
                // 取余数 0 或 1
                uint remainder = num % 2;
                // 压入栈
                stack.Push(remainder);
                // 除以2
                num = num / 2;
            }

            // 从栈顶依次弹出，就是正确的二进制顺序
            Console.WriteLine("二进制结果：");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
        #endregion
    }
}