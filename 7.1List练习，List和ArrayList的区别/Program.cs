using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1List练习_List和ArrayList的区别
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 一、List和ArrayList的区别
            // List<T> 和 ArrayList 都是可以动态添加、删除元素的集合，但 List<T> 有泛型类型限制，而 ArrayList 没有泛型类型限制。
            //List:
            List<int> enemyHPList = new List<int>();

            enemyHPList.Add(100);

            int hp = enemyHPList[0];


            ArrayList enemyHPArrayList = new ArrayList();
            enemyHPArrayList.Add(100);
            int hp2 = (int)enemyHPArrayList[0];   //注意这里多了一个 (int)。因为 ArrayList 返回的是 object，编译器不知道它具体存储了什么类型。


            //数组适合固定长度的数据，List 适合动态变化的同类型数据，ArrayList 是较早期的非泛型动态集合。
            #endregion

            #region 二、
            //建立一个整形List，为它添加10~1；
            //删除List中第五个元素
            //遍历剩余元素并打印
            List<int> list1 = new List<int>();
            for(int i = 10; i > 0; i--)
            {
                list1.Add(i);
            }
            list1.RemoveAt(4);
            foreach(int i in list1)
            {
                Console.WriteLine(i);
            }
            #endregion

            #region 三、
            //一个Monster基类，Boss和Gablin类继承它
            //在怪物类的构造函数中，将其存储到一个怪物List中
            //遍历列表可以让Boss和Gablin对象产生不同攻击

            Boss b1 = new Boss();
            Gablin g1 = new Gablin();
            Boss b2 = new Boss();
            Gablin g2 = new Gablin();

            for(int i = 0; i < Monster.monsters.Count; i++)
            {
                Monster.monsters[i].Atk();
            }
            #endregion
        }
    }

    abstract  class Monster
    {
        public static List<Monster> monsters = new List<Monster>();
        //创建构造函数
        public Monster()
        {
            monsters.Add(this);
        }

        public abstract void Atk();
    }
    class Boss : Monster 
    {
        public override void Atk()
        {
            Console.WriteLine("Boss");
        }
    }
    class Gablin:Monster
    {
        public override void Atk()
        {
            Console.WriteLine("Gablin");
        }
    }
    
}
