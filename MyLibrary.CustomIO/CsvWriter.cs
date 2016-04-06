using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyLibrary.CustomIO
{
    public class CsvWriter<T> where T : CsvableBase
    {
        private GenericXmlSerializer<T> _gxs;
        
        public void WriteFromXml(string directoryPath, string fileExtension, string destination)
        {
            var filePaths = Directory.GetFiles(directoryPath, fileExtension, SearchOption.AllDirectories);
            if (filePaths.Length > 0)
            {
                using (var sw = new StreamWriter(destination))
                {
                    foreach (var filePath in filePaths)
                    {
                        _gxs = new GenericXmlSerializer<T>();
                        var obj = _gxs.DeSerialize(filePath);
                        sw.WriteLine(obj.ToCsv());
                    }
                }
            }
        }

        public void WriteFromXml(string directoryPath, string fileExtension, string destination, string[] propertiesToIgnore)
        {
            var filePaths = Directory.GetFiles(directoryPath, fileExtension, SearchOption.AllDirectories);
            if (filePaths.Length > 0)
            {
                using (var sw = new StreamWriter(destination))
                {
                    foreach (var filePath in filePaths)
                    {
                        _gxs = new GenericXmlSerializer<T>();
                        var obj = _gxs.DeSerialize(filePath);
                        sw.WriteLine(obj.ToCsv(propertiesToIgnore));
                    }
                }
            }
        }
        public void WriteFromXml(string directoryPath, string fileExtension, string destination, int[] propertyIndexesToIgnore)
        {
            var filePaths = Directory.GetFiles(directoryPath, fileExtension, SearchOption.AllDirectories);
            if (filePaths.Length > 0)
            {
                using (var sw = new StreamWriter(destination))
                {
                    foreach (var filePath in filePaths)
                    {
                        _gxs = new GenericXmlSerializer<T>();
                        var obj = _gxs.DeSerialize(filePath);
                        sw.WriteLine(obj.ToCsv(propertyIndexesToIgnore));
                    }
                }
            }
        }

        public void WriteFromEnumerable(IEnumerable<T> objects, string destination)
        {
            var objs = objects as IList<T> ?? objects.ToList();
            if (objs.Any())
            {
                using (var sw = new StreamWriter(destination))
                {
                    foreach (var obj in objs)
                    {
                        sw.WriteLine(obj.ToCsv());
                    }
                }
            }
        }

        public void WriteFromEnumerable(IEnumerable<T> objects, string destination, string[] propertiesToIgnore)
        {
            var objs = objects as IList<T> ?? objects.ToList();
            if (objs.Any())
            {
                using (var sw = new StreamWriter(destination))
                {
                    foreach (var obj in objs)
                    {
                        sw.WriteLine(obj.ToCsv(propertiesToIgnore));
                    }
                }
            }
        }

        public void WriteFromEnumerable(IEnumerable<T> objects, string destination, int[] propertyIndexesToIgnore)
        {
            var objs = objects as IList<T> ?? objects.ToList();
            if (objs.Any())
            {
                using (var sw = new StreamWriter(destination))
                {
                    foreach (var obj in objs)
                    {
                        sw.WriteLine(obj.ToCsv(propertyIndexesToIgnore));
                    }
                }
            }
        }
    }
}
