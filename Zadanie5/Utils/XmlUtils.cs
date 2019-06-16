using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Xsl;
using Mvp.Xml.Common.Xsl;

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

            //var xs = new XmlSerializer(T, "http://www.foo.com");
            var xs = new XmlSerializer(T, "");
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
            //ns.Add("", "http://www.foo.com");
            ns.Add("", "");
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
        public static void TransformXmlToHtml(string xmlPath, string directoryPath)
        {
            var raportXslt = new MvpXslTransform();
            var htmlXsl = new MvpXslTransform();
            try
            {
                string wantedPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                raportXslt.Load(wantedPath + "../../Documents/Zadanie5.xslt");
                raportXslt.Transform(new XmlInput(xmlPath), new XsltArgumentList(), new XmlOutput(wantedPath + "../../Documents/Zadanie5_raport.xml"));
                htmlXsl.Load(wantedPath + "../../Documents/Zadanie5_xhtml.xslt");
                htmlXsl.Transform(new XmlInput(wantedPath + "../../Documents/Zadanie5_raport.xml"), new XsltArgumentList(), new XmlOutput(directoryPath));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Transform error");
                return;
            }
            MessageBox.Show("Saved html", "Ok");
        }

        public static bool ValidateSchema(string xmlPath, string schemaPath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlPath);
            XmlTextReader schemaReader = new XmlTextReader(schemaPath);
            XmlSchema schema = null;
            try
            {
                schema = XmlSchema.Read(schemaReader, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Validation Error");
                return false;
            }

            xml.Schemas.Add(schema);

            try
            {
                xml.Validate(null);
            }
            catch (XmlSchemaValidationException e)
            {
                MessageBox.Show(e.Message, "Validation Error");
                return false;
            }

            MessageBox.Show("Validation with xsd is done", "Ok");
            return true;
        }

    }
}