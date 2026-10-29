using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Queue队列练习
{

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 使用队列存储消息，一次性存10条消息，每隔一段时间打印一条消息，控制台打印消息时要有明显停顿感
            Queue queue = new Queue();
            queue.Enqueue("01");
            queue.Enqueue("02");
            queue.Enqueue("03");
            queue.Enqueue("04");
            queue.Enqueue("05");
            int updateIndex = 1;

            while (true)
            {
                if (updateIndex % 99999999 == 0)
                {
                    if (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    updateIndex = 0;
                }

                ++updateIndex;
            }
            
            #endregion
        }
    }
}
