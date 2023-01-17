using System;
using System.Diagnostics;

namespace landing
{
    public class Landing
    {
        //Initialise highest and lowest choices
        public static int low;
        public static int high;

        public static string readString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            }
            while (result == "");
            return result;
        }

        public static int readInt(string prompt)
        {
            int result;
            do
            {
                string intString = readString(prompt);
                result = int.Parse(intString);
            }
            while ((result < low || (result > high)));
            return result; 
        }
        
        static void Time()
        {
            var timer = new Stopwatch();
            Console.Clear();
            Console.WriteLine("Type 'B' to return to the landing page\n");
            string usrInput = readString("Press P to start the timer\n");

            if (usrInput.ToUpper() == "P")
            {
                timer.Start();
                usrInput = "";
                Console.WriteLine("Timer started!");
                string usrEnd = readString("Enter F to stop the timer and print your time\n");

                if (usrEnd.ToUpper() == "F")
                {
                    TimeSpan timeTaken = timer.Elapsed;
                    timer.Stop();
                    Console.WriteLine("Timer taken: " + timeTaken.ToString(@"hh\:ss\.fff"));
                }
            }

            if (usrInput.ToUpper() == "B")
            {
                usrInput = "";
                Main();
            }
        }

        static void Main()
        {
            Console.Clear();

            //initialise highest and lowest choices
            high = 2;
            low = 1;

            //landing introduction
            Console.WriteLine("Welcome! What would you like to do today?");
            int usrChoice = readInt("1. Time game\n" +
                "2. Quit\n");

            if (usrChoice == 1)
            {
                Time();
            }

            //exit
            while (usrChoice == 3)
            {
                Console.Clear();
                Console.WriteLine();
                int verify = readInt("Are you sure you want to quit?\n" +
                    "1. Yes\n" +
                    "2. No\n");
                if (verify == 1)
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    usrChoice = 0;
                    Console.Clear();
                    Main();
                }
            }
        }
    }
}