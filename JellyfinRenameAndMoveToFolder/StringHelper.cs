using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.Jellyfin.RenameAndMove
{
    public static class StringHelper
    {
        /// <summary>
        /// Ska konvertera XXXX-XXXX till Xxxx-Xxxx
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CapitalizeFirstLetter(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            if (value.Length == 1) return value.ToUpper();
            var retval = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();

            var splitted = retval.Split('-', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < splitted.Length; i++) splitted[i] = CapitalizeFirstLetter(splitted[i]);
            retval = string.Join("-", splitted);

            splitted = retval.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < splitted.Length; i++) splitted[i] = CapitalizeFirstLetter(splitted[i]);
            retval = string.Join(" ", splitted);
            return retval;
        }


        private static string RemoveDuplicateChar(string value, string find)
        {
            while (value.Contains(find + find)) value = value.Replace("%%", "%");
            return value;
        }
    }
}
