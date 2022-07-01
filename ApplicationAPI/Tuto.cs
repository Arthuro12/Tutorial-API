using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationAPI
{
    public class Tuto
    {
        public string title { get; set; }

        public int price { get; set; }

        public string image { get; set; }

        public string description { get; set; }

        public override string ToString()
        {
            return title + " | " + price;
        }

    }
}
