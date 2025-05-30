using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Type_Master
{
    
    internal class Program
    {
        static void Main(string[] args)
        {

            ParameterizedThreadStart ts1 = new ParameterizedThreadStart(Game.PrintMessage);
            Thread t1 = new Thread(ts1);
            t1.Start("*****GAME STARTED , BEST OF LUCK****");
            t1.Join();
            Thread t2 = new Thread(ts1);
            t2.Start("****YOU ENTERED GAME , BE READY****");
            t2.Join();
            Thread t3 = new Thread(ts1);
            t3.Start("****There are 2 Levels , Complete Both levels in 25 Seconds****");
            t3.Join();





            Game.Timer();

        }
    }


    class Game
    {
        static bool timeup = true;
        static string level1 = "The Cheater Cheats the Cheating Code";
        static string level2 = "She Sell Sea Shell On The Sea Shore!";

        static string ans1;
        static string ans2;
        //public static void GameStar()
        //{


        //}

        public static void Timer()
        {
            ThreadStart ts3 = new ThreadStart(TakeInput);
            Thread t4 = new Thread(ts3);
            t4.Start();
            Thread.Sleep(20 * 1000);
            try
            {
                t4.Abort();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Game Over");
            ThreadStart ts4 = new ThreadStart(check);
            Thread t5 = new Thread(ts4);
            t5.Start();



        }


        public static void PrintMessage(Object obj)

        {
            string Message = (string)obj;
            Console.WriteLine(Message);
            Console.WriteLine();
            Thread.Sleep(2000);
        }

        public static void TakeInput()

        {
            Console.WriteLine("level1 : {0}", level1);
            Console.WriteLine("Enter Input1 : ");
            ans1 = Console.ReadLine();
            Console.WriteLine("level12: {0}", level2);
            Console.WriteLine("Enter Input2 : ");
            ans2 = Console.ReadLine();
            timeup = false;

        }


        public static void check()
        {
            if(!timeup)
            {
                if (level1 == ans1 && level2 == ans2)
                {
                    Console.WriteLine("You Won...Both Levels");
                }
                else if(level1 == ans1)
                {
                    Console.WriteLine("You Lost...Level2");
                }
                else if(level2 == ans2)
                {
                    Console.WriteLine("You Lost...Level1");
                }
                else
                {
                    Console.WriteLine("You Lost...Both Levels");
                }

            }
            else
            {
                Console.WriteLine("You Lost...Time Up");
            }
            
        }


    }


}
