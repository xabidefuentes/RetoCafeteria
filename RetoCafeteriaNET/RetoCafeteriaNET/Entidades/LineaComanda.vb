Public Class LineaComanda
    Public Property IdLineaComanda As Integer
    Public Property Cantidad As Integer
    Public Property Precio As Decimal
    Public Property IdComanda As Integer
    Public Property IdProducto As Integer

    ' Propiedades adicionales para la vista
    Public Property NombreProducto As String
    Public Property Descuento As Decimal

    Public Sub New(cantidad As Integer, precio As Decimal, idProducto As Integer, nombreProducto As String)
        Me.Cantidad = cantidad
        Me.Precio = precio
        Me.IdProducto = idProducto
        Me.NombreProducto = nombreProducto
        Me.Descuento = 0
    End Sub

    Public Sub New()
        Me.Descuento = 0
    End Sub
End Class