using System.IO;
using System.Xml.Serialization;

namespace CustomIO
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
            using (var sw = new StreamWriter(filePath))
            {
                _xmlSerializer.Serialize(sw, obj);
            }
        }

        public T DeSerialize(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                return (T)_xmlSerializer.Deserialize(sr);
            }
        }
    }
}
