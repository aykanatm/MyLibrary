using System;
using System.IO;
using System.Xml.Serialization;

namespace MyLibrary.CustomIO
{
    public class GenericXmlSerializer<T> where T : class
    {
        private readonly XmlSerializer _xmlSerializer;
        private readonly string _filePath;

        public event Action<Exception> SerializationFailed;
        public event Action<Exception> DeSerializationFailed;

        public GenericXmlSerializer(string filePath)
        {
            _xmlSerializer = new XmlSerializer(typeof(T));
            _filePath = filePath;
        }

        public void Serialize(T obj)
        {
            using (var sw = new StreamWriter(_filePath))
            {
                try
                {
                    _xmlSerializer.Serialize(sw, obj);
                }
                catch (Exception e)
                {
                    if (SerializationFailed != null)
                    {
                        SerializationFailed(e);
                    }
                }
            }
        }

        public T DeSerialize()
        {
            using (var sr = new StreamReader(_filePath))
            {
                try
                {
                    return (T)_xmlSerializer.Deserialize(sr);
                }
                catch (Exception e)
                {
                    if (DeSerializationFailed != null)
                    {
                        DeSerializationFailed(e);
                    }
                    return null;
                }
            }
        }
    }
}
