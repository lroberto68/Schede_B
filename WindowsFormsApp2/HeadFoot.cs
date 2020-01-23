using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApp2
{
    public class HeadFoot : PdfPageEventHelper
    {
        public HeadFoot()
        {
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            //base.OnEndPage(writer, document);
            Font font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 13, Font.BOLD);
            font.Size = 13;

            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_LEFT, new Phrase("DITRON Srl", font), 30, 570, 0);
            font.Size = 10;
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, new Phrase("SCHEDA B CONTROLLO PRODUZIONE", font), 400, 570, 0);
            font.Size = 8;
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_RIGHT, new Phrase("P07. 0/A - Rev. 02", font), 800, 570, 0);
            font.Size = 6;
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_LEFT, new Phrase("G=Difetto Grave=Scarto; L=Difetto Lieve=Riparazione immediata; C=Conforme", font), 30, 20, 0);
            font.Size = 7;
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_RIGHT, new Phrase("FIRMA______________", font), 800, 20, 0);
        }
    }
}
