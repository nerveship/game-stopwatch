/*using System.Data.SQLite;

string cs = "Data Source=:memory:";
string stm = "SELECT SQLITE_VERSION()";

using var con = new SQLiteConnection(cs);
con.Open();

using var cmd = new SQLiteCommand(stm, con);
string version = cmd.ExecuteScalar().ToString();

Console.WriteLine($"SQLite version: {version}");*/

using System;
using System.Data.SQLite;

namespace landing
{
    public class Landing
    {
        public static int low = 0;
        public static int high = 3;

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
        static void Main()
        {
            Console.WriteLine("Welcome! What would you like to do today?");
            int usrChoice = readInt("1. Log new game\n" +
                "2. Check currently playing\n" +
                "3. Quit\n");

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
                    Console.Clear();
                    Main();
                }
            }
        }
    }
}