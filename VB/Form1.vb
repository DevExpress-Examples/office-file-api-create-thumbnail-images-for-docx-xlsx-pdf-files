Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms

Namespace FilesPreviewGenerator

    Public Partial Class Form1
        Inherits Form

        Private files As List(Of FileInfo)

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            InitData()
            gridControl1.DataSource = files
            InitViewSettings()
            AddHandler winExplorerView1.GetThumbnailImage, AddressOf WinExplorerView_GetThumbnailImage
        End Sub

        Private Sub InitData()
            files = New List(Of FileInfo)()
            Dim fileNames As String() = Directory.GetFiles("Documents\")
            For Each item As String In fileNames
                files.Add(New FileInfo(item, Path.GetFileName(item), Path.GetExtension(item)))
            Next
        End Sub

        Private Sub InitViewSettings()
            winExplorerView1.OptionsImageLoad.CacheThumbnails = True
            winExplorerView1.OptionsImageLoad.LoadThumbnailImagesFromDataSource = False
            winExplorerView1.OptionsImageLoad.AsyncLoad = True
            winExplorerView1.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.ExtraLarge
        End Sub

        Private Sub WinExplorerView_GetThumbnailImage(ByVal sender As Object, ByVal e As DevExpress.Utils.ThumbnailImageEventArgs)
            Dim filePath As String = files(e.DataSourceIndex).Path
            Dim documentFormat As String = files(e.DataSourceIndex).DocumentFormat
            Select Case documentFormat
                Case ".pdf"
                    Dim largestEdgeLength As Integer = Math.Max(e.DesiredThumbnailSize.Width, e.DesiredThumbnailSize.Height)
                    e.ThumbnailImage = GenerateImageFromPDF(filePath, largestEdgeLength)
                Case ".xlsx"
                    e.ThumbnailImage = GenerateImageFromExcel(filePath)
                Case ".docx"
                    e.ThumbnailImage = GenerateImageFromWord(filePath)
            End Select
        End Sub
    End Class
End Namespace
