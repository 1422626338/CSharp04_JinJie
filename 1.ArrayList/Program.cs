using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ArrayList的知识
{
    #region ArrayList的本质
    //ArrayList是一个C#为我们封装好的类
    //他的本质是一个object类型的数组
    //ArrayList类帮助我们实现了很多方法
    //比如数组的增删查改
    #endregion
    class Test
    {

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            //增
            array.Add(1);
            array.Add("222");
            array.Add(true);
            array.Add(new object());
            array.Add(new Test());

            ArrayList array2 = new ArrayList();
            array2.Add(123);

            array.Insert(0, array2);
            //范围增加（批量增加，把另一个list容器里面的内容加到后面）
            array.AddRange(array2);

            #region 删
            //删除指定元素（从头开始查找第一个匹配的元素并删除）
            array.Remove(1);
            //删除指定索引位置的元素
            array.RemoveAt(0);
            //清空
            array.Clear();
            #endregion

            #region 查
            //1.得到指定位置的元素
            Console.WriteLine(array[0]);

            //2.判断是否包含某个元素
            bool hasHello = array.Contains("Hello ArrayList");
            if (hasHello)
            {
                Console.WriteLine("存在Hello ArrayList");
            }

            //3.正向查找元素的索引位置（从头开始查找第一个匹配的元素并返回索引位置）(找到则返回索引，找不到则返回-1)
            int index = array.IndexOf("222");
            Console.WriteLine(index);
            //4.反向查找元素的索引位置（从尾开始找，但还是从头开始计数索引位置）
            int lastIndex = array.LastIndexOf("222");
            Console.WriteLine(lastIndex);
            #endregion

            #region 改
            array[0] = "Hello ArrayList";
            Console.WriteLine(array[0]);
            #endregion


            #region 二、遍历
            //长度，得到的是当前ArrayList中元素的个数
            Console.WriteLine(array.Count);
            //容量，得到的是ArrayList在不扩容的情况下可以存储的元素个数16X2^n，默认是16
            Console.WriteLine(array.Capacity);
            //遍历
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }
            //迭代器遍历*************************************************************************
            foreach (var item in array)
            {
                
            }
            #endregion

            #region 装箱拆箱
            //ArrayList是一个可以自动扩容的object类型的数组
            //装箱：把值类型转换成引用类型的过程叫装箱
            //拆箱：把引用类型转换成值类型的过程叫拆箱
            //由于用万物之父来存储数据，所以在存储值类型的时候会发生装箱，在取出值类型的时候会发生拆箱
            //当王其中进行值类型存储时就在装箱，将值类型对象取出时就会发生拆箱
            // 装箱：int（值类型）→ object（引用类型）
            int a = 10;
            object obj = a;

            // 拆箱：object → int
            int b = (int)obj;
            #endregion
        }
    }
}
