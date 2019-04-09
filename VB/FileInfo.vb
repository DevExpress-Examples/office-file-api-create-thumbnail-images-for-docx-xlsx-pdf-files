Imports System
Imports System.Linq

Namespace FilesPreviewGenerator
	Public Class FileInfo
		Public Sub New(ByVal path As String, ByVal name As String, ByVal documentFormat As String)
			Me.Path = path
			Me.Name = name
			Me.DocumentFormat = documentFormat
		End Sub
		Public Property Path() As String
		Public Property Name() As String
		Public Property DocumentFormat() As String
	End Class
End Namespace
