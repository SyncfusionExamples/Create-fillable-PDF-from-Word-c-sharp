using System.IO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

namespace Create_fillable_PDF_from_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            //Open the file as Stream.
            using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/Template.docx"), FileMode.Open))
            {
                //Load an existing Word document.
                using (WordDocument wordDocument = new WordDocument(fileStream, Syncfusion.DocIO.FormatType.Automatic))
                {
                    //Creates an instance of DocIORenderer.
                    using (DocIORenderer renderer = new DocIORenderer())
                    {
                        //Sets true to preserve the Word document form field as editable PDF form field in PDF document.
                        renderer.Settings.PreserveFormFields = true;
                        //Converts Word document into PDF document.
                        using (PdfDocument pdfDocument = renderer.ConvertToPDF(wordDocument))
                        {
                            //Save the PDF document to a file stream.    
                            using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                            {
                                pdfDocument.Save(outputStream);
                            }
                        }
                    }
                }
            }
        }
    }
}
