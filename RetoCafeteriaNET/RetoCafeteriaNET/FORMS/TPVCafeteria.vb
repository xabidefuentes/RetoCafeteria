Imports System.Drawing
Imports System.Windows.Forms

Public Class TPVCafeteria
    Private empleadoActual As Empleado
    Private comandaActual As Comanda

    Private ReadOnly ColorVerdePrimario As Color = Color.FromArgb(139, 195, 180)
    Private ReadOnly ColorVerdeClaro As Color = Color.FromArgb(200, 230, 220)
    Private ReadOnly ColorAzul As Color = Color.FromArgb(102, 178, 204)
    Private ReadOnly ColorMarronArena As Color = Color.FromArgb(210, 180, 140)
    Private ReadOnly ColorFondo As Color = Color.FromArgb(245, 250, 248)
    Private ReadOnly ColorBorde As Color = Color.FromArgb(180, 180, 180)
    Private ReadOnly ColorBotonNumerico As Color = Color.FromArgb(240, 240, 240)
    Private ReadOnly ColorRojo As Color = Color.FromArgb(220, 80, 80)

    Dim numeroActual As String = ""
    Dim celdaSeleccionada As DataGridViewCell = Nothing

    Private Sub FormTPV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "TPV Café Gaupasa"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized

        ConfigurarDataGridView()

        txtUDS.ReadOnly = True
        txtDTO.ReadOnly = True
        txtSubtotal.ReadOnly = True
        txtDTO.Text = "0"

        CargarCategorias()
        CargarTodosLosProductos()

        panelLogin.Visible = True
        panelLogin.BringToFront()
        CargarListaEmpleadosLogin()
    End Sub
    Private Sub CargarListaEmpleadosLogin()
        lblUsuario.Text = ""
        panelDerecha.Visible = False
        panelIzquierda.Visible = False
        Try
            dgvEmpleados.Rows.Clear()
            dgvEmpleados.Columns.Clear()

            Dim colNombre As New DataGridViewTextBoxColumn()
            colNombre.Name = "nombre"
            colNombre.HeaderText = "Seleccione Empleado"
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvEmpleados.Columns.Add(colNombre)

            dgvEmpleados.RowHeadersVisible = False
            dgvEmpleados.RowTemplate.Height = 60
            dgvEmpleados.DefaultCellStyle.Font = New Font("Segoe UI", 16)
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvEmpleados.MultiSelect = False
            dgvEmpleados.AllowUserToAddRows = False

            Dim empleados As List(Of Empleado) = EmpleadoDAO.ObtenerTodos()

            For Each emp In empleados
                ' Añadimos la fila solo con el nombre
                Dim rowIndex As Integer = dgvEmpleados.Rows.Add(emp.Nombre & " " & emp.Apellido)
                dgvEmpleados.Rows(rowIndex).Tag = emp.IdEmpleado
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar lista: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        dgvTicket.Rows.Clear()
        If dgvEmpleados.SelectedRows.Count > 0 Then
            Dim idSeleccionado As Integer = CInt(dgvEmpleados.SelectedRows(0).Tag)

            Me.empleadoActual = EmpleadoDAO.ObtenerPorId(idSeleccionado)

            panelLogin.Visible = False
            PanelTPV.Enabled = True

            panelDerecha.Visible = True
            panelIzquierda.Visible = True
            lblUsuario.Text = "Empleado: " & empleadoActual.Nombre
        Else
            MessageBox.Show("Seleccione un empleado de la lista")
        End If
    End Sub
    Private Sub ConfigurarDataGridView()
        dgvTicket.DefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Regular)
        dgvTicket.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        dgvTicket.RowTemplate.Height = 40

        ' Hacer las columnas editables
        dgvTicket.ReadOnly = False
        dgvTicket.Columns("UDS").ReadOnly = False
        dgvTicket.Columns("Descripcion").ReadOnly = True
        dgvTicket.Columns("Precio").ReadOnly = True
        dgvTicket.Columns("DTO").ReadOnly = False
        dgvTicket.Columns("Total").ReadOnly = True

        ' Evento para manejar cambios en las celdas
        AddHandler dgvTicket.CellEndEdit, AddressOf dgvTicket_CellEndEdit
        AddHandler dgvTicket.CellClick, AddressOf dgvTicket_CellClick
    End Sub

    ' Evento cuando se selecciona una celda
    Private Sub dgvTicket_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        ' Verificamos que no sea el encabezado
        If e.RowIndex >= 0 Then
            Dim nombreColumna As String = dgvTicket.Columns(e.ColumnIndex).Name

            ' SOLO permitimos asignar la celda si es UDS o DTO
            If nombreColumna = "UDS" OrElse nombreColumna = "DTO" Then
                celdaSeleccionada = dgvTicket.Rows(e.RowIndex).Cells(e.ColumnIndex)
                numeroActual = "" ' Reiniciamos para que el nuevo número empiece de cero
                dgvTicket.CurrentCell = celdaSeleccionada
            Else
                ' Si toca cualquier otra celda (como la descripción), anulamos la selección para el teclado
                celdaSeleccionada = Nothing
            End If
        End If
    End Sub

    ' Evento cuando se termina de editar una celda
    Private Sub dgvTicket_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        Try
            Dim row As DataGridViewRow = dgvTicket.Rows(e.RowIndex)

            ' Recalcular el total de la fila
            Dim cantidad As Integer = CInt(row.Cells("UDS").Value)
            Dim precioStr As String = row.Cells("Precio").Value.ToString().Replace("€", "").Trim()
            Dim precio As Decimal = Decimal.Parse(precioStr)
            Dim dtoStr As String = row.Cells("DTO").Value.ToString().Replace("%", "").Trim()
            Dim descuento As Decimal = Decimal.Parse(dtoStr)

            Dim subtotal As Decimal = cantidad * precio
            Dim total As Decimal = subtotal * (1 - (descuento / 100))

            row.Cells("Total").Value = total.ToString("0.00") & "€"

            ' Actualizar totales generales
            ActualizarTotalesGenerales()

        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Actualizar los totales en los TextBox (UDS, DTO, SUBTOTAL)
    Private Sub ActualizarTotalesGenerales()
        Dim totalUDS As Integer = 0
        Dim totalDescuento As Decimal = 0
        Dim subtotal As Decimal = 0
        Dim filasConDescuento As Integer = 0

        For Each row As DataGridViewRow In dgvTicket.Rows
            If row.Cells("UDS").Value IsNot Nothing Then
                ' Sumar UDS
                totalUDS += CInt(row.Cells("UDS").Value)

                ' Sumar descuentos
                Dim dtoStr As String = row.Cells("DTO").Value.ToString().Replace("%", "").Trim()
                Dim dto As Decimal = Decimal.Parse(dtoStr)
                If dto > 0 Then
                    totalDescuento += dto
                    filasConDescuento += 1
                End If

                ' Sumar subtotal
                Dim totalStr As String = row.Cells("Total").Value.ToString().Replace("€", "").Trim()
                subtotal += Decimal.Parse(totalStr)
            End If
        Next

        ' Actualizar TextBoxes
        txtUDS.Text = totalUDS.ToString()

        ' Calcular promedio de descuento
        If filasConDescuento > 0 Then
            txtDTO.Text = (totalDescuento / filasConDescuento).ToString("0.00") & "%"
        Else
            txtDTO.Text = "0%"
        End If

        txtSubtotal.Text = subtotal.ToString("0.00") & "€"
    End Sub

    Private Sub btnCambiarEmpleado_Click(sender As Object, e As EventArgs) Handles btnCambiarEmpleado.Click
        panelDerecha.Visible = False
        panelIzquierda.Visible = False
        panelLogin.Visible = True
        panelLogin.BringToFront()

        ' Limpiamos el empleado actual por seguridad
        Me.empleadoActual = Nothing
    End Sub

    Private Sub CargarCategorias()
        Try
            panelCategoriasGrid.Controls.Clear()

            Dim categorias As List(Of Categoria) = CategoriaDAO.ObtenerCategoriasProductos()

            panelCategoriasGrid.AutoScroll = True

            For Each cat As Categoria In categorias
               If cat.IdCategoria < 1024 Then
                Dim btnCategoria As New Button()
                btnCategoria.Text = cat.Nombre.ToUpper()
                btnCategoria.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                btnCategoria.Size = New Size(215, 95)
                btnCategoria.BackColor = ColorVerdePrimario
                btnCategoria.ForeColor = Color.White
                btnCategoria.FlatStyle = FlatStyle.Flat
                btnCategoria.FlatAppearance.BorderSize = 0
                btnCategoria.Cursor = Cursors.Hand
                btnCategoria.Margin = New Padding(5)
                btnCategoria.Tag = cat

                btnCategoria.TextImageRelation = TextImageRelation.ImageAboveText
                btnCategoria.ImageAlign = ContentAlignment.TopCenter
                btnCategoria.TextAlign = ContentAlignment.BottomCenter

                AddHandler btnCategoria.MouseEnter, Sub() btnCategoria.BackColor = Color.FromArgb(120, 180, 165)
                AddHandler btnCategoria.MouseLeave, Sub() btnCategoria.BackColor = ColorVerdePrimario
                AddHandler btnCategoria.Click, AddressOf BtnCategoria_Click

                panelCategoriasGrid.Controls.Add(btnCategoria)
            End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCategoria_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As Button = DirectCast(sender, Button)
            Dim categoria As Categoria = DirectCast(btn.Tag, Categoria)
            CargarProductosPorCategoria(categoria.IdCategoria)
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar categoría: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarProductosPorCategoria(idCategoria As Integer)
        Try
            panelProductosGrid.Controls.Clear()

            Dim productos As List(Of Producto) = ProductoDAO.ObtenerPorCategoria(idCategoria)

            panelProductosGrid.AutoScroll = True

            For Each prod As Producto In productos
                Dim btnProducto As New Button()
                btnProducto.Text = prod.Nombre & vbCrLf & prod.Precio.ToString("0.00") & "€"
                btnProducto.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                btnProducto.Size = New Size(170, 110)
                btnProducto.BackColor = ColorVerdeClaro
                btnProducto.ForeColor = Color.FromArgb(50, 50, 50)
                btnProducto.FlatStyle = FlatStyle.Flat
                btnProducto.FlatAppearance.BorderColor = ColorBorde
                btnProducto.FlatAppearance.BorderSize = 1
                btnProducto.Cursor = Cursors.Hand
                btnProducto.Margin = New Padding(5)
                btnProducto.Tag = prod

                AddHandler btnProducto.MouseEnter, Sub() btnProducto.BackColor = Color.FromArgb(180, 220, 210)
                AddHandler btnProducto.MouseLeave, Sub() btnProducto.BackColor = ColorVerdeClaro
                AddHandler btnProducto.Click, AddressOf BtnProducto_Click

                panelProductosGrid.Controls.Add(btnProducto)
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarTodosLosProductos()
        Try
            panelProductosGrid.Controls.Clear()

            Dim productos As List(Of Producto) = ProductoDAO.ObtenerTodos()

            panelProductosGrid.AutoScroll = True

            For Each prod As Producto In productos
                Dim btnProducto As New Button()
                btnProducto.Text = prod.Nombre & vbCrLf & prod.Precio.ToString("0.00") & "€"
                btnProducto.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                btnProducto.Size = New Size(170, 110)
                btnProducto.BackColor = ColorVerdeClaro
                btnProducto.ForeColor = Color.FromArgb(50, 50, 50)
                btnProducto.FlatStyle = FlatStyle.Flat
                btnProducto.FlatAppearance.BorderColor = ColorBorde
                btnProducto.FlatAppearance.BorderSize = 1
                btnProducto.Cursor = Cursors.Hand
                btnProducto.Margin = New Padding(5)
                btnProducto.Tag = prod

                AddHandler btnProducto.MouseEnter, Sub() btnProducto.BackColor = Color.FromArgb(180, 220, 210)
                AddHandler btnProducto.MouseLeave, Sub() btnProducto.BackColor = ColorVerdeClaro
                AddHandler btnProducto.Click, AddressOf BtnProducto_Click

                panelProductosGrid.Controls.Add(btnProducto)
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnProducto_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As Button = DirectCast(sender, Button)
            Dim producto As Producto = DirectCast(btn.Tag, Producto)
            Dim cantidad As Integer = 1 ' Por defecto 1

            If comandaActual Is Nothing OrElse comandaActual.IdComanda = 0 Then
                comandaActual = New Comanda With {
                    .IdEmpleado = empleadoActual.IdEmpleado,
                    .Fecha = Date.Today,
                    .Hora = DateTime.Now.TimeOfDay,
                    .Total = 0
                }
                comandaActual.IdComanda = ComandaDAO.Crear(comandaActual)
            End If

            If Not ProductoDAO.VerificarStock(producto.IdProducto, cantidad) Then
                MessageBox.Show("Stock insuficiente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim productoExiste As Boolean = False
            For Each row As DataGridViewRow In dgvTicket.Rows
                If row.Cells("Descripcion").Value IsNot Nothing AndAlso row.Cells("Descripcion").Value.ToString() = producto.Nombre Then
                    Dim cantidadActual As Integer = CInt(row.Cells("UDS").Value)
                    Dim nuevaCantidad As Integer = cantidadActual + cantidad

                    Dim lineaNueva As New LineaComanda With {
                        .IdComanda = comandaActual.IdComanda,
                        .IdProducto = producto.IdProducto,
                        .Cantidad = cantidad,
                        .Precio = producto.Precio,
                        .NombreProducto = producto.Nombre
                    }

                    If ComandaDAO.InsertarLinea(lineaNueva) Then
                        row.Cells("UDS").Value = nuevaCantidad
                        row.Cells("Total").Value = (nuevaCantidad * producto.Precio).ToString("0.00") & "€"
                    End If

                    productoExiste = True
                    Exit For
                End If
            Next

            If Not productoExiste Then
                Dim linea As New LineaComanda With {
                    .IdComanda = comandaActual.IdComanda,
                    .IdProducto = producto.IdProducto,
                    .Cantidad = cantidad,
                    .Precio = producto.Precio,
                    .NombreProducto = producto.Nombre
                }

                If ComandaDAO.InsertarLinea(linea) Then
                    dgvTicket.Rows.Add(cantidad, producto.Nombre, producto.Precio.ToString("0.00") & "€", "0", (cantidad * producto.Precio).ToString("0.00") & "€")
                End If
            End If

            ActualizarTotalesGenerales()

        Catch ex As Exception
            MessageBox.Show("Error al agregar producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Teclado numérico
    Private Sub BtnNumero_Click(sender As Object, e As EventArgs) Handles btnNum1.Click, btnNum2.Click, btnNum3.Click, btnNum4.Click, btnNum5.Click, btnNum6.Click, btnNum7.Click, btnNum8.Click, btnNum9.Click, btnNum0.Click
        If celdaSeleccionada IsNot Nothing Then
            Dim btn As Button = DirectCast(sender, Button)

            ' Acumulamos el número
            numeroActual &= btn.Text
            celdaSeleccionada.Value = numeroActual

            ' Llamamos manualmente al evento que calcula la fila actual
            Dim args As New DataGridViewCellEventArgs(celdaSeleccionada.ColumnIndex, celdaSeleccionada.RowIndex)
            dgvTicket_CellEndEdit(dgvTicket, args)
        End If
    End Sub

    Private Sub btnNumX_Click(sender As Object, e As EventArgs) Handles btnNumCancelar.Click
        If celdaSeleccionada IsNot Nothing Then
            numeroActual = ""
            celdaSeleccionada.Value = "0"
        End If
    End Sub

    Private Sub btnNumConfirmar_Click(sender As Object, e As EventArgs) Handles btnNumConfirmar.Click
        If celdaSeleccionada IsNot Nothing AndAlso Not String.IsNullOrEmpty(numeroActual) Then
            celdaSeleccionada.Value = numeroActual
            numeroActual = ""
            celdaSeleccionada = Nothing
            dgvTicket.EndEdit()
        End If
    End Sub

    ' Anular línea SIN confirmación
    Private Sub btnAnularLinea_Click(sender As Object, e As EventArgs) Handles btnAnularLinea.Click
        If dgvTicket.SelectedRows.Count > 0 Then
            dgvTicket.Rows.RemoveAt(dgvTicket.SelectedRows(0).Index)
            ActualizarTotalesGenerales()
        Else
            MessageBox.Show("Selecciona una línea", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAnularComanda_Click(sender As Object, e As EventArgs) Handles btnAnularComanda.Click
        If dgvTicket.Rows.Count > 0 Then
            If MessageBox.Show("¿Anular toda la comanda?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                If comandaActual IsNot Nothing Then
                    ComandaDAO.AnularComanda(comandaActual.IdComanda)
                End If
                dgvTicket.Rows.Clear()
                ActualizarTotalesGenerales()
                comandaActual = Nothing
            End If
        End If
    End Sub

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        If dgvTicket.Rows.Count = 0 Then
            MessageBox.Show("No hay productos en la comanda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim total As String = txtSubtotal.Text
        If MessageBox.Show($"Total a cobrar: {total}" & vbCrLf & vbCrLf & "¿Confirmar pago?",
                      "Cobrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ' IDs de las categorías a controlar stock (Infusiones, Cervezas, Vinos, Refrescos, Combinados)
            Dim categoriasControladas As New List(Of Integer) From {1, 2, 3, 4, 5}
            Dim errorStock As Boolean = False
            Dim productosConError As New List(Of String)

            ' Descontar stock de productos de categorías controladas
            For Each row As DataGridViewRow In dgvTicket.Rows
                Try
                    Dim nombreProducto As String = row.Cells("Descripcion").Value.ToString()
                    Dim cantidad As Integer = CInt(row.Cells("UDS").Value)

                    ' Obtener el producto completo para verificar su categoría
                    Dim producto As Producto = ProductoDAO.ObtenerPorNombre(nombreProducto)

                    If producto IsNot Nothing AndAlso categoriasControladas.Contains(producto.IdCategoria) Then
                        ' Verificar que hay stock suficiente
                        If producto.Stock < cantidad Then
                            errorStock = True
                            productosConError.Add($"{nombreProducto} (Stock: {producto.Stock}, Necesario: {cantidad})")
                        Else
                            ' Descontar el stock
                            Dim nuevoStock As Integer = producto.Stock - cantidad
                            If Not ProductoDAO.ActualizarStock(producto.IdProducto, nuevoStock) Then
                                errorStock = True
                                productosConError.Add($"{nombreProducto} (Error al actualizar)")
                            End If
                        End If
                    End If

                Catch ex As Exception
                    errorStock = True
                    productosConError.Add($"Error: {ex.Message}")
                End Try
            Next

            ' Mostrar resultado
            If errorStock Then
                MessageBox.Show("Error al descontar stock:" & vbCrLf & vbCrLf &
                          String.Join(vbCrLf, productosConError),
                          "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Pago realizado correctamente" & vbCrLf & "Stock actualizado",
                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvTicket.Rows.Clear()
                ActualizarTotalesGenerales()
                comandaActual = Nothing
            End If
        End If
    End Sub

    Private Sub CalcularTotales()
        ActualizarTotalesGenerales()
    End Sub

    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        StockForm.Show()
    End Sub
End Class