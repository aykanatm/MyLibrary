using System.Collections.Generic;

namespace IOUtils.Packaging
{
    public class FilePackage
    {
        public string FilePath { get; set; }
        public IEnumerable<string> ContentFilePathList { get; set; }
    }
}
