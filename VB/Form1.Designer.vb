Namespace FilesPreviewGenerator
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.winExplorerView1 = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
			Me.colFileName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colImage = New DevExpress.XtraGrid.Columns.GridColumn()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.winExplorerView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.winExplorerView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(915, 405)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.winExplorerView1})
			' 
			' winExplorerView1
			' 
			Me.winExplorerView1.Appearance.ItemNormal.Font = New System.Drawing.Font("Segoe UI", 7F)
			Me.winExplorerView1.Appearance.ItemNormal.Options.UseFont = True
			Me.winExplorerView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colFileName, Me.colImage})
			Me.winExplorerView1.ColumnSet.ExtraLargeImageColumn = Me.colImage
			Me.winExplorerView1.ColumnSet.TextColumn = Me.colFileName
			Me.winExplorerView1.GridControl = Me.gridControl1
			Me.winExplorerView1.Name = "winExplorerView1"
			' 
			' colFileName
			' 
			Me.colFileName.FieldName = "Name"
			Me.colFileName.MinWidth = 60
			Me.colFileName.Name = "colFileName"
			Me.colFileName.Visible = True
			Me.colFileName.VisibleIndex = 0
			Me.colFileName.Width = 150
			' 
			' colImage
			' 
			Me.colImage.Name = "colImage"
			Me.colImage.Width = 150
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(915, 405)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.winExplorerView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private winExplorerView1 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
		Private colFileName As DevExpress.XtraGrid.Columns.GridColumn
		Private colImage As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace

