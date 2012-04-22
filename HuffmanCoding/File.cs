using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HuffmanCoding
{
    public class FileHelper
    {
        static Encoding enc = Encoding.GetEncoding("us-ascii",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());

        public static void WriteBinaryFile(byte[] bytes, string fileName)
        {
            using (var fs = File.Create(@fileName))
            {
                using (var bw = new BinaryWriter(fs, enc))
                {
                    bw.Write(bytes);

                    bw.Close();
                }

                fs.Close();
            }
        }

        public static byte[] GetFileBytes(string fileName)
        {
            byte[] bytes;

            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var br = new BinaryReader(fs, enc))
                {
                    bytes = br.ReadBytes(Convert.ToInt32(fs.Length));

                    br.Close();
                }

                fs.Close();
            }

            return bytes;
        }
    }
}
