using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _12._2委托练习
{
    #region 一、
    //一家三口，妈妈做饭，爸爸妈妈和孩子都要吃饭
    //用委托模拟 做饭->开饭->吃饭 的过程
    abstract class PerSon
    {
        public abstract void Eat();
    }

    class Mother : PerSon
    {
        public Action beginEat;
        public override void Eat()
        {
            Console.WriteLine("妈妈吃饭");
        }

        public void DoFood()
        {
            Console.WriteLine("妈妈做饭");
            Console.WriteLine("妈妈做好饭了");

            if (beginEat != null)
            {
                beginEat();
            }
        }
    }
    class Son : PerSon
    {
        public override void Eat()
        {
            Console.WriteLine("儿子吃饭");
        }
    }
    class Dad : PerSon
    {
        public override void Eat()
        {
            Console.WriteLine("爸爸吃饭");
        }
    }
    #endregion

    #region 二、
    //怪物死亡后，玩家要加10块钱，界面更新数据，成就要累加怪物击杀数，
    //用委托来实现这些功能
    class Monster
    {
        public Action<Monster> deadDoSomeThing;
        public int money = 10;
        public void Dead()
        {
            //deadDoSomeThing?.Invoke(this);  这个与if等价
            if (deadDoSomeThing != null)
            {
                deadDoSomeThing(this);  //this 代表正在调用 Dead 的那一只怪物实例
            }
            deadDoSomeThing = null;
        }
    }
    class Player
    {
        private int currentMoney = 0;
        public void MonsterDeadPlayerToDo(Monster monster)
        {
            currentMoney += monster.money;
        }
    }
    class Panel
    {
        private int currentPanelMoney = 0;
        public void MonsterDeadPanelToDo(Monster m)
        {
            currentPanelMoney += m.money;
        }
    }
    class CJ
    {
        private int currrentNomber = 0;
        public void MonsterDeadCJToDo(Monster m)
        {
            currrentNomber++;
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 一、
            Console.WriteLine("***一***");
            Mother m = new Mother();
            Dad d = new Dad();
            Son s = new Son();

            //订阅
            m.beginEat += d.Eat;
            m.beginEat += s.Eat;
            m.beginEat += m.Eat;

            //触发
            m.DoFood();
            #endregion


            #region 二、
            Monster monster = new Monster();
            Player player = new Player();
            Panel panel = new Panel();
            CJ cJ = new CJ();

            //订阅
            monster.deadDoSomeThing += player.MonsterDeadPlayerToDo;
            monster.deadDoSomeThing += panel.MonsterDeadPanelToDo;
            monster.deadDoSomeThing += cJ.MonsterDeadCJToDo;
            //触发、执行
            monster.Dead();
            #endregion
        }
    }
}
