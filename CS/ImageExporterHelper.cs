using DevExpress.Office.Utils;
using DevExpress.Pdf;
using DevExpress.Spreadsheet;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Export.Image;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace FilesPreviewGenerator
{
    public static class ImageExporterHelper
    {
        public static Image GenerateImageFromExcel(string fileName)
        {
            using (Workbook excelDocumentAPI = new Workbook())
            {
                excelDocumentAPI.LoadDocument(fileName);
                var worksheet = excelDocumentAPI.Worksheets.ActiveWorksheet;

                OfficeImage docImage = worksheet.CreateThumbnail(1600, 900);
                return docImage.NativeImage;
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
                RichEditImageExportOptions options = new RichEditImageExportOptions();
                options.ExportMode = RichEditImageExportMode.SingleFilePageByPage;
                options.PageRange = "1";

                var streamList = wordDocumentAPI.Document.ExportToImage(options);

                Bitmap bm = new Bitmap(streamList[0]);
                streamList[0].Close();

                return bm;


            }
        }
    }
}
