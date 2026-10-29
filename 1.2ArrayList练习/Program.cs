using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _1._2ArrayList练习
{
    #region 一、简述ArrayList和数组的区别
    //ArrayList实际上是一个object数组的封装

    //1.ArrayList可以不用一开始就确定长度，单独使用数组是定长的
    //2.数组可以指定存储类型，ArrayList默认为object类型（可以存任意的类型）
    //3.数组的增删需要自己去实现，ArrayList已经帮我们实现了增删方法
    //4.ArrayList使用时可能有装箱拆箱问题，数组使用时只要不是object数组就不存在这个问题
    //5.数组长度为Length，ArrayList长度为Count
    #endregion

    #region 二、创建一个背包管理类，使用ArrayList存储物品，实现购买物品，卖出物品，显示物品的功能。购买与卖出物品会导致金钱变化
    class BagMng
    {
        //背包中的物品
        private ArrayList items;//声明一个背包，类型是ArrayList
        private int money;

        //写个构造函数，初始化背包(初始化背包钱)
        public BagMng(int money)
        {
            this.money = money;
            //创建一个空背包，让背包可以开始装东西。
            items = new ArrayList();
        }
        public int ShowMoney()
        {
            return this.money;
        }
        public void BuyItem(Item item)
        {
            //判断传入的物品是否合法（数量不能为负，价格不能为负）
            if (item.num < 0 || item.price < 0)
            {
                Console.WriteLine("物品数量或价格不能为负");
                return;
            }

            //先判断钱够不够买这个物品
            if (this.money < item.price * item.num)
            {
                Console.WriteLine("钱不够，买不了");
                return;
            }

            //钱够
            this.money -= item.price * item.num;
            Console.WriteLine("购买{0}{1}个花费{2}钱", item.name, item.num, item.price * item.num);
            Console.WriteLine("还剩{0}钱", this.money);
            //如果可以叠加
            for (int i = 0; i < items.Count; i++)
            {
                //如果背包里有这个物品了（原来的ID==传进来的ID）
                if ((items[i] as Item).id == item.id)   //背包里存的是 object 类型，转成 Item 类型才能访问 id 属性
                {
                    //叠加数量（当前的数量加上传进来的数量）
                    (items[i] as Item).num += item.num;
                    return;
                }
            }

            //把一组物品加到list中
            items.Add(item);
        }
        public void SellItem(Item item)
        {
            if (item == null || item.num <= 0)
            {
                Console.WriteLine("物品不合法！");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Item bagItem = items[i] as Item;

                // 找到对应ID的物品（如果背包object物品的id与传进来的id一样）
                if (bagItem.id == item.id)
                {
                    int sellNum;

                    // 要卖的数量 >= 背包数量 → 全卖
                    if (item.num >= bagItem.num)
                    {
                        sellNum = bagItem.num;
                        items.RemoveAt(i);  // 卖光就移除
                    }
                    else
                    {
                        sellNum = item.num;
                        bagItem.num -= sellNum; // 卖多少减多少 ✔
                    }

                    // 计算钱
                    int earn = (int)(sellNum * bagItem.price * 0.8);
                    this.money += earn;

                    Console.WriteLine("卖出{0} {1}个，获得{2}钱", bagItem.name, sellNum, earn);
                    Console.WriteLine("当前金钱：{0}", this.money);

                    return; // 找到就退出，避免重复执行 ✔️
                }
            }

            Console.WriteLine("背包里没有该物品！");
        }
        public void SellItem(string itemName)
        {
        }
        public void SellItem(int itemId, int num = 1)
        {
            // 遍历背包找到ID对应的物品
            foreach (Item bagItem in items)
            {
                if (bagItem.id == itemId)
                {
                    // 构造一个临时物品（带正确价格和名字）
                    Item tempItem = new Item(bagItem.id, bagItem.name, num, bagItem.price);
                    SellItem(tempItem);
                    return;
                }
            }
            Console.WriteLine("找不到该ID物品");
        }

        public void ShowItem()
        {
            Console.WriteLine("\n===== 背包 =====");
            foreach (Item item in items)
            {
                Console.WriteLine("{0} ×{1} 单价：{2}", item.name, item.num, item.price);
            }
            Console.WriteLine("当前金钱：{0}\n", this.money);
        }
    }
    class Item
    {
        //物品唯一ID 来区分物品的种类
        public int id;
        //物品名字
        public string name;
        //物品数量
        public int num;
        //物品价格
        public int price;

        //写个构造函数
        /// <summary>
        /// Item类的构造函数，传入物品的ID，名字，数量和价格来创建一个物品对象
        /// </summary>
        /// <param name="id">物品唯一ID</param>
        /// <param name="name">物品名字</param>
        /// <param name="num">物品数量</param>
        /// <param name="price">物品价格</param>
        public Item(int id, string name, int num, int price)
        {
            this.id = id;
            this.name = name;
            this.num = num;
            this.price = price;
        }
         public Item(int id,int num)
        {
            this.id = id;
            this.num = num;
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            BagMng bag = new BagMng(1000);
            Console.WriteLine("初始有{0}钱了", bag.ShowMoney());
            Item item1 = new Item(1, "红药水", 3, 10);
            Item item2 = new Item(2, "蓝药水", 5, 20);
            Item item3 = new Item(3, "长剑", 1, 150);

            bag.BuyItem(item1);
            bag.BuyItem(item2);
            bag.BuyItem(item3);
            bag.ShowItem();

            bag.SellItem(item3);
            bag.SellItem(1, 1);
            bag.SellItem(1, 1);
            bag.SellItem(1, 2);
            bag.SellItem(1, 2);
            bag.SellItem(2, 3);
        }
    }
}
