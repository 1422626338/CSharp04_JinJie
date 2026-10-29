using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Dictionary字典
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dictionary的本质
            //可以理解为拥有泛型的Hashtable
            //基于键的哈希代码组织起来的 键/值对
            //键值对类型从Hashtable的object变味了可以自己制定的泛型
            #endregion
            #region 申明
                        Dictionary<int, string> dictionary = new Dictionary<int, string>();
            #endregion
            #region 增删查改
            //增
            //不能有重复的键，值可以重复
            dictionary.Add(1, "张三");
            dictionary.Add(2, "李四");
            dictionary.Add(3, "王五");
            dictionary.Add(4, "张三");

            //删除
            dictionary.Remove(1);
            //清空
            dictionary.Clear();

            dictionary.Add(1, "张三");
            dictionary.Add(2, "李四");
            dictionary.Add(3, "王五");
            dictionary.Add(4, "张三");

            //查找
            //找不到直接报错（HashTable是找不到返回空）
            Console.WriteLine(dictionary[1]);
            //Console.WriteLine(dictionary[5]);

            if (dictionary.ContainsKey(5))
            {
                Console.WriteLine(dictionary[5]);
            }
            if (dictionary.ContainsValue("张三"))
            {
                Console.WriteLine(dictionary[3]);
            }

            //改
            dictionary[1] = "张1";
            Console.WriteLine(dictionary[1]);
            #endregion

            #region 遍历
            Console.WriteLine("********");
            Console.WriteLine(dictionary.Count);
            //1.遍历所有键
            foreach (int item in dictionary.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine(dictionary[item]);
            }
            //2.遍历所有值
            foreach (string str in dictionary.Values)
            {
                Console.WriteLine(str);
            }
            //3.键值对一起遍历
            foreach(KeyValuePair<int,string> item in dictionary)
            {
                Console.WriteLine("键："+item.Key + "值:"+ item.Value);
            }
            #endregion
        }
    }
}
