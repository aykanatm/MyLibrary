using System;
using System.Collections.Generic;
using System.Linq;
using StringUtils.ExtensionMethods;

namespace IOUtils.Csv
{
    public abstract class CsvableBase
    {
        public virtual string ToCsv(bool needPreprocessing, char seperator)
        {
            string output = "";

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                {
                    var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[] {typeof(bool), typeof(char) });
                    output += m.Invoke(properties[i].GetValue(this), new object [] {needPreprocessing, seperator});
                }
                else
                {
                    if (needPreprocessing)
                    {
                        output += PreProcess(properties[i].GetValue(this).ToString());
                    }
                    else
                    {
                        output += properties[i].GetValue(this).ToString();
                    }
                }

                if (i != properties.Length - 1)
                {
                    output += seperator;
                }
            }

            return output;
        }

        public virtual string ToCsv(string[] propertyNames, bool isIgnore, bool needPreprocessing, char seperator)
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
                            output += seperator;
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[] { typeof(bool), typeof(char) });
                            output += m.Invoke(properties[i].GetValue(this), new object[] { needPreprocessing, seperator });
                        }
                        else
                        {
                            if (needPreprocessing)
                            {
                                output += PreProcess(properties[i].GetValue(this).ToString());
                            }
                            else
                            {
                                output += properties[i].GetValue(this).ToString();
                            }
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
                            output += seperator;
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[] { typeof(bool), typeof(char) });
                            output += m.Invoke(properties[i].GetValue(this), new object[] { needPreprocessing, seperator });
                        }
                        else
                        {
                            if (needPreprocessing)
                            {
                                output += PreProcess(properties[i].GetValue(this).ToString());
                            }
                            else
                            {
                                output += properties[i].GetValue(this).ToString();
                            }
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

        public virtual string ToCsv(int[] propertyIndexes, bool isIgnore, bool needPreprocessing, char seperator)
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
                            output += seperator;
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[] { typeof(bool), typeof(char) });
                            output += m.Invoke(properties[i].GetValue(this), new object[] { needPreprocessing, seperator });
                        }
                        else
                        {
                            if (needPreprocessing)
                            {
                                output += PreProcess(properties[i].GetValue(this).ToString());
                            }
                            else
                            {
                                output += properties[i].GetValue(this).ToString();
                            }
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
                            output += seperator;
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("ToCsv", new Type[] { typeof(bool), typeof(char) });
                            output += m.Invoke(properties[i].GetValue(this), new object[] { needPreprocessing, seperator });
                        }
                        else
                        {
                            if (needPreprocessing)
                            {
                                output += PreProcess(properties[i].GetValue(this).ToString());
                            }
                            else
                            {
                                output += properties[i].GetValue(this).ToString();
                            }
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

        public virtual string GetHeaders(char seperator)
        {
            string output = "";

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                {
                    var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[] {typeof(char)});
                    output += m.Invoke(properties[i].GetValue(this), new object[] {seperator});
                }
                else
                {
                    output += properties[i].Name;
                }

                if (i != properties.Length - 1)
                {
                    output += seperator;
                }
            }

            return output;
        }
        public virtual string GetHeaders(string[] propertyNames, bool isIgnore, char seperator)
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
                            output += seperator;
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[] { typeof(char) });
                            output += m.Invoke(properties[i].GetValue(this), new object[] { seperator });
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
                            output += seperator;
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[] { typeof(char) });
                            output += m.Invoke(properties[i].GetValue(this), new object[] { seperator });
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
        public virtual string GetHeaders(int[] propertyIndexes, bool isIgnore, char seperator)
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
                            output += seperator;
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[] { typeof(char) });
                            output += m.Invoke(properties[i].GetValue(this), new object[] { seperator });
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
                            output += seperator;
                        }

                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var m = properties[i].PropertyType.GetMethod("GetHeaders", new Type[] { typeof(char) });
                            output += m.Invoke(properties[i].GetValue(this), new object[] { seperator });
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

        public virtual void AssignValuesFromCsv(string[] propertyValues)
        {
            var properties = GetType().GetProperties();
            for (var i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType.IsSubclassOf(typeof (CsvableBase)))
                {
                    var instance = Activator.CreateInstance(properties[i].PropertyType);
                    var instanceProperties = instance.GetType().GetProperties();
                    var propertyList = new List<string>();

                    for (var j = 0; j < instanceProperties.Length; j++)
                    {
                        propertyList.Add(propertyValues[i+j]);
                    }
                    var m = instance.GetType().GetMethod("AssignValuesFromCsv", new Type[] { typeof(string[]) });
                    m.Invoke(instance, new object[] {propertyList.ToArray()});
                    properties[i].SetValue(this, instance);

                    i += instanceProperties.Length;
                }
                else
                {
                    var type = properties[i].PropertyType.Name;
                    switch (type)
                    {
                        case "Int32":
                            properties[i].SetValue(this, int.Parse(propertyValues[i]));
                            break;
                        default:
                            properties[i].SetValue(this, propertyValues[i]);
                            break;
                    }
                }
            }
        }
         
        private string PreProcess(string input)
        {
            input = input.ReplaceSpecialCharacters()
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
