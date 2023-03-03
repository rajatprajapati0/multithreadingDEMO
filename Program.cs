using System;
using System.Threading; //thread class presrnt in this space

namespace DemoWorkOnMultithreading 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program o = new Program();
            Thread t1 = new Thread(o.firstmethod); //life cycle started
            Console.WriteLine("born t1 but it is in unstarted state");

            Thread t2 = new Thread(secondmethod); //life cycle started
            Console.WriteLine("born t2 but it is in unstarted state");

            Thread t3 = new Thread(thirdmethod); //life cycle started
            Console.WriteLine("born t3 but it is in unstarted state");

            // life cycle started When we creat an object of thread class 

            t1.Start();//t1 ready to run state or runnable
            t2.Start();//t2 ready to run state or runnable
            t3.Start();//t2 ready to run state or runnable
            //task();

            Console.WriteLine("main thread died");
        }


        static void task() 
        {
            Program o = new Program();

            Task t1 = Task.Run(o.firstmethod);
            Task t2 = Task.Run(secondmethod);
            Task t3 = Task.Run(thirdmethod);
            //task will creat thread for these method
            //it will hold main thread on wait untill all three methods exicuted 
            Task.WaitAll(t1,t2,t3);
        }

        void firstmethod()
        {
          for(int i=0; i<100; i++)
          {
                if (i == 50) 
                {
                    Console.WriteLine("        t1 thread is in sleeping state\n");//not runable state

                    Thread.Sleep(1000);
                }
                Console.WriteLine("t1  is in runing state");
                //this state exisit at the time of execution
          }

            Console.WriteLine("******* t1 thread died");
        }
    
        static void secondmethod()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 60)
                {
                    Console.WriteLine("       t2 thread is in sleeping state\n");//not runable state

                    Thread.Sleep(1000);
                }
                Console.WriteLine("t2 is in runing state");
                //this state exisit at the time of execution
            }
            Console.WriteLine("      ****** t2 thread died");

        }

        static void thirdmethod()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 90)
                {
                    Console.WriteLine("        t3 thread is in waiting state \n");//not runable state

                    Thread.SpinWait(1000);
                }
                Console.WriteLine("t3 is in runing state");
                //this state exisit at the time of execution
            }

            Console.WriteLine("       ****** t3 thread died");

        }


    }



}