using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.List的本质
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region List的本质
            //List时C#封装好的类，本质是一个可变类型的泛型数组
            //泛型数组的增删查改
            #endregion

            #region 知识点二、申明
            //命名空间 using System.Collection.Generic
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            #endregion

            #region 知识点三、增删查改
            list.Add("--sd");
            list2.Add(2);


            List<string> list3 = new List<string>();
            list3.Add("dadasda");
            list3.AddRange(list);
            Console.WriteLine(list3.Count);

            list.Insert(0, "999");
            Console.WriteLine(list[0]);

            //删除
            //1.移除指定元素
            list.Remove("-");   //遍历，查找到则移除，后面的往前

            //2.移除指定位置的元素 移除第一个元素
            list.RemoveAt(0);

            //3.清空
            list.Clear();

            #region 查找
            //1.得到指定位置的元素
            Console.WriteLine(list3[0]);

            //2.查看元素是否存在
            if (list3.Contains("a"))
            {
                Console.WriteLine("list3 有a");
            }

            //3.正向查找元素位置
            //找到返回位置，找不到，返回-1
            int index = list3.IndexOf("a");
            Console.WriteLine(index);

            //4.反向查找元素的位置
            //找到返回位置，找不到，返回-1
            index = list3.LastIndexOf("--sd");
            Console.WriteLine(index);
            #endregion

            #region 改
            Console.WriteLine(list3[0]);
            list3[0] = "bbbb";
            Console.WriteLine(list3[0]);
            #endregion
            #endregion

            #region 四、遍历
            list.Add("01");
            //长度
            Console.WriteLine(list.Count);
            //容量
            //避免产生垃圾
            Console.WriteLine("*****");
            Console.WriteLine(list.Capacity);
            Console.WriteLine("*****");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            foreach(string str in list)
            {
                Console.WriteLine(str);
            }
            #endregion
        }
    }
}
