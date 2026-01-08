Public Class Empleado
    Public Property IdEmpleado As Integer
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Dni As String
    Public Property Password As String
    Public Property Salario As Decimal
    Public Property FechaAlta As Date
    Public Property IdCategoria As Integer

    ' Propiedad calculada
    Public ReadOnly Property NombreCompleto As String
        Get
            Return $"{Nombre} {Apellido}"
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub New(id As Integer, nombre As String, apellido As String, dni As String)
        Me.IdEmpleado = id
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Dni = dni
    End Sub
End Class
