﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyLibrary.ClassOperations
{
    public class GenericCloner<T> where T : class
    {
        public T Clone(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
