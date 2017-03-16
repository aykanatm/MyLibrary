
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace CustomIO.Packaging
{
    public class FilePackageReader
    {
        private Dictionary<string, string> _filenameFileContentDictionary;
        private readonly string _filepath;

        public FilePackageReader(string filepath)
        {
            _filepath = filepath;
        }

        public Dictionary<string, string> GetFilenameFileContentDictionary()
        {
            try
            {
                _filenameFileContentDictionary = new Dictionary<string, string>();

                using (var fs = new FileStream(_filepath, FileMode.Open))
                {
                    using (var archive = new ZipArchive(fs))
                    {
                        foreach (var zipArchiveEntry in archive.Entries)
                        {
                            using (var stream = zipArchiveEntry.Open())
                            {
                                using (var zipSr = new StreamReader(stream))
                                {
                                    _filenameFileContentDictionary.Add(zipArchiveEntry.Name, zipSr.ReadToEnd());
                                }
                            }
                        }
                    }
                }

                return _filenameFileContentDictionary;
            }
            catch (Exception e)
            {
                var errorMessage = "Unable to open/read the package. " + e.Message;
                throw new Exception(errorMessage);
            }
        }
    }
}
