using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Queue队列
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1.Queue本质
            //Queue也是C#封装好的类,本质也是一个object[]数组，只是封装了特殊的存储规则
            //队列，先进先出
            #endregion
            // 1. 声明队列
            Queue queue = new Queue();

            // 2. 入队（添加元素，只能加到队尾）
            queue.Enqueue("第一个人排队");
            queue.Enqueue("第二个人排队");
            queue.Enqueue("第三个人排队");

            // 3. 获取队列元素数量
            Console.WriteLine("队列当前人数：" + queue.Count); // 输出：3

            // 4. 出队（取出队首元素，并从队列中移除）
            Console.WriteLine("第一个人买到了：" + queue.Dequeue()); // 输出：第一个人排队

            // 5. 查看队首元素（不移除）
            Console.WriteLine("现在队首的人是：" + queue.Peek()); // 输出：第二个人排队

            // 6. 遍历队列（从队首到队尾）
            Console.WriteLine("\n当前队列所有人：");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            // 7. 清空队列
            queue.Clear();
            Console.WriteLine("\n清空后队列人数：" + queue.Count); // 输出：0
            //8.查看元素是否存在于队列中
            if (queue.Contains("5"))
            {
                Console.WriteLine("");
            }

            //9.遍历
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }
            object[] array = queue.ToArray();
            for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
                while (queue.Count > 0)
                {
                    object o = queue.Dequeue();
                    Console.WriteLine(o);
            }
        }
    }
}
