using System.Collections.Generic;
using System.IO;

namespace IOUtils.Csv
{
    public class CsvReader<T> where T : CsvableBase, new()
    {
        private readonly char _seperator;
        public CsvReader(char seperator)
        {
            _seperator = seperator;
        }
        public IEnumerable<T> Read(string filePath, bool hasHeaders)
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
                        if (!hasHeaders)
                        {
                            var obj = new T();
                            var propertyValues = line.Split(_seperator);
                            obj.AssignValuesFromCsv(propertyValues);
                            objects.Add(obj);
                        }
                        hasHeaders = false;
                    }
                } while ( line != null);
            }

            return objects;
        }
    }
}
