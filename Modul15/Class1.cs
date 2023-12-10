using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul15
{
    internal class Class1
    {
        private int privateField = 42;
        public string publicField = "Public Field";

        public int PublicProperty { get; set; }
        private string PrivateProperty { get; set; }

        private Class1(int value)
        {
            this.PrivateProperty = "Private Property";
            this.PublicProperty = value;
        }

        public Class1()
        {
        }

        public void PublicMethod()
        {
            Console.WriteLine("Public Method");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Private Method");
        }

        public int CalculateSum(int a, int b)
        {
            return a + b;
        }
    }
}
