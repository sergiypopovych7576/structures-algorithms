using System;
using System.Collections.Generic;

namespace SearchAlgorithms
{
    internal class Program
    {
        public static List<string> Sample = new List<string>()
        {
            "First",
            "Second",
            "Third"
        };

        static void Main(string[] args)
        {
            var res = Sample.LinearSearch(item => item == "Second");
        }
    }
}
