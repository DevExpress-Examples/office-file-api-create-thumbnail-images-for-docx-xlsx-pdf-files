Imports System
Imports System.Linq

Namespace FilesPreviewGenerator
	Public Class FileInfo
'INSTANT VB NOTE: The variable path was renamed since Visual Basic does not handle local variables named the same as class members well:
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not handle local variables named the same as class members well:
'INSTANT VB NOTE: The variable documentFormat was renamed since Visual Basic does not handle local variables named the same as class members well:
		Public Sub New(ByVal path_Conflict As String, ByVal name_Conflict As String, ByVal documentFormat_Conflict As String)
			Me.Path = path_Conflict
			Me.Name = name_Conflict
			Me.DocumentFormat = documentFormat_Conflict
		End Sub
		Public Property Path() As String
		Public Property Name() As String
		Public Property DocumentFormat() As String
	End Class
End Namespace
