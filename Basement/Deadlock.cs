using Basement.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basement
{
    public class Deadlock : IProceed
    {
        public void Act()
        {
            Do1();
        }

        private void Do1()
        {
            var lockA = new object();
            var lockB = new object();
            var cancellationSource = new CancellationTokenSource();
            var cancellationToken = cancellationSource.Token;
            Task.Factory.StartNew(() =>
              {
                  Thread.Sleep(2000);
                  cancellationSource.Cancel();
                  Console.WriteLine("end deadlock");
              });

            var tsk1 = Task.Run(() =>
            {
                lock (lockA)
                {
                    Console.WriteLine("lockA of tsk1");
                    lock (lockB)
                    {
                        Console.WriteLine("lockB of tsk1");
                        Thread.Sleep(10);
                    }
                }
            });

            var tsk2 = Task.Run(() =>
            {
                lock (lockB)
                {
                    Console.WriteLine("lockA of tsk2");
                    lock (lockA)
                    {
                        Console.WriteLine("lockB of tsk2");
                        Thread.Sleep(10);
                    }
                }
            });
            Console.WriteLine("Deadlock is happening now");
            try
            {
                Task.WaitAll(new Task[] { tsk1, tsk2 }, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}

