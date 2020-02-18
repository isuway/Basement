using Basement.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Basement
{
    public class AlternatingThreads : IProceed
    {
        public void Act()
        {
            Run1();
        }

        private void Run1()
        {
            TickTock tt = new TickTock();
            MyThread mt1 = new MyThread("Tick", tt);
            MyThread mt2 = new MyThread("Tock", tt);
            mt1.Thrd.Join();
            mt2.Thrd.Join();
            Console.WriteLine("Timer stopped");
        }
    }

    public class TickTock
    {
        object lockOn = new object();
        public void Tick(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                { // остановить часы 
                    Monitor.Pulse(lockOn); // уведомить любые ожидающие потоки return;
                }
                Console.Write("Tick ");
                Monitor.Pulse(lockOn); // разрешить выполнение метода Tock() 
                Monitor.Wait(lockOn);    // ожидать завершения метода Tock()
            }
        }
        public void Tock(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                { // остановить часы
                    Monitor.Pulse(lockOn); // уведомить любые ожидающие потоки return;
                }
                Console.WriteLine("Tock ");
                Monitor.Pulse(lockOn); // разрешить выполнение метода Tick() 
                Monitor.Wait(lockOn);    // ожидать завершения метода Tick()
            }
        }
    }
    class MyThread
    {
        public Thread Thrd;
        TickTock ttOb;
        public MyThread(string name, TickTock tt)
        {
            ttOb = tt;
            Thrd = new Thread(Run)
            {
                Name = name
            };
            Thrd.Start();
        }
        void Run()
        {
            if (Thrd.Name == "Tick")
            {
                for (int i = 0; i < 5; i++)
                    ttOb.Tick(true);
                ttOb.Tick(false);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                    ttOb.Tock(true);
                ttOb.Tock(false);
            }
        }
    }
}
