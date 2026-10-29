using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
//总结
//匿名函数,就是没有名字的函数
//固定写法
//delegate(参数列表)
//{
//  //函数逻辑
//};

//主要在委托和事件传递和存储时 ，未来方便可以直接使用匿名函数
//缺点：无法指定移除，无法指定取消订阅
namespace _14.匿名函数
{
    #region 一、什么是匿名函数？
    //匿名函数,就是没有名字的函数
    //主要配合委托和事件进行使用
    //脱离委托和事件，是不会使用匿名函数的
    #endregion

    #region 二、基本语法
    //delegate(参数列表)
    //{
    //  //函数逻辑
    //};

    //何时使用？
    //1.函数中传递委托参数时，
    //2.委托或事件赋值时
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 三、使用
            //1.无参数无返回值 ,声明一个没有名字的函数，直接放进来委托的容器中存起来
            Action action = delegate ()
            {
                Console.WriteLine("匿名函数逻辑");
            };
            //进行调用
            action();

            //2.有参
            Action<int,string> action2 = delegate (int a, string s)
            {
                Console.WriteLine(a);
                Console.WriteLine(s);
            };
            //调用
            action2(100, "123");

            //3.有返回值
            Func<string> func = delegate ()
            {
                return "无参有返回值";
            };
            //调用
            Console.WriteLine( func() );

            //4.一般情况下会作为函数参数传递 或者 作为函数返回值
            Test t = new Test();
            //参数传递
            //调用
            Action ac = delegate ()
            {
                Console.WriteLine("随参数传入的匿名函数逻辑");
            };
            t.DoSomething(200, ac);

            //一步到位
            t.DoSomething(100, delegate ()
            {
                Console.WriteLine("随参数传入的匿名函数逻辑");
            });


            //返回值
            Action ac2 = t.GetFun();
            ac2();

            //一步到位
            t.GetFun()();
            #endregion

            #region 匿名函数缺点
            //添加到委托或事件容器中后，不记录，无法单独移除
            //因为匿名函数没有名字，所以没有办法指定移除某一个匿名函数,只能清空 
            Action ac3 = delegate ()
            {
                Console.WriteLine("匿名函数一");
            };
            ac3 += delegate ()
            {
                Console.WriteLine("匿名函数二");
            };
            ac3();

            //取消订阅没有用
            ac3 -= delegate ()
            {
                Console.WriteLine("匿名函数二");
            };
            ac3();
            #endregion
        }
    }

    class Test
    {
        public Action action;
        //作为参数传递时
        public void DoSomething(int a,Action fun)
        {
            Console.WriteLine(a);
            //调用传递过来的委托执行对应的函数
            fun();
        }

        //作为返回值
        public Action GetFun()
        {
            return delegate () { Console.WriteLine("函数内部返回的一个匿名函数逻辑"); };
        }
    }
}
