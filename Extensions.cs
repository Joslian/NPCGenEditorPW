using System;
using System.IO;
using System.Text;

namespace NPCGenToXml
{
    public static class Extensions
    {
        public static string ReadTaskChar(this BinaryReader br, uint length, bool x2 = true)
        {
            byte[] data = x2 ? br.ReadBytes((int)length * 2) : br.ReadBytes((int)length);
            return Encoding.GetEncoding("GBK").GetString(data);
        }

        public static void WriteTaskChar(this BinaryWriter bw, string data, uint length, bool x2 = true)
        {
            byte[] source = Encoding.GetEncoding("GBK").GetBytes(data);
            byte[] target = x2 ? new byte[(int)length * 2] : new byte[(int)length];
            if (target.Length > source.Length)
                Array.Copy(source, target, source.Length);
            else
                Array.Copy(source, target, target.Length);
            bw.Write(target);
        }
    }
}