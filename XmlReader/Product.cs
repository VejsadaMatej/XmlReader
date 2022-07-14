using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlReader
{
    internal class Product
    {
        public string Ean { get; set; }

        public Product(string ean)
        {
            Ean = ean;
        }

        public override string ToString()
        {
            return Ean;
        }
    }
}
