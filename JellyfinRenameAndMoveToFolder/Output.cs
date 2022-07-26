using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.Jellyfin.RenameAndMove
{
    public static class Output
    {
        public static void WriteTitleLine(string value, int surroundWithStars = 3, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            PrintStars(surroundWithStars);

            Console.Write(value);

            PrintStars(surroundWithStars);
            Console.WriteLine();
            Console.ResetColor();
        }

        private static void PrintStars(int numberOfStars)
        {
            for (int i = 0; i < numberOfStars; i++)
            {
                Console.Write("*");
            }
        }

        public static void WriteError(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void WriteOK(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }
}
