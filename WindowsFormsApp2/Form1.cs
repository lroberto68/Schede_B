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
    public partial class Form1 : Form
    {
        DBconnect db = new DBconnect();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Connection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connection();
            listView1.View = View.Details;
        }
        
        private void Connection()
        {
            if (db.OpenConnection())
            {
                label1.ForeColor = Color.Green;
                label1.Text = "Stato database: CONNESSO";
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Stato database: NON CONNESSO";
            }
        }

        private void LoadSchede()
        {
            List<Scheda> schede = db.GetScheda();

            listView1.Items.Clear();

            foreach(Scheda s in schede)
            {
                listView1.Items.Add(new ListViewItem(new string[] { s.Id, s.Cod, s.Descr,s.Logo,s.Pr_matri,s.Se_matri,s.Data_reg,s.Assem,s.Qty }));
            }

            //MessageBox.Show(listView1.Items.Count.ToString());
            label3.Text = listView1.Items.Count.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //listView1.Items.Add(new ListViewItem(new string[] { "ciao", "roberto", "maurizio", "sandy" }));
            //List<Scheda> schede = db.GetScheda();
            LoadSchede();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                String s = string.Format("selezionato {0}", listView1.SelectedItems[0].SubItems[1].Text);
                MessageBox.Show(s);
            }
        }
    }
}
