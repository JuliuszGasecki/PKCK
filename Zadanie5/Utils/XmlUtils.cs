using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Utils
{

    public static class XmlUtils
    {
        public static bool NewLineOnAttributes { get; set; }
        public static T Deserialize<T>(string filePath)
        {
            XmlSerializer selializer = new XmlSerializer(typeof(T));
            using (Stream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return (T)selializer.Deserialize(fs);
            }
        }

        private static string ToXml(object obj, XmlSerializerNamespaces ns)
        {
            Type T = obj.GetType();

            var xs = new XmlSerializer(T, "http://www.foo.com");
            var ws = new XmlWriterSettings { Indent = true, NewLineOnAttributes = NewLineOnAttributes, OmitXmlDeclaration = true };

            var sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, ws))
            {
                xs.Serialize(writer, obj, ns);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Serializes an object to an XML string.
        /// </summary>
        public static string XmlToXmlString(object obj)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.foo.com");
            return ToXml(obj, ns);
        }

        public static void Serialize<T>(T dataToSerialize, string path)
        {
            TextWriter writer = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(path);
                serializer.Serialize(writer, dataToSerialize);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

    }
}