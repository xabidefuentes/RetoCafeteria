Public Class Categoria
    Public Property IdCategoria As Integer
    Public Property Nombre As String

    Public Sub New()
    End Sub

    Public Sub New(id As Integer, nombre As String)
        Me.IdCategoria = id
        Me.Nombre = nombre
    End Sub
End Class
