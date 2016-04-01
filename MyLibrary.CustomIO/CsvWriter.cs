using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        _gxs = new GenericXmlSerializer<T>(filePath);
                        var obj = _gxs.DeSerialize();
                        sw.WriteLine(obj.ToCsv());
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
    }
}
