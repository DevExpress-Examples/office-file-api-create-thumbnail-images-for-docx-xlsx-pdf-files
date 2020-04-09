using DevExpress.Pdf;
using DevExpress.Spreadsheet;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace FilesPreviewGenerator
{
    public static class ImageExporterHelper
    {
        public static Bitmap GenerateImageFromExcel(string fileName)
        {
            using (Workbook excelDocumentAPI = new Workbook())
            {
                excelDocumentAPI.LoadDocument(fileName);
                return ExportToImage(excelDocumentAPI);
            }
        }

        public static Bitmap GenerateImageFromPDF(string fileName, int largestEdgeLength)
        {
            using (PdfDocumentProcessor pdfDocumentAPI = new PdfDocumentProcessor())
            {
                pdfDocumentAPI.LoadDocument(fileName);
                return pdfDocumentAPI.CreateBitmap(1, largestEdgeLength);
            }
        }
        public static Bitmap GenerateImageFromWord(string fileName)
        {
            using (RichEditDocumentServer wordDocumentAPI = new RichEditDocumentServer())
            {
                wordDocumentAPI.LoadDocument(fileName);
                return ExportToImage(wordDocumentAPI);
            }
        }
        private static Bitmap ExportToImage(IBasePrintable component)
        {
            PrintableComponentLink pLink = new PrintableComponentLink(new PrintingSystem());
            pLink.Component = component;
            pLink.CreateDocument(true);

            MemoryStream mStream = new MemoryStream();
            ImageExportOptions options = new ImageExportOptions();
            options.ExportMode = ImageExportMode.SingleFilePageByPage;
            options.PageRange = "1";
            pLink.ExportToImage(mStream, options);
            mStream.Position = 0;
            Bitmap bm = new Bitmap(mStream);
            mStream.Close();

            return bm;
        }
    }
}
