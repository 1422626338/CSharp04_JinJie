using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
/*委托变量 = 方法：覆盖赋值，把原来链全部清空，只保留这一个方法
委托变量 += 方法：追加订阅，在现有链末尾加上这个方法
委托变量 -= 方法：从链里移除第一个匹配的方法，一次只删一个*/
namespace _12.委托
{

    //总结
    //委托是用来装载、传递函数的容器，是一种自定义的变量类型
    //可以使用委托变量 来存储和传递函数
    //系统已经提供了自带的委托，
    //Action 无返回值，参数有0~16个委托给我们用
    //Func<> 有返回值，参数有0~16个委托给我们用
    #region 一、委托是什么
    //委托是 函数（方法）的容器
    //可以理解为函数的变量类型
    //用来存储、传递方法
    //委托的本质是一个类，用来定义函数的类型（返回值和参数的类型）
    //不同的函数必须对应和各自格式一直到委托

    #endregion
    #region 二、基本语法
    //关键字：delegate
    //语法：访问修饰符delegate 返回值 委托名 （参数列表）

    //写在哪里
    //可以申明再namespace和class语句块中
    //更多的写在namespace中
    //简单记忆委托语法 就是 函数申明语法前面加一个delegate关键字
    #endregion
    #region 三、自定义委托（默认是public）
    //申明了一个可以用来存储无参无返回值函数的容器
    //这里只定义了规则，并没有使用
    delegate void MyFun();      //装无参无返回值函数
    //同一语句块中委托名不能相同
    //表示用来装载或传递 返回值为int 有一个int参数的函数的委托 容器规则
    delegate int MyFun2(int a); //装int 返回值，int 参数的函数

    delegate T MyFunc3<T, K>(T t, K k); //自定义泛型委托
    //委托装的函数要与委托对应

    #endregion

    #region 四、使用定义好的委托
    //委托变量是函数的容器
    //委托常用在：
    //1.作为类的成员
    //2.作为函数的参数
    #endregion

    #region 五、委托变量可以存储多个函数（多播委托）

    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            //专门用来装载函数的容器
            MyFun f = new MyFun(Fun);
            Console.WriteLine("dasd");
            //1.调用委托执行函数
            f.Invoke();

            //2.    与MyFun f = new MyFun(Fun);一样，不要写()，就是存下来这个函数，暂时不执行
            MyFun f2 = Fun;
            Console.WriteLine("2");
            f2();       //调用委托执行函数


            //01
            MyFun2 f3 = Fun2;
            Console.WriteLine(f3(9));
            //02
            MyFun2 f4 = new MyFun2(Fun2);
            Console.WriteLine(f4?.Invoke(0));


            //使用
            Test t = new Test();
            t.TestFun(Fun, Fun2);


            Console.WriteLine("*******多播*******");
            //多播
            MyFun ff = Fun;
            ff += Fun;
            ff();   //Fun()执行了两次

            Console.WriteLine("******多播2*******");
            MyFun fff = null;
            fff += Fun;
            fff += Fun3;
            fff();

            Console.WriteLine("*****增****");
            Test t2 = new Test();
            t2.AddFun(Fun, Fun2);
            t2.fun();
            t2.fun2(50);

            t2.RemoveFun(Fun, Fun2);
            if(t2.fun == null &&t2.fun2 == null)
            {
                Console.WriteLine("fun和fun2已经移除完了");
            }
            //清空容器,多减不会报错
            t2.fun = null;
            t2.fun2 = null;


            #region 知识点六、系统定义好的委托
            //使用系统自带的委托,需要引用using System；   //Action 实际上是一个无参无返回值的委托
            Console.WriteLine("***使用系统自带的委托Action***");
            Action action = Fun;
            action += Fun3;
            action();

            //Func<T> 可以指定返回值类型的 泛型委托
            Console.WriteLine("***使用系统自带的泛型委托Func***");
            Func<string> funcString = Fun4;
            Func<int> funcInt = Fun5;

            //可以传递N个参数的,系统提供了1~16个参数的委托
            Action<int, string> action2 = Fun6;

            //可以传递N个参数，且有返回值的 ，系统也提供了1~16个
            Func<int, int> func2 = Fun2;    //表示一个int 参数，一个int返回值
            #endregion
        }
        static void Fun()
        {
            Console.WriteLine("执行Fun，123");
        }

        static int Fun2(int a)
        {
            return a;
        }

        static void Fun3()
        {
            Console.WriteLine("执行Fun3");
        }

        static string Fun4()
        {
            return "";
        }
        static int Fun5()
        {
            return 1;
        }
        static void Fun6(int i,string s)
        {
            Console.WriteLine("Action<int,string>的委托参数");
        }
    }

    class Test
    {
        public MyFun fun;
        public MyFun2 fun2;

        public Action action;

        public void TestFun(MyFun fun, MyFun2 fun2)
        {
            //先处理一些别的逻辑 ，当这些逻辑处理完了，在执行传入的函数
            int i = 1;
            i *= 2;
            i += 2;

            //直接调用
            fun();
            fun2(i);

            //先存起来
            this.fun = fun;
            this.fun2 = fun2;
        }

        #region 增
        public void AddFun(MyFun fun1, MyFun2 fun2)
        {
            this.fun = fun1;
            this.fun2 = fun2;
        }
        #endregion

        #region 删
        public void RemoveFun(MyFun fun,MyFun2 fun2)
        {
            this.fun = this.fun - fun;
            this.fun2 -= fun2;
        }
        #endregion
    }
}
