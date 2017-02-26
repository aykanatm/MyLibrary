using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIO.Packaging
{
    public class FilePackageWriter
    {
        private readonly string _filepath;
        private string _tempDirectoryPath;

        public FilePackageWriter(FilePackage filePackage)
        {
            _filepath = filePackage.FilePath;
        }

        public void GeneratePackage(IEnumerable<string> filePathList, bool deleteContents)
        {
            var filePaths = filePathList as IList<string> ?? filePathList.ToList();

            try
            {
                string parentDirectoryPath = null;
                string filename = null;

                var fileInfo = new FileInfo(_filepath);

                if (fileInfo.Exists)
                {
                    filename = fileInfo.Name;

                    var parentDirectoryInfo = fileInfo.Directory;
                    if (parentDirectoryInfo != null)
                    {
                        parentDirectoryPath = parentDirectoryInfo.FullName;
                    }
                    else
                    {
                        throw new NullReferenceException("Parent directory info was null!");
                    }

                    File.Delete(_filepath);
                }
                else
                {
                    var lastIndexOfFileSeperator = _filepath.LastIndexOf("\\", StringComparison.Ordinal);
                    if (lastIndexOfFileSeperator != -1)
                    {
                        parentDirectoryPath = _filepath.Substring(0, lastIndexOfFileSeperator);
                        filename = _filepath.Substring(lastIndexOfFileSeperator + 1,_filepath.Length - (lastIndexOfFileSeperator + 1));
                    }
                    else
                    {
                        throw new Exception("The input file path '" + _filepath +
                                            "' does not contain any file seperators.");
                    }
                }

                _tempDirectoryPath = parentDirectoryPath + "\\" + filename + "_temp";
                if (Directory.Exists(_tempDirectoryPath))
                {
                    Directory.Delete(_tempDirectoryPath, true);
                }

                Directory.CreateDirectory(_tempDirectoryPath);
                foreach (var filePath in filePaths)
                {
                    var filePathInfo = new FileInfo(filePath);
                    if (filePathInfo.Exists)
                    {
                        File.Copy(filePathInfo.FullName, _tempDirectoryPath + "\\" + filePathInfo.Name);
                    }
                    else
                    {
                        throw new FileNotFoundException("File path " + filePath + " doesn't exist!");
                    }
                }

                ZipFile.CreateFromDirectory(_tempDirectoryPath, _filepath);
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while generating the package. " + e.Message;
                throw new Exception(errorMessage);
            }
            finally
            {
                if (Directory.Exists(_tempDirectoryPath))
                {
                    Directory.Delete(_tempDirectoryPath, true);
                }

                if (deleteContents)
                {
                    foreach (var filePath in filePaths)
                    {
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                }
            }
        }
    }
}
