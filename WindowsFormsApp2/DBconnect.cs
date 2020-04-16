using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public class DBconnect
    {
        private const string SERVER= "127.0.0.1";
        private const string DATABASE = "schede_b";
        private const string USER = "root";
        private const string PASSWORD = "andromeda";
       
        private MySqlConnection dbConn;
        
        public DBconnect()
        {
            Initialize();
        }

        public string Database { get ; private set; }

        private void Initialize()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.Database = DATABASE;
            builder.UserID = USER;
            builder.Password = PASSWORD;
            builder.SslMode = MySqlSslMode.None;

            string connString = builder.ToString();

            builder = null;

            dbConn = new MySqlConnection(connString);
            this.Database = DATABASE;
        }

        public bool OpenConnection()
        {
            try
            {
                dbConn.Open();
                return true;
            }

            catch(MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0:
                        MessageBox.Show("non è possibile la connessione "+ex.Message);
                        break;
                    case 1045:
                        MessageBox.Show("Username e Password errati. Riprovare");
                        break;
                    //case 1934:
                      //  break;
                }
                return false;
            }
            catch(System.InvalidOperationException ex)
            {
                MessageBox.Show("errore " + ex.Message);
                return true;
            }
            
        }

        public void Close()
        {
            dbConn.Close();
        }

        public List<Scheda> GetScheda()
        {
            List<Scheda> schede = new List<Scheda>();
            string query = "SELECT * FROM SCHEDA";
            MySqlCommand cmd = new MySqlCommand(query, dbConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string id = reader["id_schede"].ToString();
                string cod = reader["codice_ecr"].ToString();
                string desc = reader["descrizione_ecr"].ToString();
                string logo = reader["logotipo"].ToString();
                string pr_matri = reader["pr_matri"].ToString();
                string se_matri = reader["se_matri"].ToString();
                string data_reg = reader["data_reg"].ToString();
                string assem = reader["assemb"].ToString();
                string qty = reader["qty"].ToString();

                Scheda s = new Scheda(id, cod, desc,logo,pr_matri,se_matri,data_reg,assem,qty);

                schede.Add(s);
            }
            reader.Close();
            return schede;
        }

        public SchedaPdf GetScheda(string cod, string descr,string logo,string ass,string qty)
        {
            string query = "SELECT list_ecr.id_ecr, logotipo.ultima_matricola, logotipo.cifre, logotipo.flag_anno, logotipo.cifra_sottassieme, logotipo.id_logotipo " +
                                "FROM logotipo INNER JOIN list_ecr ON logotipo.id_logotipo = list_ecr.id_logotipo " +
                                "WHERE codice_ecr='" + cod + "' AND status_rec=0";
            MySqlCommand cmd = new MySqlCommand(query, dbConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
                string id_ecr = reader["id_ecr"].ToString();
                string pr_matri = reader["ultima_matricola"].ToString();
                byte cifre = Convert.ToByte(reader["cifre"]);
                string flag_anno = reader["flag_anno"].ToString();
                byte cifra_sottass = Convert.ToByte(reader["cifra_sottassieme"]);
                string id_logo = reader["id_logotipo"].ToString();

                SchedaPdf s = new SchedaPdf(id_ecr, cod, descr, logo, pr_matri, ass, qty, cifre, flag_anno, cifra_sottass, id_logo);

            reader.Close();
            return s;
        }

        public List<Modello> GetModello(string cod)
        {
            List<Modello> modelli = new List<Modello>();
            string query = string.Format("SELECT * FROM MODELLO WHERE status_rec='0' AND codice_ecr LIKE '%{0}%'",cod);
            MySqlCommand cmd = new MySqlCommand(query, dbConn);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["id_ecr"].ToString();
                    string codice = reader["codice_ecr"].ToString();
                    string desc = reader["descrizione_ecr"].ToString();
                    string logo = reader["logotipo"].ToString();
                    string ultimaMatr = reader["ultima_matr"].ToString();
                    Modello m = new Modello(id, codice, desc, logo,ultimaMatr);
                    modelli.Add(m);
                }
                reader.Close();
                return modelli;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Errore, database non connesso. Non è possibile caricare i modelli");
                return null;
            }
            
            catch(MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Errore, la tabella modelli non esiste. Non è possibile caricare i modelli");
                return null;
            }
        }

        public List<Assemblatore> GetAssemblatore()
        {
            List<Assemblatore> assemblatores = new List<Assemblatore>();
            string query = "SELECT * FROM assemblatore";
            MySqlCommand cmd = new MySqlCommand(query, dbConn);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["id_assemb"].ToString();
                    string name = reader["assemb"].ToString();
                    Assemblatore a = new Assemblatore(id, name);
                    assemblatores.Add(a);
                }
                reader.Close();
                return assemblatores;
            }

            catch (InvalidOperationException)
            {
                MessageBox.Show("Errore, database non connesso. Non è possibile caricare l' elenco assemblatori");
                return null;
            }

            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Errore, la tabella assemblatori non esiste. Non è possibile caricare gli assemblatori");
                return null;
            }

        }

        private string GetIdAssemb(string assem)
        {
            string query= "SELECT id_assemb FROM assemblatore WHERE assemb='" + assem + "'";
            string result;

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            result = cmd.ExecuteScalar().ToString();

            return result;
        }

        public void InsertScheda(string id_ecr, string pr_matri, string se_matri, string data_reg, string ass)
        {
            string query_scheda = "INSERT INTO schede (id_ecr, pr_matri, se_matri, data_reg, id_assemb) VALUES (?,?,?,?,?)";
            string id_assem;

            id_assem = GetIdAssemb(ass);

            MySqlCommand cmdi = new MySqlCommand(query_scheda, dbConn);

            cmdi.Parameters.AddWithValue("id_ecr", id_ecr);
            cmdi.Parameters.AddWithValue("pr_matri", pr_matri);
            cmdi.Parameters.AddWithValue("se_matri", se_matri);
            cmdi.Parameters.AddWithValue("data_reg", data_reg);
            cmdi.Parameters.AddWithValue("id_assemb", id_assem);

            cmdi.ExecuteNonQuery();

            //string query_logo="UPDATE logotipo SET logotipo.ultima_matricola=?"
            string query_logo = "UPDATE logotipo INNER JOIN list_ecr ON logotipo.id_logotipo = list_ecr.id_logotipo SET logotipo.ultima_matricola=? WHERE list_ecr.id_ecr=" + id_ecr;

            MySqlCommand cmdu = new MySqlCommand(query_logo, dbConn);

            cmdu.Parameters.AddWithValue("ultima_matricola", se_matri);

            cmdu.ExecuteNonQuery();
        }
    }
}
