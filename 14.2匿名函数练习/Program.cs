using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._2匿名函数练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //调用 TestFun，传入 i = 2
            Func<int, int> func = TestFun(2);
            //这里真正调用，3传到了v中，最终返回了2*3=6
            //调用委托，传入 v = 3，匿名函数使用之前记住的 i = 2。
            Console.WriteLine(func(3));
        }

        #region 一、
        //写一个函数，传入一个整数，返回一个函数
        //之后执行这个匿名函数时，传入一个整数和之前那个函数传入的数相乘
        //返回结果
        //
        //正常的函数
        static int TestFun2(int i)
        {
            return 1;
        }
        //返回值是个委托的函数
        static Func<int,int> TestFun(int i)
        {
            //这里i是传进来的2，还没有执行这个函数，只是存起来了，
            //会改变i的生命周期
            return delegate (int v)
            {
                return i * v;
            };
        }
        #endregion
    }
}
