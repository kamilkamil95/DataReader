using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Engine
{
    public static class ConsoleLogger
    {

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-" + message);
        }
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-" + message);
        }
        public static void ErrorHandler(Exception message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-" + message);
        }
        public static void UserChoice(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-" + message);
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("-" + message);
        }

    }
}
