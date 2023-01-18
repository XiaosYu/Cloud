using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Office.Pdf
{
    public class PdfGraphics
    {
        public PdfGraphics() 
        {
            Document = new PdfDocument();
            CurrentPage = Document.Pages.Add();
        }

        public PdfGraphics(string filename)
        {
            Document = new PdfDocument(filename);
            CurrentPage = Document.Pages.Count > 0 ? Document.Pages[0]: Document.Pages.Add();
        }
        private PdfDocument Document { set; get; }
        private PdfPageBase CurrentPage { set; get; }

        public void AddPage()
        {
            CurrentPage = Document.Pages.Add();
        }

        public void ChangeCurrentPage(int index)
        {
            CurrentPage = Document.Pages[index];
        }

        public void RemovePage(int index) 
        {
            Document.Pages.RemoveAt(index);
        }

        

    }
}
