Imports System.Data.SqlClient
Imports System.Data

' =============================================
' Clase: ComandaDAO
' Acceso a datos de Comandas usando ADO.NET
' =============================================
Public Class ComandaDAO

    ' Crear nueva comanda y devolver su ID
    Public Shared Function Crear(comanda As Comanda) As Integer
        Dim idComanda As Integer = 0

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "INSERT INTO COMANDAS (fecha, hora, total, idEmpleado) VALUES (@fecha, @hora, @total, @idEmpleado); SELECT SCOPE_IDENTITY();"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@fecha", comanda.Fecha)
                    cmd.Parameters.AddWithValue("@hora", comanda.Hora)
                    cmd.Parameters.AddWithValue("@total", comanda.Total)
                    cmd.Parameters.AddWithValue("@idEmpleado", comanda.IdEmpleado)

                    idComanda = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al crear comanda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return idComanda
    End Function

    ' Actualizar total de la comanda
    Public Shared Function ActualizarTotal(idComanda As Integer) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "UPDATE COMANDAS SET total = (SELECT SUM(cantidad * precio) FROM LINEA_COMANDAS WHERE idComanda = @idComanda) WHERE idComanda = @idComanda"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idComanda", idComanda)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar total: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Insertar línea en comanda con transacción
    Public Shared Function InsertarLinea(linea As LineaComanda) As Boolean
        Dim conn As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing

        Try
            conn = ConexionBD.ObtenerConexion()
            conn.Open()

            ' Verificar stock antes de insertar
            If Not ProductoDAO.VerificarStock(linea.IdProducto, linea.Cantidad) Then
                MessageBox.Show("Stock insuficiente para este producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Iniciar transacción
            transaction = conn.BeginTransaction()

            ' Insertar línea
            Dim query As String = "INSERT INTO LINEA_COMANDAS (cantidad, precio, idComanda, idProducto) VALUES (@cantidad, @precio, @idComanda, @idProducto)"

            Using cmd As New SqlCommand(query, conn, transaction)
                cmd.Parameters.AddWithValue("@cantidad", linea.Cantidad)
                cmd.Parameters.AddWithValue("@precio", linea.Precio)
                cmd.Parameters.AddWithValue("@idComanda", linea.IdComanda)
                cmd.Parameters.AddWithValue("@idProducto", linea.IdProducto)
                cmd.ExecuteNonQuery()
            End Using

            ' Actualizar stock del producto
            Dim queryStock As String = "UPDATE PRODUCTOS SET stock = stock - @cantidad WHERE idProducto = @idProducto"
            Using cmdStock As New SqlCommand(queryStock, conn, transaction)
                cmdStock.Parameters.AddWithValue("@cantidad", linea.Cantidad)
                cmdStock.Parameters.AddWithValue("@idProducto", linea.IdProducto)
                cmdStock.ExecuteNonQuery()
            End Using

            ' Actualizar total de la comanda
            Dim queryTotal As String = "UPDATE COMANDAS SET total = (SELECT SUM(cantidad * precio) FROM LINEA_COMANDAS WHERE idComanda = @idComanda) WHERE idComanda = @idComanda"
            Using cmdTotal As New SqlCommand(queryTotal, conn, transaction)
                cmdTotal.Parameters.AddWithValue("@idComanda", linea.IdComanda)
                cmdTotal.ExecuteNonQuery()
            End Using

            ' Confirmar transacción
            transaction.Commit()
            Return True

        Catch ex As Exception
            ' Revertir transacción en caso de error
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Error al insertar línea: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    ' Obtener líneas de una comanda
    Public Shared Function ObtenerLineas(idComanda As Integer) As List(Of LineaComanda)
        Dim lineas As New List(Of LineaComanda)

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT lc.idLineaComanda, lc.cantidad, lc.precio, lc.idComanda, lc.idProducto, p.nombre " &
                                     "FROM LINEA_COMANDAS lc " &
                                     "INNER JOIN PRODUCTOS p ON lc.idProducto = p.idProducto " &
                                     "WHERE lc.idComanda = @idComanda"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idComanda", idComanda)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            lineas.Add(New LineaComanda With {
                                .IdLineaComanda = Convert.ToInt32(reader("idLineaComanda")),
                                .Cantidad = Convert.ToInt32(reader("cantidad")),
                                .Precio = Convert.ToDecimal(reader("precio")),
                                .IdComanda = Convert.ToInt32(reader("idComanda")),
                                .IdProducto = Convert.ToInt32(reader("idProducto")),
                                .NombreProducto = reader("nombre").ToString(),
                                .Descuento = 0
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener líneas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return lineas
    End Function

    ' Eliminar línea de comanda y devolver stock
    Public Shared Function EliminarLinea(idLineaComanda As Integer, idProducto As Integer, cantidad As Integer) As Boolean
        Dim conn As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing

        Try
            conn = ConexionBD.ObtenerConexion()
            conn.Open()
            transaction = conn.BeginTransaction()

            ' Eliminar la línea
            Dim query As String = "DELETE FROM LINEA_COMANDAS WHERE idLineaComanda = @idLineaComanda"

            Using cmd As New SqlCommand(query, conn, transaction)
                cmd.Parameters.AddWithValue("@idLineaComanda", idLineaComanda)
                cmd.ExecuteNonQuery()
            End Using

            ' Devolver stock
            Dim queryStock As String = "UPDATE PRODUCTOS SET stock = stock + @cantidad WHERE idProducto = @idProducto"
            Using cmdStock As New SqlCommand(queryStock, conn, transaction)
                cmdStock.Parameters.AddWithValue("@cantidad", cantidad)
                cmdStock.Parameters.AddWithValue("@idProducto", idProducto)
                cmdStock.ExecuteNonQuery()
            End Using

            ' Confirmar transacción
            transaction.Commit()
            Return True

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Error al eliminar línea: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    ' Anular comanda completa (devolver todo el stock)
    Public Shared Function AnularComanda(idComanda As Integer) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                ' Primero devolver el stock de todos los productos
                Dim queryStock As String = "UPDATE PRODUCTOS SET stock = stock + lc.cantidad " &
                                          "FROM PRODUCTOS p INNER JOIN LINEA_COMANDAS lc ON p.idProducto = lc.idProducto " &
                                          "WHERE lc.idComanda = @idComanda"

                Using cmdStock As New SqlCommand(queryStock, conn)
                    cmdStock.Parameters.AddWithValue("@idComanda", idComanda)
                    cmdStock.ExecuteNonQuery()
                End Using

                ' Eliminar las líneas
                Dim queryLineas As String = "DELETE FROM LINEA_COMANDAS WHERE idComanda = @idComanda"
                Using cmdLineas As New SqlCommand(queryLineas, conn)
                    cmdLineas.Parameters.AddWithValue("@idComanda", idComanda)
                    cmdLineas.ExecuteNonQuery()
                End Using

                ' Eliminar la comanda
                Dim queryComanda As String = "DELETE FROM COMANDAS WHERE idComanda = @idComanda"
                Using cmdComanda As New SqlCommand(queryComanda, conn)
                    cmdComanda.Parameters.AddWithValue("@idComanda", idComanda)
                    Return cmdComanda.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al anular comanda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Obtener comanda por ID
    Public Shared Function ObtenerPorId(idComanda As Integer) As Comanda
        Dim comanda As Comanda = Nothing

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idComanda, fecha, hora, total, idEmpleado FROM COMANDAS WHERE idComanda = @idComanda"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idComanda", idComanda)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            comanda = New Comanda With {
                                .IdComanda = Convert.ToInt32(reader("idComanda")),
                                .Fecha = Convert.ToDateTime(reader("fecha")),
                                .Hora = TimeSpan.Parse(reader("hora").ToString()),
                                .Total = Convert.ToDecimal(reader("total")),
                                .IdEmpleado = Convert.ToInt32(reader("idEmpleado"))
                            }
                        End If
                    End Using
                End Using

                ' Cargar las líneas si se encontró la comanda
                If comanda IsNot Nothing Then
                    comanda.Lineas = ObtenerLineas(idComanda)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener comanda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return comanda
    End Function

    ' Obtener comandas del día
    Public Shared Function ObtenerComandasDelDia() As List(Of Comanda)
        Dim comandas As New List(Of Comanda)

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idComanda, fecha, hora, total, idEmpleado FROM COMANDAS WHERE fecha = CONVERT(date, GETDATE()) ORDER BY hora DESC"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            comandas.Add(New Comanda With {
                                .IdComanda = Convert.ToInt32(reader("idComanda")),
                                .Fecha = Convert.ToDateTime(reader("fecha")),
                                .Hora = TimeSpan.Parse(reader("hora").ToString()),
                                .Total = Convert.ToDecimal(reader("total")),
                                .IdEmpleado = Convert.ToInt32(reader("idEmpleado"))
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener comandas del día: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return comandas
    End Function

    ' Obtener comandas usando DataAdapter y DataSet
    Public Shared Function ObtenerComandasConDataSet() As DataSet
        Dim ds As New DataSet()

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                Dim query As String = "SELECT c.idComanda, c.fecha, c.hora, c.total, e.nombre + ' ' + e.apellido AS empleado " &
                                     "FROM COMANDAS c " &
                                     "INNER JOIN EMPLEADOS e ON c.idEmpleado = e.idEmpleado " &
                                     "ORDER BY c.fecha DESC, c.hora DESC"

                Using adapter As New SqlDataAdapter(query, conn)
                    adapter.Fill(ds, "Comandas")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener comandas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ds
    End Function
End Class