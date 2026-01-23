Public Class Producto
    Public Property IdProducto As Integer
    Public Property Nombre As String
    Public Property Precio As Decimal
    Public Property Stock As Integer
    Public Property IdCategoria As Integer

    Public Sub New()
    End Sub

    Public Sub New(id As Integer, nombre As String, precio As Decimal, stock As Integer)
        Me.IdProducto = id
        Me.Nombre = nombre
        Me.Precio = precio
        Me.Stock = stock
    End Sub
End Class
