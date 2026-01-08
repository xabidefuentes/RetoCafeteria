Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Data.MySqlConnection

' =============================================
' Clase: ConexionBD
' Gestiona la conexión a la base de datos MySQL
' =============================================
Public Class ConexionBD
    ' Cadena de conexión - MODIFICA SEGÚN TU CONFIGURACIÓN
    Private Shared connectionString As String = "Server=localhost;Database=CafeGaupasa;Uid=root;Pwd=;Port=3306;"

    ' Método para obtener una nueva conexión
    Public Shared Function ObtenerConexion() As MySqlConnection
        Return New SqlConnection(connectionString)
    End Function

    ' Método para probar la conexión
    Public Shared Function ProbarConexion() As Boolean
        Try
            Using conn As MySqlConnection = ObtenerConexion()
                conn.Open()
                Return True
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error de MySQL: " & ex.Message & vbCrLf & "Código de error: " & ex.Number,
                          "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message,
                          "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Método para configurar la cadena de conexión manualmente
    Public Shared Sub ConfigurarConexion(servidor As String, baseDatos As String, usuario As String, password As String, Optional puerto As Integer = 3306)
        connectionString = $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={password};Port={puerto};"
    End Sub

    ' Método para obtener la cadena de conexión actual
    Public Shared Function ObtenerCadenaConexion() As String
        Return connectionString
    End Function
End Class