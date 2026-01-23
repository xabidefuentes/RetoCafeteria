Imports System.Data.SqlClient
Imports System.Data
Public Class CategoriaDAO

    ' Obtener todas las categorías
    Public Shared Function ObtenerTodas() As List(Of Categoria)
        Dim categorias As New List(Of Categoria)

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idCategoria, nombre FROM CATEGORIA ORDER BY nombre"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            categorias.Add(New Categoria With {
                                .IdCategoria = Convert.ToInt32(reader("idCategoria")),
                                .Nombre = reader("nombre").ToString()
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return categorias
    End Function

    ' Obtener categorías de productos
    Public Shared Function ObtenerCategoriasProductos() As List(Of Categoria)
        Dim categorias As New List(Of Categoria)

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idCategoria, nombre FROM CATEGORIA WHERE idCategoria >= 5 ORDER BY nombre"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            categorias.Add(New Categoria With {
                                .IdCategoria = Convert.ToInt32(reader("idCategoria")),
                                .Nombre = reader("nombre").ToString()
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener categorías de productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return categorias
    End Function

    ' Obtener categorías de empleados
    Public Shared Function ObtenerCategoriasEmpleados() As List(Of Categoria)
        Dim categorias As New List(Of Categoria)

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idCategoria, nombre FROM CATEGORIA WHERE idCategoria <= 4 ORDER BY nombre"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            categorias.Add(New Categoria With {
                                .IdCategoria = Convert.ToInt32(reader("idCategoria")),
                                .Nombre = reader("nombre").ToString()
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener categorías de empleados: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return categorias
    End Function

    ' Obtener categoría por ID
    Public Shared Function ObtenerPorId(idCategoria As Integer) As Categoria
        Dim categoria As Categoria = Nothing

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idCategoria, nombre FROM CATEGORIA WHERE idCategoria = @idCategoria"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            categoria = New Categoria With {
                                .idCategoria = Convert.ToInt32(reader("idCategoria")),
                                .Nombre = reader("nombre").ToString()
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener categoría: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return categoria
    End Function

    ' Obtener categorías usando DataAdapter y DataSet
    Public Shared Function ObtenerTodasConDataSet() As DataSet
        Dim ds As New DataSet()

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                Dim query As String = "SELECT idCategoria, nombre FROM CATEGORIA ORDER BY nombre"

                Using adapter As New SqlDataAdapter(query, conn)
                    adapter.Fill(ds, "Categorias")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ds
    End Function

    ' Insertar nueva categoría
    Public Shared Function Insertar(categoria As Categoria) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "INSERT INTO CATEGORIA (nombre) VALUES (@nombre)"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al insertar categoría: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Actualizar categoría
    Public Shared Function Actualizar(categoria As Categoria) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "UPDATE CATEGORIA SET nombre = @nombre WHERE idCategoria = @idCategoria"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre)
                    cmd.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar categoría: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Eliminar categoría
    Public Shared Function Eliminar(idCategoria As Integer) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "DELETE FROM CATEGORIA WHERE idCategoria = @idCategoria"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al eliminar categoría: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class