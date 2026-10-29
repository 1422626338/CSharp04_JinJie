using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Hashtable哈希表练习
{
    #region 描述Hashtable的存储规则
    //Hashtable又称散列表，键值对一一对应
    //一个键对应一个值
    #endregion
    #region 制作一个怪物管理器，提供创建怪物，移除怪物的方法。每个怪物都有自己唯一的ID
    class MonsterMgr
    {
        private static MonsterMgr instance = new MonsterMgr();
        public static MonsterMgr Instance
        {
            get
            {
                return instance;
            }
        }
        private MonsterMgr() { }

        public Hashtable monsterTable = new Hashtable();

        private int monsterID = 0;
        public void AddMonster()
        {
            Monster monster = new Monster(monsterID);
            monsterTable.Add(monsterID, monster);
            monsterID++;
            
        }
        public void RemoveMonster(int monsterID)
        {

            if (monsterTable.ContainsKey(monsterID))
            {
                (monsterTable[monsterID] as Monster).Dead();
                monsterTable.Remove(monsterID);
            }
        }
    }
    class Monster
    {
        public int id;
        public Monster(int id)
        {
            this.id = id;
        }
        public void Dead()
        {
            Console.WriteLine("怪物" + id + "死了");
        }
    }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.RemoveMonster(1);
            MonsterMgr.Instance.RemoveMonster(3);
        }
    }
}
