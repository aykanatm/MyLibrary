using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyLibrary.CustomIO
{
    public abstract class CsvableBase
    {
        public virtual string ToCsv()
        {
            string output = "";

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (i == properties.Length - 1)
                {
                    output += PreProcess(properties[i].GetValue(this).ToString());
                }
                else
                {
                    output += PreProcess(properties[i].GetValue(this).ToString()) + ",";
                }
            }

            return output;
        }

        public virtual string ToCsv(string[] propertiesToIgnore)
        {
            string output = "";

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (!propertiesToIgnore.Contains(properties[i].Name))
                {
                    if (i == properties.Length - 1)
                    {
                        output += PreProcess(properties[i].GetValue(this).ToString());
                    }
                    else
                    {
                        output += PreProcess(properties[i].GetValue(this).ToString()) + ",";
                    }
                }
            }

            return output;
        }

        public virtual string ToCsv(int[] propertiesToIgnore)
        {
            string output = "";

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (!propertiesToIgnore.Contains(i))
                {
                    if (i == properties.Length - 1)
                    {
                        output += PreProcess(properties[i].GetValue(this).ToString());
                    }
                    else
                    {
                        output += PreProcess(properties[i].GetValue(this).ToString()) + ",";
                    }
                }
            }

            return output;
        }


        public virtual void AssignValuesFromCsv(string[] proprtyValues)
        {
            var properties = GetType().GetProperties();
            for (var i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(this, proprtyValues[i]);
            }
        }
         
        private string PreProcess(string input)
        {
            string output = input.Replace('ı', 'i').Replace('ç', 'c').Replace('ö', 'o').Replace('ş', 's').Replace('ü', 'u').Replace('ğ', 'g')
                                 .Replace('İ', 'I').Replace('Ç', 'C').Replace('Ö', 'O').Replace('Ş', 'S').Replace('Ü', 'U').Replace('Ğ', 'G');
            output = output.Trim();
            return output;
        }
    }
}
