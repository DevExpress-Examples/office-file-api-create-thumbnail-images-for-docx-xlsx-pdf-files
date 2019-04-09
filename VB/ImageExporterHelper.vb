Imports DevExpress.Pdf
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraRichEdit
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Linq

Namespace FilesPreviewGenerator
	Public Module ImageExporterHelper
		Public Function GenerateImageFromExcel(ByVal fileName As String) As Bitmap
			Using excelDocumentAPI As New Workbook()
				excelDocumentAPI.LoadDocument(fileName)
				Return ExportToImage(excelDocumentAPI)
			End Using
		End Function

		Public Function GenerateImageFromPDF(ByVal fileName As String, ByVal largestEdgeLength As Integer) As Bitmap
			Using pdfDocumentAPI As New PdfDocumentProcessor()
				pdfDocumentAPI.LoadDocument(fileName)
				Return pdfDocumentAPI.CreateBitmap(1, largestEdgeLength)
			End Using
		End Function
		Public Function GenerateImageFromWord(ByVal fileName As String) As Bitmap
			Using wordDocumentAPI As New RichEditDocumentServer()
				wordDocumentAPI.LoadDocument(fileName)
				Return ExportToImage(wordDocumentAPI)
			End Using
		End Function
		Private Function ExportToImage(ByVal component As IPrintable) As Bitmap
			Dim pLink As New PrintableComponentLink(New PrintingSystem())
			pLink.Component = component
			pLink.CreateDocument(True)

			Dim mStream As New MemoryStream()
			Dim options As New ImageExportOptions()
			options.ExportMode = ImageExportMode.SingleFilePageByPage
			options.PageRange = "1"
			pLink.ExportToImage(mStream, options)
			mStream.Position = 0
			Dim bm As New Bitmap(mStream)
			mStream.Close()

			Return bm
		End Function
	End Module
End Namespace
