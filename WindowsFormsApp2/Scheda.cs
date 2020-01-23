using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Scheda
    {
        public string Id { get; private set;}
        public string Cod { get; private set;}
        public string Descr { get; private set;}
        public string Logo { get; private set;}
        public string Pr_matri { get; private set;}
        public string Se_matri { get; private set;}
        public string Data_reg { get; private set; }
        public string Assem { get; private set; }
        public string Qty { get; private set; }

        public Scheda()
        {

        }

        public Scheda(string cod, string descr, string logo, string assem, string qty)
        {
            this.Cod = cod;
            this.Descr = descr;
            this.Logo = logo;
            this.Assem = assem;
            this.Qty = qty;
        }
        
        public Scheda(string id, string cod, string descr, string logo, string pr_matri, string assem, string qty)
            :this(cod,descr,logo,assem,qty)
        {
            this.Id = id;
            this.Pr_matri = pr_matri;
        }

        public Scheda(string id, string cod, string descr, string logo, string pr_matri, string se_matri,string date_reg, string assem, string qty)
            :this(cod,descr,logo,assem,qty)
        {
            this.Id = id;
            this.Pr_matri = pr_matri;
            this.Se_matri = se_matri;
            this.Data_reg = Data_reg;
        }
    }
}
