using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;

using System.Xml;
using System.Xml.Serialization;

namespace XlightsACNBridge.Shared
{
    public static class Serializer
    {
       static  Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings() { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii };

        /// <summary>
        ///     Serialize any class object to Json string.
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="t">Object</param>
        /// <returns>Json string</returns>
        public static string JsonSerialize<T>(T t)
        {
          
            return JsonConvert.SerializeObject(t, settings);
            //string jsonString;

            //using (var stream = new MemoryStream())
            //{
            //    var serializer = new DataContractJsonSerializer(typeof(T));

            //    serializer.WriteObject(stream, t);
            //    stream.Position = 0;
            //    using (var reader = new StreamReader(stream))
            //    {
            //        jsonString = reader.ReadToEnd();
            //    }
            //}

            //return jsonString;
        }

        /// <summary>
        ///     Serialize any class object to Json string.
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="t">Object</param>
        /// <returns>Json string</returns>
        public static string Json<T>(T t)
        {
            return JsonConvert.SerializeObject(t, settings);
            //var json = new JavaScriptSerializer().Serialize(t);
            //return json;
        }

        /// <summary>
        ///     Deserialize Json string to any class object.
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="jsonString">Json string</param>
        /// <returns>Class object</returns>
        public static T JsonDeserialize<T>(string jsonString)
        {
             
                return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }

		/// <summary>
        ///     Deserialize XML to any class object.
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="xml">Xml string</param>
        /// <returns>Class object</returns>
        public static T XmlDeserialize<T>(string xml)
        {
            T t;

            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(xml)))
            {
                var serializer = new DataContractSerializer(typeof(T));
                t = (T)serializer.ReadObject(stream);
            }

            return t;
        }

        /// <summary>
        ///     Serialize any class object to Xml.
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="data">Class object</param>
        /// <returns>Xml string</returns>
        public static string XmlSerialize<T>(T data)
        {
            string content;

            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(stream, data);
                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }

            return content;
        }
        /// <summary>
        /// Read stream and returns byte[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] ReadStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static string SerializeXml<T>(T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringwriter = new StringWriter())
            {
                serializer.Serialize(stringwriter, data);
                var result = stringwriter.ToString();

                return result;
            }
        }

        public static string SerializePlainXml<T>(T data)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stringwriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stringwriter, settings))
                {
                    serializer.Serialize(writer, data, emptyNamepsaces);
                    var result = stringwriter.ToString();

                    return result;
                }
            }
        }

        public static T DeserializeXml<T>(string xml,params System.Type[] extraTypes  )
        {
            var serializer = new XmlSerializer(typeof(T),extraTypes);
            using (var stringReader = new StringReader(xml))
            {
                var t = (T)serializer.Deserialize(stringReader);

                return t;
            }
        }

        public static byte[] ToBinary<T>(T data)
        {
            byte[] output = null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Position = 0;
                bf.Serialize(ms, data);
                output = ms.GetBuffer();
            }

            return output;
        }

        public static T FromBinary<T>(byte[] data)
        {
            byte[] buffer = data;
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                ms.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();
                return (T)bf.Deserialize(ms);
            }
        }
    }
}
