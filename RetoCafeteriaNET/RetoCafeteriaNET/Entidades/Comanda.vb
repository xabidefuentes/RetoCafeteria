Public Class Comanda
    Public Property IdComanda As Integer
    Public Property Fecha As Date
    Public Property Hora As TimeSpan
    Public Property Total As Decimal
    Public Property IdEmpleado As Integer

    ' Lista de líneas de la comanda
    Public Property Lineas As New List(Of LineaComanda)

    Public Sub New()
        Me.Fecha = Date.Today
        Me.Hora = TimeSpan.FromTicks(DateTime.Now.TimeOfDay.Ticks)
        Me.Total = 0
    End Sub
End Class
