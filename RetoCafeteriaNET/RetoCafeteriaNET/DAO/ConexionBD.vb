Imports System.Data.SqlClient
Imports System.Data

Public Class ConexionBD
    Private Shared connectionString As String = "Data Source=localhost;Initial Catalog=cafegaupasa;Integrated Security=True"

    ' Método para obtener una nueva conexión
    Public Shared Function ObtenerConexion() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    ' Método para probar la conexión
    Public Shared Function ProbarConexion() As Boolean
        Try
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()
                MessageBox.Show("Conexión exitosa a la base de datos", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End Using
        Catch ex As SqlException
            MessageBox.Show("Error de SQL Server: " & ex.Message & vbCrLf & "Número de error: " & ex.Number,
                          "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message,
                          "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Método para configurar la cadena de conexión manualmente
    Public Shared Sub ConfigurarConexion(servidor As String, baseDatos As String, Optional integratedSecurity As Boolean = True, Optional usuario As String = "", Optional password As String = "")
        If integratedSecurity Then
            ' Autenticación de Windows
            connectionString = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True"
        Else
            ' Autenticación SQL Server
            connectionString = $"Data Source={servidor};Initial Catalog={baseDatos};User ID={usuario};Password={password}"
        End If
    End Sub

    ' Método para obtener la cadena de conexión actual
    Public Shared Function ObtenerCadenaConexion() As String
        Return connectionString
    End Function

    ' Método para ejecutar consultas SELECT y devolver un DataTable
    Public Shared Function EjecutarConsulta(query As String) As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As SqlConnection = ObtenerConexion()
                Using cmd As New SqlCommand(query, conn)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar consulta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function

    ' Método para ejecutar comandos INSERT, UPDATE, DELETE
    Public Shared Function EjecutarComando(query As String) As Integer
        Dim filasAfectadas As Integer = 0

        Try
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    filasAfectadas = cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar comando: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return filasAfectadas
    End Function
End Class