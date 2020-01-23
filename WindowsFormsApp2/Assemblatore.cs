using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Assemblatore
    {
        public string  Id { get; private set; }
        public string  Name { get; private set; }

        public  Assemblatore (string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
