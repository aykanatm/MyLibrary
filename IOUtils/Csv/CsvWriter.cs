using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IOUtils.Csv
{
    public class CsvWriter<T> where T : CsvableBase
    {
        private GenericXmlSerializer<T> _gxs;
        private readonly char _seperator;

        public CsvWriter(char seperator)
        {
            _seperator = seperator;
        }

        public void WriteFromXml(string directoryPath, string fileExtension, string destination, bool displayHeaders, bool needPreprocessing)
        {
            var filePaths = Directory.GetFiles(directoryPath, fileExtension, SearchOption.AllDirectories);
            if (filePaths.Length > 0)
            {
                using (var sw = new StreamWriter(destination))
                {
                    _gxs = new GenericXmlSerializer<T>();
                    if (displayHeaders)
                    {
                        var obj = _gxs.DeSerialize(filePaths[0]);
                        sw.WriteLine(obj.GetHeaders(_seperator));
                    }
                    foreach (var filePath in filePaths)
                    {
                        var obj = _gxs.DeSerialize(filePath);
                        sw.WriteLine(obj.ToCsv(needPreprocessing, _seperator));
                    }
                }
            }
        }

        public void WriteFromXml(string directoryPath, string fileExtension, string destination, string[] propertyNames, bool isIgnore, bool displayHeaders, bool needPreprocessing)
        {
            var filePaths = Directory.GetFiles(directoryPath, fileExtension, SearchOption.AllDirectories);
            if (filePaths.Length > 0)
            {
                using (var sw = new StreamWriter(destination))
                {
                    _gxs = new GenericXmlSerializer<T>();
                    if (displayHeaders)
                    {
                        var obj = _gxs.DeSerialize(filePaths[0]);
                        sw.WriteLine(obj.GetHeaders(_seperator));
                    }
                    foreach (var filePath in filePaths)
                    {
                        var obj = _gxs.DeSerialize(filePath);
                        sw.WriteLine(obj.ToCsv(propertyNames, isIgnore, needPreprocessing,_seperator));
                    }
                }
            }
        }
        public void WriteFromXml(string directoryPath, string fileExtension, string destination, int[] propertyIndexes, bool isIgnore, bool displayHeaders, bool needPreprocessing)
        {
            var filePaths = Directory.GetFiles(directoryPath, fileExtension, SearchOption.AllDirectories);
            if (filePaths.Length > 0)
            {
                using (var sw = new StreamWriter(destination))
                {
                    _gxs = new GenericXmlSerializer<T>();
                    if (displayHeaders)
                    {
                        var obj = _gxs.DeSerialize(filePaths[0]);
                        sw.WriteLine(obj.GetHeaders(_seperator));
                    }
                    foreach (var filePath in filePaths)
                    {
                        var obj = _gxs.DeSerialize(filePath);
                        sw.WriteLine(obj.ToCsv(propertyIndexes, isIgnore, needPreprocessing, _seperator));
                    }
                }
            }
        }

        public void WriteFromEnumerable(IEnumerable<T> objects, string destination, bool displayHeaders, bool needPreprocessing)
        {
            var objs = objects as IList<T> ?? objects.ToList();
            if (objs.Any())
            {
                using (var sw = new StreamWriter(destination))
                {
                    if (displayHeaders)
                    {
                        sw.WriteLine(objs[0].GetHeaders(_seperator));
                    }
                    foreach (var obj in objs)
                    {
                        sw.WriteLine(obj.ToCsv(needPreprocessing, _seperator));
                    }
                }
            }
        }

        public void WriteFromEnumerable(IEnumerable<T> objects, string destination, string[] propertyNames, bool isIgnore, bool displayHeaders, bool needPreprocessing)
        {
            var objs = objects as IList<T> ?? objects.ToList();
            if (objs.Any())
            {
                using (var sw = new StreamWriter(destination))
                {
                    if (displayHeaders)
                    {
                        sw.WriteLine(objs[0].GetHeaders(propertyNames,isIgnore, _seperator));
                    }
                    foreach (var obj in objs)
                    {
                        sw.WriteLine(obj.ToCsv(propertyNames, isIgnore, needPreprocessing, _seperator));
                    }
                }
            }
        }

        public void WriteFromEnumerable(IEnumerable<T> objects, string destination, int[] propertyIndexes, bool isIgnore, bool displayHeaders, bool needPreprocessing)
        {
            var objs = objects as IList<T> ?? objects.ToList();
            if (objs.Any())
            {
                using (var sw = new StreamWriter(destination))
                {
                    if (displayHeaders)
                    {
                        sw.WriteLine(objs[0].GetHeaders(propertyIndexes, isIgnore, _seperator));
                    }
                    foreach (var obj in objs)
                    {
                        sw.WriteLine(obj.ToCsv(propertyIndexes, isIgnore, needPreprocessing, _seperator));
                    }
                }
            }
        }
    }
}
