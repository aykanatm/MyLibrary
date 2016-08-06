using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Vision.v1.Data;

namespace MyLibrary.GoogleVision.ExtensionMethods
{
    public static class ListExtensionMethods
    {
        public static string EntityAnnotationListToString(this IList<EntityAnnotation> input)
        {
            string values = "";
            if (input != null)
            {
                if (input.Any())
                {
                    foreach (var annotation in input)
                    {
                        values += annotation.Description + ", ";
                    }
                    values = values.Replace("\n", "");
                    values = values.Trim();
                    values = values.RemoveLastChar();
                }
            }
            return values;
        }
    }
}
