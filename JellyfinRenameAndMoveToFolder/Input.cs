using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.Jellyfin.RenameAndMove
{
    public static class Input
    {
        /// <summary>
        /// Returns input key as lower case.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="validChoices"></param>
        /// <returns></returns>
        public static string GetKey(string question, params char[] validChoices)
        {
            while (true)
            {
                Console.Write(question);
                var key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (validChoices.Contains(key)) return key.ToString().ToLower();
            }
        }

        public static string ReadLine(string question, bool checkCase = false, params string[] validValues)
        {
            if (validValues == null) validValues = new string[0];
            if (checkCase == false) validValues = validValues.Select(x => x.ToLower()).ToArray();
            var value = "";
            while (true)
            {
                Console.Write(question);
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value) == false)
                {
                    if (validValues.Contains(checkCase ? value : value.ToLower()))
                    {
                        return value;
                    }
                }
                Console.WriteLine("Please choose form: " + string.Join(", ", validValues));
            }
        }

    }
}
