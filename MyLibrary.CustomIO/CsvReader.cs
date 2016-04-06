using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.CustomIO
{
    public class CsvReader<T> where T : CsvableBase, new()
    {
        public IEnumerable<T> Read(string filePath)
        {
            var objects = new List<T>();
            using (var sr = new StreamReader(filePath))
            {
                string line;
                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        var obj = new T();
                        var propertyValues = line.Split(',');
                        obj.AssignValuesFromCsv(propertyValues);
                        objects.Add(obj);
                    }
                } while ( line != null);
            }

            return objects;
        }
    }
}
