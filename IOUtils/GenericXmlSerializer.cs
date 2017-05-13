using System;
using System.IO;
using System.Xml.Serialization;

namespace IOUtils
{
    public class GenericXmlSerializer<T> where T : class
    {
        private readonly XmlSerializer _xmlSerializer;

        public GenericXmlSerializer()
        {
            _xmlSerializer = new XmlSerializer(typeof(T));
        }

        public void Serialize(T obj, string filePath)
        {
            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    _xmlSerializer.Serialize(sw, obj);
                }
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while serializing. " + e.Message;
                throw new Exception(errorMessage);
            }
        }

        public T DeSerialize(string filePath)
        {
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    return (T)_xmlSerializer.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while deserializing. " + e.Message;
                throw new Exception(errorMessage);
            }
        }

        public T DeSerializeFromString(string xmlString)
        {
            try
            {
                using (TextReader tr = new StringReader(xmlString))
                {
                    return (T)_xmlSerializer.Deserialize(tr);
                }
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while deserializing XML string. " + e.Message;
                throw new Exception(errorMessage);
            }
        }
    }
}
