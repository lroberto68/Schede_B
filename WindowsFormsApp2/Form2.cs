using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        private readonly DBconnect db =new  DBconnect();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Connection();
            lstModelli.View = View.Details;
            LoadAssemblatori();
            
        }

        private void Connection()
        {
            if (db.OpenConnection())
            {
                lblConn.ForeColor = Color.Green;
                lblConn.Text = "Stato database " + db.Database + ": CONNESSO";
            }
            else
            {
                lblConn.ForeColor = Color.Red;
                lblConn.Text = "Stato database: NON CONNESSO";
            }
        }

        private void LoadModelli()
        {
            List<Modello> modelli = db.GetModello(txtModello.Text);
            lstModelli.Items.Clear();
            if (modelli != null)
            {
                foreach (Modello m in modelli)
                {
                    lstModelli.Items.Add(new ListViewItem(new string[] { m.Cod, m.Decr, m.Logo }));
                }
            }
            
        }

        private void LoadAssemblatori()
        {
            List<Assemblatore> assemblatores = db.GetAssemblatore();
            lstAss.Items.Clear();
            if (assemblatores!=null)
            {
                foreach (Assemblatore a in assemblatores)
                {
                    lstAss.Items.Add(a.Name);
                }
            }
        }

        private void BtnRicerca_Click(object sender, EventArgs e)
        {
            LoadModelli();
        }

        private void BtnAggiungi_Click(object sender, EventArgs e)
        {
            string sc;
            uint qty;
            try
            {
                qty = Convert.ToUInt16(txtQty.Text);
                if (lstAss.SelectedItem != null && lstModelli.SelectedItems.Count > 0)
                {
                    Scheda s = new Scheda(lstModelli.SelectedItems[0].SubItems[0].Text, lstModelli.SelectedItems[0].SubItems[1].Text, lstModelli.SelectedItems[0].SubItems[2].Text, lstAss.SelectedItem.ToString(), qty.ToString());
                    
                    lstSchede.Items.Add(new ListViewItem(new string[] { s.Cod, s.Descr, s.Logo, s.Assem, s.Qty,"" }));
                    
                }
                else
                {
                    //TO DO: inserire i messaggi di warning per ASSEMBLATORE e MODELLO
                    sc = "nessun elemento selezionato";
                    MessageBox.Show(sc);
                }
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Inserire una quantità valida");
            }
            catch(OverflowException)
            {
                MessageBox.Show("la quantità inserita non è valida");
            }
           
        }

        private void BtnCrea_Click(object sender, EventArgs e)
        {
            

            foreach(ListViewItem ls in lstSchede.Items)
            {
                SchedaPdf schedaPdf;
                MessageBox.Show(ls.SubItems[0].Text);
                string cod = ls.SubItems[0].Text;
                string desc = ls.SubItems[1].Text;
                string logo = ls.SubItems[2].Text;
                string ass = ls.SubItems[3].Text;
                string qty = ls.SubItems[4].Text;
                

                schedaPdf = db.GetScheda(cod, desc, logo, ass, qty);
                if (schedaPdf.CreaTab())
                {
                    //MessageBox.Show("Schede create e database aggiornato");
                    ls.SubItems[5].Text = "OK";
                    ls.ForeColor = Color.Green;
                }
                else
                {
                    ls.SubItems[5].Text = "KO";
                    ls.ForeColor = Color.Red;
                    MessageBox.Show("Schede non create e database non aggiornato");
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Close();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lstSchede.SelectedItems.Count > 0)
            {
                lstSchede.SelectedItems[0].Remove();
            }
        }
    }
}
