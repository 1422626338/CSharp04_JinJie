using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._2事件练习
{
    #region 一、
    //有一个热水器，包含一个加热器，一个报警器，一个显示器
    //给热水器通上电，当水温超过95度时
    //1.报警器会开始发出声音，告诉你水的温度
    //2.显示器也会改变水温提示，提示你水已经烧开了

    public class Heater
    {
        public event Action<int> myEvent;
        private int value = 0;
        public void AddHot()
        {
            int updateIndex = 0;
            while (true)
            {
                if(updateIndex % 999999 == 0)
                {
                    Console.WriteLine("当前温度{0}度", value);
                    ++value;
                    if (value > 100)
                        break;
                    if(value>=95)
                    {
                        if (myEvent != null)
                        {
                            myEvent(value);
                        }
                        myEvent = null;
                    }              
                    updateIndex = 0;
                }
                ++updateIndex;
            }
        }

    }
    public class Alarm
    {
        public void ShowInFo(int v)
        {
            Console.WriteLine("加热到水温{0}°",v);
        }
    }
    public class Display
    {
        public void ShowInFo(int v)
        {
            Console.WriteLine("水已经烧开，当前水温{0}°", v);
        }
    }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Heater h = new Heater();
            Alarm a = new Alarm();
            Display d = new Display();
            //订阅
            h.myEvent += a.ShowInFo;
            h.myEvent += d.ShowInFo;
            //执行
            h.AddHot();

        }
    }
}
