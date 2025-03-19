using System;
using System.Threading;

public class AlarmClock
{
    //定义Tick事件
    public event EventHandler Tick;
    //定义Alarm事件
    public event EventHandler Alarm;

    //闹钟的定时时间
    private int alarmtime;

    //设置闹钟时间
    public AlarmClock(int time)
    {
        alarmtime = time;
    }

    //启动闹钟
    public void Start()
    {
        int i;
        for (i = 0; i < alarmtime; i++)
        {
            //模拟每秒走时
            Thread.Sleep(1000); 
            //每秒嘀嗒一下
            OnTick();
        }
        //到达定时时间则响铃
        if (i == alarmtime)
            OnAlarm();

    }

    //嘀嗒事件
    protected virtual void OnTick()
    {
        if (Tick != null)
            Tick(this, EventArgs.Empty);
    }

    //响铃事件
    protected virtual void OnAlarm()
    {
        if (Alarm != null)
            Alarm(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //实例化闹钟对象，并设置定时时间
        AlarmClock clock = new AlarmClock(15);

        //为嘀嗒事件添加一个处理方法
        void OnTick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick...");
        }
        clock.Tick += OnTick;

        //为响铃事件添加一个处理方法
        void OnAlarm(object sender, EventArgs e)
        {
            Console.WriteLine("Alarm!");
        }
        clock.Alarm += OnAlarm;

        //启动闹钟
        clock.Start();
    }
}
