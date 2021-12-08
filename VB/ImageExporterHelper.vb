Imports DevExpress.Office.Utils
Imports DevExpress.Pdf
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraRichEdit
Imports System.Drawing
Imports System.IO

Namespace FilesPreviewGenerator

    Public Module ImageExporterHelper

        Public Function GenerateImageFromExcel(ByVal fileName As String) As Image
            Using excelDocumentAPI As Workbook = New Workbook()
                excelDocumentAPI.LoadDocument(fileName)
                Dim worksheet = excelDocumentAPI.Worksheets.ActiveWorksheet
                Dim printableCellRange = worksheet.GetPrintableRange()
                Dim docImage As OfficeImage = printableCellRange.ExportToImage()
                Return docImage.NativeImage
            End Using
        End Function

        Public Function GenerateImageFromPDF(ByVal fileName As String, ByVal largestEdgeLength As Integer) As Bitmap
            Using pdfDocumentAPI As PdfDocumentProcessor = New PdfDocumentProcessor()
                pdfDocumentAPI.LoadDocument(fileName)
                Return pdfDocumentAPI.CreateBitmap(1, largestEdgeLength)
            End Using
        End Function

        Public Function GenerateImageFromWord(ByVal fileName As String) As Bitmap
            Using wordDocumentAPI As RichEditDocumentServer = New RichEditDocumentServer()
                wordDocumentAPI.LoadDocument(fileName)
                Return ExportToImage(wordDocumentAPI)
            End Using
        End Function

        Private Function ExportToImage(ByVal component As IBasePrintable) As Bitmap
            Dim pLink As PrintableComponentLinkBase = New PrintableComponentLinkBase(New PrintingSystemBase())
            pLink.Component = component
            pLink.CreateDocument(True)
            Dim mStream As MemoryStream = New MemoryStream()
            Dim options As ImageExportOptions = New ImageExportOptions()
            options.ExportMode = ImageExportMode.SingleFilePageByPage
            options.PageRange = "1"
            pLink.ExportToImage(mStream, options)
            mStream.Position = 0
            Dim bm As Bitmap = New Bitmap(mStream)
            mStream.Close()
            Return bm
        End Function
    End Module
End Namespace
