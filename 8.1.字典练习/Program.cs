using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._1.字典练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 一、
            //使用子弟啊存储0~9的数字对应的大写文字
            //提示用户输入一个不超过三位的数，提供一个方法，返回数的大写

            #endregion
        }

        static string GetInfo(int num)
        {
            Dictionary<int,string> dic = new Dictionary<int, string>();
            dic.Add(0, "零");
            dic.Add(1, "壹");

            string str = "";
            //得百位
            int b = num / 100;
            str += dic[b];
            //得十位
            int s = num % 100 /10;
            str += dic[s];
            //得个位
            int g = num % 10;
            str += dic[g];
            return str;
        }
    }
}
