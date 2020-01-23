using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApp2
{
    public class SchedaPdf : Scheda
    {
        private const string PATH_W = @"c:\temp\schede\";
        //private const string PATH_W = @"/home/roberto/Temp/schede/";
        private struct Layout
        {
            public byte fontSize;
            public byte colSpan;
            public byte rowSpan;
            public byte horAlignment;
            public byte verAlignment;
            public byte rotation;
            public string message;
        }

        private Document doc1 = new Document(PageSize.A4.Rotate());

        private byte Cifre { get;  set; }
        private string Flag_anno { get; set; }
        private byte Cifre_sottassiame { get; set; }
        private string Id_logo { get; set; }       

        public SchedaPdf(string id, string cod, string descr, string logo, string pr_matri, string assem, string qty,byte cifre,string flag_anno, byte cifre_sottassieme, string id_logo)
            :base(id,cod,descr,logo,pr_matri,assem,qty)
        {
            this.Cifre = cifre;
            this.Flag_anno = flag_anno;
            this.Cifre_sottassiame = cifre_sottassieme;
            this.Id_logo = id_logo;
            
        }

        private List<Layout> GeneraLayout(string codArt, string descrizione, string assemblatore)
        {
            List<Layout> layouts = new List<Layout>();

            layouts.Add(new Layout() { fontSize = 9, colSpan = 2, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = "MODELLO" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 0, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = descrizione });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = "CODICE" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 6, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = codArt });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 6, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = "ASSEMBLATORE" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 6, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = assemblatore });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 0, message = "DATA" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 4, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = "" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 0, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = "N°" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 0, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = "MATRICOLA INDUSTRIALE" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 0, rowSpan = 0, horAlignment = 0, verAlignment = 0, rotation = 0, message = "MATRICOLA FISCALE" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "CONTROLLO \n MATERIALI" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "CONTROLLO \n ASSEMBLAGGIO" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "CONTROLLO \n ISPETTIVO \n INTERNO" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "CONFORMITA' \n ASPETTO \n ESTETICO" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "ACCENSIONE E \n COLLAUDO \n FUNZIONALE" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "RUN-IN" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "CONTROLLO \n FINE RUN-IN" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "VERIFICA \n ACCESSORI" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 3, rowSpan = 1, horAlignment = 0, verAlignment = 0, rotation = 90, message = "IMBALLO" });
            layouts.Add(new Layout() { fontSize = 9, colSpan = 0, rowSpan = 1, horAlignment = 1, verAlignment = 0, rotation = 0, message = "NOTE" });

            return layouts;
        }

        public bool CreaTab()
        {
            const short col = 31;
            int qty = Convert.ToInt32(Qty);
            int pr_matri = Convert.ToInt32(Pr_matri)+1;
            int se_matri = pr_matri +qty - 1;

            DBconnect db = new DBconnect();

            string path_w2 = Creadir(PATH_W, Assem) + "\\" + Cod + "_" + Qty + "_Pz.pdf";
            try
            {

                FileStream fileStream = new FileStream(path_w2, FileMode.Create, FileAccess.Write);
                PdfWriter writer = PdfWriter.GetInstance(doc1, fileStream);
                PdfPTable table = new PdfPTable(col);
                table.TotalWidth = 775;
                table.LockedWidth = true;
                float[] widths = new float[] { 20f, 95f, 100f, 15f, 15f, 15f, 16f, 16f, 16f, 16f, 16f, 16f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 122f };
                List<Layout> layouts = new List<Layout>();
                table.SetWidths(widths);
                PdfPCell cell;


                Font font = FontFactory.GetFont(FontFactory.TIMES_ROMAN);

                layouts = GeneraLayout(Cod, Descr, Assem);



                foreach (Layout items in layouts)
                {
                    Font font2 = FontFactory.GetFont(FontFactory.TIMES_ROMAN);
                    font2.Size = items.fontSize;
                    cell = new PdfPCell(new Paragraph(items.message, font2));
                    cell.Colspan = items.colSpan;
                    cell.Rowspan = items.rowSpan;
                    cell.Rotation = items.rotation;
                    cell.HorizontalAlignment = items.horAlignment;
                    cell.VerticalAlignment = items.verAlignment;
                    table.AddCell(cell);
                }


                font.Size = 10;
                ushort k = 0;
                for (int i = pr_matri; i <= se_matri; i++)
                {
                    k++;
                    cell = new PdfPCell(new Paragraph(k.ToString(), font));
                    //cell.Colspan = 31;
                    cell.Rowspan = 2;
                    table.AddCell(cell);


                    cell = new PdfPCell(new Paragraph("", font));
                    cell.Rowspan = 2;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(Logotipo() + " " + i.ToString("d" + Cifre), font));
                    cell.Rowspan = 2;
                    table.AddCell(cell);

                    for (ushort j = 1; j <= 9; j++)
                    {
                        cell = new PdfPCell(new Paragraph("G", font));
                        table.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("L", font));
                        table.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("C", font));
                        table.AddCell(cell);
                    }

                    cell = new PdfPCell(new Paragraph("", font));

                    cell.Rowspan = 2;
                    table.AddCell(cell);


                    for (ushort j = 1; j <= 9; j++)
                    {
                        cell = new PdfPCell(new Paragraph(" ", font));
                        cell.Colspan = 3;
                        table.AddCell(cell);
                    }

                }

                table.HeaderRows = 2;

                doc1.Open();
                writer.PageEvent = new HeadFoot();
                doc1.Add(table);
                doc1.Close();

                if (db.OpenConnection())
                {
                    db.InsertScheda(Id, pr_matri.ToString(), se_matri.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), Assem);
                    db.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Attenzione database non aggiornato");
                    return false;
                }
                
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show("Errore di percorso {0}", e.Message);
                
                return false;
            }
        }
        private string Creadir(string path, string assemblatore)
        {
            string dt = DateTime.Now.ToString("ddMMyy");
            string pathd = path + assemblatore + "_" + dt;
            try
            {
                if (!Directory.Exists(pathd))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathd);
                }
                return pathd;
            }
            catch (Exception e)
            {
                MessageBox.Show("errore di percorso, impossibile creare la directory {0}", e.Message);
                
                return path;
            }
            finally
            {

            }
        }

        private string Logotipo()
        {
            string dt = DateTime.Now.ToString("ddMMyy");
            string logo;
            logo = (Flag_anno == "0") ? Logo : Logo + dt.Substring(4);
            return logo;
        }
    }
}
