using System;
// 小张类
public class MrZhang
{
    // 其实买车票的悲情人物是小张
    public static void BuyTicket()
    {
        Console.WriteLine("NND,每次都让我去买票，鸡人呀！");
    }

    public static void BuyMovieTicket()
    {
        Console.WriteLine("我去，自己泡妞，还要让我带电影票！");
    }
}

//小明类
class MrMing
{
    // 声明一个委托，其实就是个“命令”
    public delegate void BugTicketEventHandler();
    public static void response()
    {
        Console.WriteLine("are u ok ");
        //return 1;
    }

    public static void Main(string[] args)
    {
        // 这里就是具体阐述这个命令是干什么的，本例是MrZhang.BuyTicket“小张买车票”
        BugTicketEventHandler myDelegate = new BugTicketEventHandler(MrZhang.BuyTicket);

        //用事件连接 ，一个被触发后另一个也随之运行
        myDelegate += MrMing.response;
        //myDelegate += MrZhang.BuyTicket;
        // 这时候委托被附上了具体的方法
        myDelegate();
        Console.ReadKey();
    }
}