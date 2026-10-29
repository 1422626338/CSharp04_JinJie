using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

//总结
//1.申明泛型时，她只是一个类型的占位符
//2.泛型真正起作用的时候 是在使用它的时候
//3.泛型占位字母可以有n个，多个泛型占位字母用逗号隔开
//4.泛型占位字母一般是大写字母
//5.不确定泛型类型时，获取默认值 可以使用default(泛型占位字母)来获取默认值
//6.看到<>包裹字母 肯定是泛型

namespace _5.泛型
{
    #region 泛型是什么
    //泛型实现了类型参数化，达到代码重用目的
    //通过类型参数化来实现同一份代码上操作多种类型

    //泛型相当于类型占位符
    //定义类或方法是使用提大夫代表变量类型
    //当真正使用类或者方法时再具体指定类型
    #endregion
    #region 泛型分类
    //泛型类和泛型接口
    //基本语法
    //class 类名<泛型占位字母>
    //interface 接口名<泛型占位字母>

    //泛型函数
    //基本语法:函数名<泛型占位字母>(参数列表)
    //
    //主要：泛型占位字母可以有多个，用逗号分开
    #endregion

    #region 泛型类和接口
    class TestClass<T>
    {
        public T value;
    }

    class TestClass2<T1, T2,K,M>
    {
        public T1 value1;
        public T2 value2;
        public K value3;
        public M value4;
    }

    interface TestInterface<T>
    {
        T Value
        {
            get;
            set;
        }
    }

    class Test : TestInterface<int>
    {
        public int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    #endregion

    #region 四、泛型方法
    //1.普通类中的泛型方法
    public class MyClass
    {
        public void TestFun<T>(T value)
        {
            Console.WriteLine(value);
        }
        public void TestFun<T>()
        {
            T t = default(T);
        }
        public void TestFun<T1, T2>(T1 value1, T2 value2)
        {
            Console.WriteLine(value1);
            Console.WriteLine(value2);
        }
        //不用泛型时：
       public void PrintInt(int value) { }
        void PrintString(string value) { }

        //使用泛型时：
        public void Print<T>(T value) { }
    }

    #endregion

    #region 知识点五、泛型作用
    //1.不同类型对象的相同逻辑处理可以选择泛型
    //2.使用泛型可以一定程度避免拆箱装箱
    //举例：优化ArrayList

    class ArrayList<T>
    {
        private T[] array;

        public void Add(T value)
        {
            
        }   
        public void Remove(T value)
        {

        }
    }   

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型");

            TestClass<int> t = new TestClass<int>();
            t.value = 100;
            Console.WriteLine(t.value);

            TestClass<string> t2 = new TestClass<string>();
            t2.value = "hello";
            Console.WriteLine(t2.value);

            TestClass<bool> t3 = new TestClass<bool>();
            t3.value = true;
            Console.WriteLine(t3.value);

            TestClass2<int, bool, float, TestClass<int>> t4 = new TestClass2<int, bool, float, TestClass<int>>();

            MyClass myClass = new MyClass();    
            myClass.TestFun<int>(100);
            myClass.TestFun<string>("hello");

            myClass.PrintInt(100);
            myClass.Print<int>(100);
        }
    }
}
