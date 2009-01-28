using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Runner().Generate();
            Console.ReadKey();
        }
    }
}
