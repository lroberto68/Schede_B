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
        //public string Pr_matri { get; private set; }

        public Modello(string id, string cod, string desc, string logo)
        {
            this.Id = id;
            this.Cod = cod;
            this.Decr = desc;
            this.Logo = logo;
            //this.Pr_matri = pr_matri;
        }
    }
}
