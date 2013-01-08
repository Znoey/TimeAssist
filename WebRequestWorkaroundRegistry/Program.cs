
using System.IO;
namespace WebRequestWorkaroundRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = File.OpenRead("ioException.reg");
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("ioException.bin.reg"));
            byte[] bytes = new byte [stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            bw.Write(bytes);
            stream.Close();
            bw.Close();
        }
    }
}
