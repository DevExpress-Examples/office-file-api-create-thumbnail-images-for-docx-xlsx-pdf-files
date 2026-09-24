Imports DevExpress.Office.Utils
Imports DevExpress.Pdf
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Export.Image
Imports System.Drawing

Namespace FilesPreviewGenerator

    Public Module ImageExporterHelper

        Public Function GenerateImageFromExcel(ByVal fileName As String) As Image
            Using excelDocumentAPI As Workbook = New Workbook()
                excelDocumentAPI.LoadDocument(fileName)
                Dim worksheet = excelDocumentAPI.Worksheets.ActiveWorksheet
                Dim docImage As OfficeImage = worksheet.CreateThumbnail(1600, 900)
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
                Dim options As RichEditImageExportOptions = New RichEditImageExportOptions()
                options.ExportMode = RichEditImageExportMode.SingleFilePageByPage
                options.PageRange = "1"
                Dim streamList = wordDocumentAPI.Document.ExportToImage(options)
                Dim bm As Bitmap = New Bitmap(streamList(0))
                streamList(0).Close()
                Return bm
            End Using
        End Function
    End Module
End Namespace
