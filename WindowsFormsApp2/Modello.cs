using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Modello
    {
        public string Id { get; private set; }
        public string Cod { get; private set; }
        public string Decr { get; private set; }
        public string Logo { get; private set; }
        public string UltMatri { get; private set; }

        public Modello(string id, string cod, string desc, string logo,string ultimaMatr)
        {
            this.Id = id;
            this.Cod = cod;
            this.Decr = desc;
            this.Logo = logo;
            this.UltMatri = ultimaMatr;
            
        }
    }
}
