using System.IO;
using System.Xml.Serialization;

public class XmlSerialization
{
    public static T LoadFromXml<T>(string fileName)
    {
        if (File.Exists(fileName))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StreamReader(fileName))
                return (T)serializer.Deserialize(textReader);
        }
        else
            return default(T);
    }

    public static void SaveToXml<T>(string fileName, T t)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter textReader = new StreamWriter(fileName))
                serializer.Serialize(textReader, t);
        }
    }
}


