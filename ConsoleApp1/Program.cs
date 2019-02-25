using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = ObjectRandomizer.Randomizer.GenerateRandom<MyType>();
        }
    }
    public class MyType
        {
        public string str { get; set; }

        public int i { get; set; }

        public Guid testId { get; set; }
        public SubType st { get; set; }
        
        }
    public class SubType
    {
        public long l { get; set; }
        public short s { get; set; }
        public string str { get; set; }
        public Guid guid { get; set; }
        public double d { get; set; }
        public decimal de { get; set; }
    }
}
