using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.泛型约束练习
{
    //1.用泛型实现一个单例模式基类
    //泛型约束单例
    class SingleBase<T> where T : new()   //无参构造函数
    {
        private static T instance = new T();
        public static T Instance
        {
            get
            {
                return instance;
            }
        }

    }

    class GameMgr : SingleBase<GameMgr>
    {
        public int value = 10;
    }

    //单例
    class Test
    {
        private static Test instance = new Test();
        private Test() { }
        public static Test Instance
        {
            get
            {
                return instance;
            }
        }
        public int value = 20;
    }

    //2.利用非泛型知识，仿造ArrarList实现一个不确定数组类型的类，实现增删改查方法

    class ArrayList<T>
    {
        private T[] array;

        //当前真正存了多少个元素
        private int count;
        
        public ArrayList()
        {
            count = 0;
            //一开始的容量就是16
            array = new T[16];
        }

        public void Add(T value)
        {
            //是否需要扩容
            if(count >= Capacity)
            {
                //搬家 每次家扩容2倍
                T[] temp = new T[Capacity * 2];
                for(int i = 0; i < Capacity; i++)
                {
                    temp[i] = array[i];
                }

                //重新指向地址
                array = temp;
            }
            //不需要扩容
            array[Count] = value;
            ++count;
        }
        public void Remove(T value)
        {
            int index = -1;
            for(int i = 0; i < Count; i++)
            {
                if (array[i].Equals(value))
                {
                    index = 1;
                    break;
                }
            }

            if(index != -1)
            {
                for(;index <Count - 1; index++)
                {
                    array[index] = array[index + 1];
                }
                array[Count - 1] = default(T);

                --count;
            }
        }
        public void RemoveAt(int index)
        {
            //索引合法吗？
            if(index <0 || index >= Count)
            {
                Console.WriteLine("索引不合法");
                return;
            }
            for(;index <Count - 1; index++)
            {
                array[index] = array[index + 1];
            }
            array[Count - 1] = default(T);
            --count;
        }
        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
        
        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Test.Instance.value = 30;
            Console.WriteLine(Test.Instance.value);

            GameMgr.Instance.value = 10;
            Console.WriteLine(GameMgr.Instance.value);
        }
    }
}
