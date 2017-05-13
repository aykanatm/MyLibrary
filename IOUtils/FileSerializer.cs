using System;
using System.IO;

namespace IOUtils
{
    public class FileSerializer
    {
        public byte[] Bytes { get; private set; }

        private FileSerializer()
        {
            
        }

        public static FileSerializer FromFile(string filePath)
        {
            var fileSerializer = new FileSerializer {Bytes = GenerateBytes(filePath)};
            return fileSerializer;
        }

        public static FileSerializer FromString(string str)
        {
            try
            {
                var stringBytes = str.Split(',');

                var bytes = new byte[stringBytes.Length];

                for (var i = 0; i < stringBytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(stringBytes[i]);
                }

                var fileSerializer = new FileSerializer { Bytes = bytes };

                return fileSerializer;
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while generating the file serializer. " + e.Message;
                throw new Exception(errorMessage);
            }
        }

        private static byte[] GenerateBytes(string filePath)
        {
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var binaryReader = new BinaryReader(fileStream))
                    {
                        return binaryReader.ReadBytes((int)fileStream.Length);
                    }
                }
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while generating bytes. " + e.Message;
                throw new Exception(errorMessage);
            }
        }

        public void GenerateFile(string savePath)
        {
            try
            {
                if (Bytes != null)
                {
                    if (Bytes.Length != 0)
                    {
                        File.WriteAllBytes(savePath, Bytes);
                    }
                    else
                    {
                        throw new Exception("Byte array does not have any elements!");
                    }
                }
                else
                {
                    throw new Exception("Byte array is null!");
                }
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured during file generation. " + e.Message;
                throw new Exception(errorMessage);
            }
        }
    }
}
