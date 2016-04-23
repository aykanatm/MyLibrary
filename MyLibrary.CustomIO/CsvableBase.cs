using System;
using System.Linq;

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
                    if (properties[i].PropertyType.IsSubclassOf(typeof (CsvableBase)))
                    {
                        var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[0]);
                        output += m.Invoke(properties[i].GetValue(this), new object[0]);
                    }
                    else
                    {
                        output += PreProcess(properties[i].GetValue(this).ToString());
                    }
                }
                else
                {
                    if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                    {
                        var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[0]);
                        output += m.Invoke(properties[i].GetValue(this), new object[0]);
                    }
                    else
                    {
                        output += PreProcess(properties[i].GetValue(this).ToString());
                    }
                    output += ",";
                }
            }

            return output;
        }

        public virtual string ToCsv(string[] propertyNames, bool isIgnore)
        {
            string output = "";
            bool isFirstPropertyWritten = false;
            

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (isIgnore)
                {
                    if (!propertyNames.Contains(properties[i].Name))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[0]);
                            output += m.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += PreProcess(properties[i].GetValue(this).ToString());
                        }

                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
                else
                {
                    if (propertyNames.Contains(properties[i].Name))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[0]);
                            output += m.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += PreProcess(properties[i].GetValue(this).ToString());
                        }

                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
            }

            return output;
        }

        public virtual string ToCsv(int[] propertyIndexes, bool isIgnore)
        {
            string output = "";

            bool isFirstPropertyWritten = false;

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (isIgnore)
                {
                    if (!propertyIndexes.Contains(i))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[0]);
                            output += m.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += PreProcess(properties[i].GetValue(this).ToString());
                        }

                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
                else
                {
                    if (propertyIndexes.Contains(i))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[0]);
                            output += m.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += PreProcess(properties[i].GetValue(this).ToString());
                        }

                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
                
            }

            return output;
        }

        public virtual string GetHeaders()
        {
            string output = "";

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (i == properties.Length - 1)
                {
                    if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                    {
                        var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[0]);
                        output += m.Invoke(properties[i].GetValue(this), new object[0]);
                    }
                    else
                    {
                        output += properties[i].Name;
                    }
                }
                else
                {
                    if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                    {
                        var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[0]);
                        output += m.Invoke(properties[i].GetValue(this), new object[0]);
                    }
                    else
                    {
                        output += properties[i].Name;
                    }
                    output += ",";
                }
            }

            return output;
        }
        public virtual string GetHeaders(string[] propertyNames, bool isIgnore)
        {
            string output = "";
            bool isFirstPropertyWritten = false;


            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (isIgnore)
                {
                    if (!propertyNames.Contains(properties[i].Name))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[0]);
                            output += m.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += properties[i].Name;
                        }

                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
                else
                {
                    if (propertyNames.Contains(properties[i].Name))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[0]);
                            output += m.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += properties[i].Name;
                        }

                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
            }

            return output;
        }
        public virtual string GetHeaders(int[] propertyIndexes, bool isIgnore)
        {
            string output = "";

            bool isFirstPropertyWritten = false;

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (isIgnore)
                {
                    if (!propertyIndexes.Contains(i))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[0]);
                            output += m.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += properties[i].Name;
                        }

                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
                else
                {
                    if (propertyIndexes.Contains(i))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[0]);
                            output += m.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += properties[i].Name;
                        }

                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
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
            input = input.Replace('ı', 'i')
                .Replace('ç', 'c')
                .Replace('ö', 'o')
                .Replace('ş', 's')
                .Replace('ü', 'u')
                .Replace('ğ', 'g')
                .Replace('İ', 'I')
                .Replace('Ç', 'C')
                .Replace('Ö', 'O')
                .Replace('Ş', 'S')
                .Replace('Ü', 'U')
                .Replace('Ğ', 'G')
                .Replace("\"", "\"\"")
                .Trim();
            if (input.Contains(","))
            {
                input = "\"" + input + "\"";
            }
            return input;
        }
    }
}
