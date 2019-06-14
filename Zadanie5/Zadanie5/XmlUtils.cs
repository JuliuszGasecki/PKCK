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
                return (T) selializer.Deserialize(fs);
            }
        }

        public static string ToXml(object obj, XmlSerializerNamespaces ns)
        {
            Type T = obj.GetType();

            var xs = new XmlSerializer(T);
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
        public static string ToXml(object obj)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            return ToXml(obj, ns);
        }

    }
}