using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationAPI
{
    public class Tuto
    {
        public string title { set; get; }

        public int price { set; get; }

        public string image { set; get; }

        public string description { set; get; }

        public override string ToString()
        {
            return title + " | " + price;
        }

    }
}
