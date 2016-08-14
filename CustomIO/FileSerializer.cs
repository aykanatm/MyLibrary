﻿using System;
using System.IO;

namespace CustomIO
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
            var stringBytes = str.Split(',');

            var bytes = new byte[stringBytes.Length];

            for (var i = 0; i < stringBytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(stringBytes[i]);
            }

            var fileSerializer = new FileSerializer {Bytes = bytes};
            return fileSerializer;
        }

        private static byte[] GenerateBytes(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    return binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }

        public void GenerateFile(string savePath)
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
    }
}