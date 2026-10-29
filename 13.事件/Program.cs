using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
/*委托变量 = 方法：覆盖赋值，把原来链全部清空，只保留这一个方法
委托变量 += 方法：追加订阅，在现有链末尾加上这个方法
委托变量 -= 方法：从链里移除第一个匹配的方法，一次只删一个*/

//总结
//事件和委托的区别
//事件和委托的使用几乎就是一模一样的
//事件就是特殊的委托
//主要区别是：
//1.事件不能在外部使用赋值=符号，只能+= ，-= 订阅和取消订阅
//2.事件不能在外部执行，委托在哪里都可以执行
//3.事件不能作为函数重点临时变量，委托可以
namespace _13.事件
{
    #region 一、事件是什么
    //事件是基于委托的存在
    //事件是委托的安全包裹
    //让委托的使用更具有安全性
    //事件 是一种特殊的变量类型
    #endregion

    #region 三、为什么有事件
    //1.防止外部随意置空委托
    //2.防止外部随意调用委托
    //3.事件相当于对委托进行了一次封装 ，让其更加安全
    #endregion

    #region 二、事件的使用
    //申明语法
    //访问修饰符 event 委托类型 事件名;
    //事件的使用：
    //1.事件是作为 成员变量 存在于类中
    //2.委托怎么用，事件就怎么用
    //事件与委托的区别
    //1.不能在类外部赋值
    //2.不能在类外部调用
    //3.所有，事件只能在外面+=和-=订阅和取消订阅
    //注意：
    //只能作为 成员 存在于 类、接口、结构体中

    public class Test
    {
        //委托成员变量 用于存储 函数的
        public Action myFun;
        //事件成员你变量 也是用于存储 函数的
        public event Action myEvent;
        //构造函数,用于初始化，创建对象时调用
        public Test() 
        {

            //直接赋值一个函数
            myFun = TestFun;
            myEvent =  TestFun;
            //多播
            myFun += TestFun;   //委托链变成 [TestFun, TestFun]
            myEvent += TestFun;
            //执行
            myFun();
            myEvent();
            //取消
            myFun -= TestFun;   //移除一个匹配的TestFun，链变成 [TestFun]
            myEvent -= TestFun;

            //分别还剩一个方法
            myFun?.Invoke();
            myEvent?.Invoke();
        }
        public void TestFun()
        {
            Console.WriteLine("123");
        }

        //只能外部调用这个封装的方法，来间接调用事件
        public void DoEvent()
        {
            myEvent?.Invoke();
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();

            //区别，委托可以在类外部赋值和调用
            test.myFun = test.TestFun;
            test.myFun();
            test.myFun?.Invoke();
            test.myFun = null;

            //事件是不能在外部赋值和调用的
            //test.myEvent = null;
            //test.myEvent?.Invoke();
            //只能外部调用这个封装的方法，来间接调用事件
            test.DoEvent();
            //但是可以在外部+= 和-= 订阅和取消订阅
            test.myEvent += test.TestFun;
            test.myEvent -= test.TestFun;
            //不能用赋值符号“=”
            //test.myEvent = test.myEvent + test.TestFun;

            Action a = test.TestFun;
            //事件是不能作为临时变量在函数中使用的
            //event Action ae = test.TestFun;
    }

    }
}
