Imports System.Data.SqlClient
Imports System.Data

' =============================================
' Clase: ProductoDAO
' Acceso a datos de Productos usando ADO.NET
' =============================================
Public Class ProductoDAO

    ' Obtener todos los productos
    Public Shared Function ObtenerTodos() As List(Of Producto)
        Dim productos As New List(Of Producto)

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idProducto, nombre, precio, stock, idCategoria FROM PRODUCTOS ORDER BY nombre"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            productos.Add(New Producto With {
                                .IdProducto = Convert.ToInt32(reader("idProducto")),
                                .Nombre = reader("nombre").ToString(),
                                .Precio = Convert.ToDecimal(reader("precio")),
                                .Stock = Convert.ToInt32(reader("stock")),
                                .IdCategoria = Convert.ToInt32(reader("idCategoria"))
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return productos
    End Function

    ' Obtener productos por categoría
    Public Shared Function ObtenerPorCategoria(idCategoria As Integer) As List(Of Producto)
        Dim productos As New List(Of Producto)

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idProducto, nombre, precio, stock, idCategoria FROM PRODUCTOS WHERE idCategoria = @idCategoria ORDER BY nombre"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            productos.Add(New Producto With {
                                .IdProducto = Convert.ToInt32(reader("idProducto")),
                                .Nombre = reader("nombre").ToString(),
                                .Precio = Convert.ToDecimal(reader("precio")),
                                .Stock = Convert.ToInt32(reader("stock")),
                                .IdCategoria = Convert.ToInt32(reader("idCategoria"))
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener productos por categoría: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return productos
    End Function

    ' Obtener producto por ID
    Public Shared Function ObtenerPorId(idProducto As Integer) As Producto
        Dim producto As Producto = Nothing

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idProducto, nombre, precio, stock, idCategoria FROM PRODUCTOS WHERE idProducto = @idProducto"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idProducto", idProducto)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            producto = New Producto With {
                                .IdProducto = Convert.ToInt32(reader("idProducto")),
                                .Nombre = reader("nombre").ToString(),
                                .Precio = Convert.ToDecimal(reader("precio")),
                                .Stock = Convert.ToInt32(reader("stock")),
                                .IdCategoria = Convert.ToInt32(reader("idCategoria"))
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return producto
    End Function

    ' Obtener productos usando DataAdapter y DataSet
    Public Shared Function ObtenerTodosConDataSet() As DataSet
        Dim ds As New DataSet()

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                Dim query As String = "SELECT idProducto, nombre, precio, stock, idCategoria FROM PRODUCTOS ORDER BY nombre"

                Using adapter As New SqlDataAdapter(query, conn)
                    adapter.Fill(ds, "Productos")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ds
    End Function

    ' Actualizar stock (restar cantidad vendida)
    Public Shared Function ActualizarStock(idProducto As Integer, cantidad As Integer) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "UPDATE PRODUCTOS SET stock = stock - @cantidad WHERE idProducto = @idProducto"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@cantidad", cantidad)
                    cmd.Parameters.AddWithValue("@idProducto", idProducto)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Devolver stock (sumar cantidad cuando se anula)
    Public Shared Function DevolverStock(idProducto As Integer, cantidad As Integer) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "UPDATE PRODUCTOS SET stock = stock + @cantidad WHERE idProducto = @idProducto"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@cantidad", cantidad)
                    cmd.Parameters.AddWithValue("@idProducto", idProducto)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al devolver stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Verificar stock disponible
    Public Shared Function VerificarStock(idProducto As Integer, cantidad As Integer) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT stock FROM PRODUCTOS WHERE idProducto = @idProducto"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idProducto", idProducto)

                    Dim stock As Object = cmd.ExecuteScalar()
                    If stock IsNot Nothing Then
                        Return Convert.ToInt32(stock) >= cantidad
                    End If
                    Return False
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al verificar stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Insertar nuevo producto
    Public Shared Function Insertar(producto As Producto) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "INSERT INTO PRODUCTOS (nombre, precio, stock, idCategoria) VALUES (@nombre, @precio, @stock, @idCategoria)"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre)
                    cmd.Parameters.AddWithValue("@precio", producto.Precio)
                    cmd.Parameters.AddWithValue("@stock", producto.Stock)
                    cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al insertar producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Actualizar producto
    Public Shared Function Actualizar(producto As Producto) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "UPDATE PRODUCTOS SET nombre = @nombre, precio = @precio, stock = @stock, idCategoria = @idCategoria WHERE idProducto = @idProducto"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre)
                    cmd.Parameters.AddWithValue("@precio", producto.Precio)
                    cmd.Parameters.AddWithValue("@stock", producto.Stock)
                    cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria)
                    cmd.Parameters.AddWithValue("@idProducto", producto.IdProducto)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Eliminar producto
    Public Shared Function Eliminar(idProducto As Integer) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "DELETE FROM PRODUCTOS WHERE idProducto = @idProducto"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idProducto", idProducto)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al eliminar producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class