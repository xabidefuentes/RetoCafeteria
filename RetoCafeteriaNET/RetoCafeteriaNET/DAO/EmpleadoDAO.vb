Imports System.Data.SqlClient
Imports System.Data

Public Class EmpleadoDAO

    ' Login de empleado
    Public Shared Function Login(dni As String, password As String) As Empleado
        Dim empleado As Empleado = Nothing

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idEmpleado, nombre, apellido, dni, salario, fechaAlta, idCategoria " &
                                     "FROM EMPLEADOS WHERE dni = @dni AND password = @password"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@dni", dni)
                    cmd.Parameters.AddWithValue("@password", password)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            empleado = New Empleado()
                            empleado.IdEmpleado = Convert.ToInt32(reader("idEmpleado"))
                            empleado.Nombre = reader("nombre").ToString()
                            empleado.Apellido = reader("apellido").ToString()
                            empleado.Dni = reader("dni").ToString()
                            empleado.Salario = Convert.ToDecimal(reader("salario"))
                            empleado.FechaAlta = Convert.ToDateTime(reader("fechaAlta"))
                            empleado.IdCategoria = Convert.ToInt32(reader("idCategoria"))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al realizar login: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return empleado
    End Function

    ' Obtener todos los empleados
    Public Shared Function ObtenerTodos() As List(Of Empleado)
        Dim empleados As New List(Of Empleado)

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT idEmpleado, nombre, apellido, dni, salario, fechaAlta, idCategoria " &
                                     "FROM EMPLEADOS ORDER BY apellido, nombre"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim empleado As New Empleado()
                            empleado.IdEmpleado = Convert.ToInt32(reader("idEmpleado"))
                            empleado.Nombre = reader("nombre").ToString()
                            empleado.Apellido = reader("apellido").ToString()
                            empleado.Dni = reader("dni").ToString()
                            empleado.Salario = Convert.ToDecimal(reader("salario"))
                            empleado.FechaAlta = Convert.ToDateTime(reader("fechaAlta"))
                            empleado.IdCategoria = Convert.ToInt32(reader("idCategoria"))
                            empleados.Add(empleado)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener empleados: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return empleados
    End Function

    ' Obtener empleados usando DataAdapter y DataSet
    Public Shared Function ObtenerTodosConDataSet() As DataSet
        Dim ds As New DataSet()

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                Dim query As String = "SELECT idEmpleado, nombre, apellido, dni, salario, fechaAlta, idCategoria FROM EMPLEADOS ORDER BY apellido"

                Using adapter As New SqlDataAdapter(query, conn)
                    adapter.Fill(ds, "Empleados")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener empleados: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ds
    End Function

    Public Shared Function ObtenerPorId(id As Integer) As Empleado
        Dim empleado As Empleado = Nothing
        Dim sql As String = "SELECT idEmpleado, nombre, apellido, dni FROM Empleados WHERE idEmpleado = @id"

        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            empleado = New Empleado() With {
                            .IdEmpleado = Convert.ToInt32(reader("idEmpleado")),
                            .Nombre = reader("nombre").ToString(),
                            .Apellido = reader("apellido").ToString(),
                            .Dni = reader("dni").ToString()
                        }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener el empleado: " & ex.Message)
        End Try

        Return empleado
    End Function
    ' Insertar nuevo empleado
    Public Shared Function Insertar(empleado As Empleado) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "INSERT INTO EMPLEADOS (nombre, apellido, dni, password, salario, fechaAlta, idCategoria) " &
                                     "VALUES (@nombre, @apellido, @dni, @password, @salario, @fechaAlta, @idCategoria)"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", empleado.Nombre)
                    cmd.Parameters.AddWithValue("@apellido", empleado.Apellido)
                    cmd.Parameters.AddWithValue("@dni", empleado.Dni)
                    cmd.Parameters.AddWithValue("@password", empleado.Password)
                    cmd.Parameters.AddWithValue("@salario", empleado.Salario)
                    cmd.Parameters.AddWithValue("@fechaAlta", empleado.FechaAlta)
                    cmd.Parameters.AddWithValue("@idCategoria", empleado.IdCategoria)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al insertar empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Actualizar empleado
    Public Shared Function Actualizar(empleado As Empleado) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "UPDATE EMPLEADOS SET nombre = @nombre, apellido = @apellido, " &
                                     "salario = @salario, idCategoria = @idCategoria " &
                                     "WHERE idEmpleado = @idEmpleado"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", empleado.Nombre)
                    cmd.Parameters.AddWithValue("@apellido", empleado.Apellido)
                    cmd.Parameters.AddWithValue("@salario", empleado.Salario)
                    cmd.Parameters.AddWithValue("@idCategoria", empleado.IdCategoria)
                    cmd.Parameters.AddWithValue("@idEmpleado", empleado.IdEmpleado)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Eliminar empleado
    Public Shared Function Eliminar(idEmpleado As Integer) As Boolean
        Try
            Using conn As SqlConnection = ConexionBD.ObtenerConexion()
                conn.Open()

                Dim query As String = "DELETE FROM EMPLEADOS WHERE idEmpleado = @idEmpleado"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al eliminar empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class