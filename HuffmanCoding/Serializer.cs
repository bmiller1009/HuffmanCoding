using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HuffmanCoding
{
    internal class Serializer
    {
        /// <summary>
        /// Method to convert a custom Object to XML string
        /// </summary>
        /// <param name="pObject">Object that is to be serialized to XML</param>
        /// <returns>XML string</returns>
        internal static void SaveAsBinaryFile<T>(string filePath, T pObject) 
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var bf = new BinaryFormatter();

                    bf.Serialize(memoryStream, pObject);

                    string path = Path.GetDirectoryName(filePath);

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    File.WriteAllBytes(filePath, memoryStream.ToArray());

                    memoryStream.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Method to reconstruct an Object from XML string
        /// </summary>
        /// <param name="pXmlizedString"></param>
        /// <returns></returns>
        internal static T DeserializeBinaryFile<T>(string filePath)
        {
            var bf = new BinaryFormatter();

            using (var memoryStream = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                return (T)bf.Deserialize(memoryStream);
            }           
        }
    }
}
