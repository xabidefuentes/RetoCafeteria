Imports System.Data.SqlClient
Imports System.Data

Public Class ConexionBD

    Private Shared connectionString As String =
    "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cafegaupasa;Integrated Security=True"

    Public Shared Function ObtenerConexion() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    Public Shared Function ProbarConexion() As Boolean
        Try
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()
                MessageBox.Show("Conexión exitosa a la base de datos", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End Using
        Catch ex As SqlException
            MessageBox.Show("Error de SQL Server: " & ex.Message,
                            "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
