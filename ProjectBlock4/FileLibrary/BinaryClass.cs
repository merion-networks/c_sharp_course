using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibrary
{
    public class BinaryClass
    {
        public void ExampleBinaryWrite()
        {
            using (var stream = new BinaryWriter(File.Open("data.bin", FileMode.OpenOrCreate)))
            {
                stream.Write(120);
                stream.Write(3.14);
                stream.Write(true);
            }
        }

        public void ExampleBinaryRead()
        {
            using (var stream = new BinaryReader(File.Open("data.bin", FileMode.Open)))
            {
                int intValue = stream.ReadInt32();
                double doubleValue = stream.ReadDouble();
                bool boolValue = stream.ReadBoolean();

                Console.WriteLine($"{intValue} {doubleValue} {boolValue}");
            }
        }
        public BinaryClass() { }
    }
}
