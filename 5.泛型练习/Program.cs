using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.泛型练习
{
    #region 定义一个泛型方法，方法内判断该类型为何类型，并返回类型的名称与占有的字节数，如果是int，则返回“整形”，4字节

    #endregion
    internal class Program
    {
        static string Func<T>()
        {
            if (typeof(T) == typeof(int))
            {
                return string.Format("{0},{1}字节", "整形", sizeof(int));
            }
            else if (typeof(T) == typeof(char))
            {
                return string.Format("{0},{1}字节", "字符", sizeof(int));
            }
            else if (typeof(T) == typeof(float))
            {
                return string.Format("{0},{1}字节", "浮点", sizeof(float));
            }
            else if (typeof(T) == typeof(string))
            {
                return string.Format("{0},{1}字节","字符串","?");
            }
            else
            return "其他累心";
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Func<int>());
            Console.WriteLine(Func<string>());
        }

    }

}
