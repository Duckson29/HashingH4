using ConsoleApp1.Hashing;
using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHMAC mAC = new MyHMAC();

            Console.WriteLine("1: md5\n2: sha1\n3: sha256\n4: sha512");

            int data = 0;
            int.TryParse(Console.ReadLine(),out data);
            mAC.HashToUse(data);

            Console.WriteLine("Hashing of pwd");
            Console.WriteLine("Input keyString to use in hmac");
            byte[] keyString = Encoding.UTF8.GetBytes(Console.ReadLine());            
            Console.WriteLine("Input password.");
            byte[] passwordByte = Encoding.UTF8.GetBytes(Console.ReadLine());
            byte[] output = mAC.HashBytes(passwordByte, keyString);
            Console.WriteLine($"ASCII: {Convert.ToBase64String(output)}\n HEX: {Encoding.UTF8.GetChars(output)[2]}");
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
