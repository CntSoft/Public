using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VanChi.Utility
{
    public class XmlUtility
    {
        public static string Serialize<T>(T value)
        {
            string m_Xml = string.Empty;

            XmlSerializer m_XmlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream m_MemoryStream = new MemoryStream())
            {
                m_XmlSerializer.Serialize(m_MemoryStream, value);
                m_MemoryStream.Seek(0, SeekOrigin.Begin);
                using (StreamReader m_StreamReader = new StreamReader(m_MemoryStream))
                {
                    m_Xml = m_StreamReader.ReadToEnd();
                }
            }

            return m_Xml;
        }
        public static T DeSerialize<T>(string xml)
        {
            T m_Value = default(T);

            if (!string.IsNullOrEmpty(xml))
            {
                XmlSerializer m_XmlSerializer = new XmlSerializer(typeof(T));
                using (StringReader m_StringReader = new StringReader(xml))
                {
                    m_Value = (T)m_XmlSerializer.Deserialize(m_StringReader);
                }
            }

            return m_Value;
        }
        public static string Serialize<T>(T value, Type[] types)
        {
            string m_Xml = string.Empty;

            XmlSerializer m_XmlSerializer = new XmlSerializer(typeof(T), types);
            using (MemoryStream m_MemoryStream = new MemoryStream())
            {
                m_XmlSerializer.Serialize(m_MemoryStream, value);
                m_MemoryStream.Seek(0, SeekOrigin.Begin);
                using (StreamReader m_StreamReader = new StreamReader(m_MemoryStream))
                {
                    m_Xml = m_StreamReader.ReadToEnd();
                }
            }

            return m_Xml;
        }
    }
}
