using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Hashtable哈希表
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 本质
            //Hashtable又称散列表，键值对一一对应
            //提高查询效率，使用键来访问值
            #endregion
            // 1. 创建哈希表
            Hashtable ht = new Hashtable();

            // 2. 添加键值对
            ht.Add(1, "张三");
            ht.Add(2, "李四");
            ht.Add(3, "王五");
            ht.Add("0101", "老六");

            //删除
            ht.Remove("0101");//删除不存在的键没反应//通过键删除
            // 3. 根据 Key 取值
            string name = (string)ht[2];
            Console.WriteLine("Key=2 对应：" + name); // Key=2 对应：李四
            Console.WriteLine(ht["0101"]); //老六

            Console.WriteLine(ht[2]); //李四

            //4.查找是否存在
            if(ht.ContainsKey(3))
            {
                Console.WriteLine("存在键3");
            }
            if (ht.ContainsKey(3))
            {
                Console.WriteLine("存在键3");
            }
            if (ht.ContainsValue("王五"))
            {
            }

            //改
            ht[2] = "李四改了";//通过键修改值

            // 4. 遍历
            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine(item.Key + "：" + item.Value);
            }
            //1.遍历所有键
            foreach (object key in ht.Keys)
            {
                Console.WriteLine("键：" + key);
                Console.WriteLine("值:" + ht[key]);
            }
            //2.遍历所有值
            foreach (object value in ht.Values)
            {
                Console.WriteLine("值：" + value);

            }
            //3.遍历所有键值对
            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine("键：" + item.Key + "，值：" + item.Value);
            }
            //4.使用 GetEnumerator 方法获取枚举器进行遍历(迭代器遍历法)
            IDictionaryEnumerator enumerator = ht.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("键：" + enumerator.Key + "，值：" + enumerator.Value);
            }
        }
    }
}
