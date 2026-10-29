using System;
using System.Collections;

namespace _2.Stack栈
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Stack本质，一个一个进，一个一个出，没法用for访问，
            //栈本质是C#封装好的类
            //也是object[]数组，只是封装了特殊存储规则
            //先进后出
            //foreach遍历，从栈顶到栈底
            //可以先把他转成数组，再用for访问
            //while访问
            #endregion

            #region 申明
            Stack stack = new Stack();
            #endregion
            //增，压栈，只能一个一个入栈
            // 1. 入栈（添加元素）
            stack.Push("第一个入栈");
            stack.Push(666);
            stack.Push(true);

            // 2. 获取栈中元素数量
            Console.WriteLine("栈内元素个数：" + stack.Count);

            // 3. 出栈（取出并删除最后加入的元素）
            Console.WriteLine("出栈元素：" + stack.Pop());
            Console.WriteLine("出栈元素：" + stack.Pop());

            // 4. 查看栈顶元素（不删除）
            Console.WriteLine("栈顶元素：" + stack.Peek());
            //4.2查看元素是否存在于栈中
            if (stack.Contains("123"))
            {
                Console.WriteLine("存在123");
            }
            // 5. 清空栈
            // stack.Clear();

            //6.无法改，只能存和取

            //7.遍历
            Console.WriteLine(stack.Count);

            //7.2foreach遍历,也是从顶部开始遍历
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }

            //7.3将栈转为数组再遍历，还是从顶部到底部
            object[] array = stack.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            //循环弹出栈内元素，直到栈空
            while (stack.Count > 0)
            {
                object o = stack.Pop();
                Console.WriteLine(o);
            }
            Console.WriteLine(stack.Count);

        }
    }
}