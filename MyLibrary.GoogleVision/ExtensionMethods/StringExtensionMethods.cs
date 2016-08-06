using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.GoogleVision.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string RemoveLastChar(this string input)
        {
            return input.Remove(input.Length - 1);
        }
    }
}
