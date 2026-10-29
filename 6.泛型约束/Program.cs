using _6.泛型约束;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.泛型约束
{
    #region 知识点一、什么是泛型约束
    //让泛型的类型有一定的限制
    //关键字：where
    //泛型约束一共有6种
    //1.值类型约束         where T:struct
    //2.引用类型约束       where T:class
    //3.无参构造函数约束   where T:new()
    //4.某个类本身或派生类约束 where T:类名
    //5.某个接口的派生类约束 where T:接口名
    //6.另一个泛型类型本身或派生类约束 where T:U

    //where 泛型字母 ： （约束的类型）
    #endregion

    #region 二、各泛型约束讲解
    #region 值类型约束
    class Test1<T> where T : struct
    {
        //只能是值类型，不能是引用类型
        public T value;
        public void TestFun<K>(K v) where K : struct
        {
            //只能是值类型，不能是引用类型

        }
    }
    #endregion

    //2.引用类型约束
    class Test2<T> where T : class
    {
        public T value;
        public void TestFun<K>(K k) where K : class
        {

        }
    }




    #endregion

}




internal class Program
{
    static void Main(string[] args)
    {
        Test1<int> test1 = new Test1<int>();
        test1.TestFun<int>(100);
        test1.TestFun<double>(100.0);
        test1.TestFun<DateTime>(DateTime.Now);

        Test2<string> test3 = new Test2<string>();
        test3.value = "你好";
        Console.WriteLine(test3.value);

        Test2<Object> test2 = new Test2<Object>();
        test2.TestFun<string>("Hello!");
        test2.TestFun<object>(new object());
    }
}

