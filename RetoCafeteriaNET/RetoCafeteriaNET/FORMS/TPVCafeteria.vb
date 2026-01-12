Imports System.Drawing
Imports System.Windows.Forms

Public Class TPVCafeteria
    Private empleadoActual As Empleado
    Private comandaActual As Comanda

    ' Colores profesionales TPV Café Gaupasa
    Private ReadOnly ColorVerdePrimario As Color = Color.FromArgb(139, 195, 180)
    Private ReadOnly ColorVerdeClaro As Color = Color.FromArgb(200, 230, 220)
    Private ReadOnly ColorAzul As Color = Color.FromArgb(102, 178, 204)
    Private ReadOnly ColorMarronArena As Color = Color.FromArgb(210, 180, 140)
    Private ReadOnly ColorFondo As Color = Color.FromArgb(245, 250, 248)
    Private ReadOnly ColorBorde As Color = Color.FromArgb(180, 180, 180)
    Private ReadOnly ColorBotonNumerico As Color = Color.FromArgb(240, 240, 240)
    Private ReadOnly ColorRojo As Color = Color.FromArgb(220, 80, 80)

    Dim numeroActual As String = ""

    Private Sub FormTPV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "TPV Café Gaupasa"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized




        PanelTPV.Enabled = False

        empleadoActual = New Empleado With {
        .IdEmpleado = 1,
        .Nombre = "Usuario",
        .Apellido = "Prueba"
    }
        PanelTPV.Enabled = True
        CargarCategorias()
        CargarTodosLosProductos()
    End Sub

    ' =============================================
    ' LOGIN (si tienes los controles en el diseñador)
    ' =============================================


    ' =============================================
    ' CERRAR SESIÓN
    ' =============================================
    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        If MessageBox.Show("¿Deseas cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            PanelTPV.Enabled = False

            ' Mostrar login si existe
            ' PanelLogin.Visible = True
            ' PanelLogin.BringToFront()

            lblUsuario.Text = "Usuario"
            dgvTicket.Rows.Clear()
            CalcularTotales()
            comandaActual = Nothing
            empleadoActual = Nothing

            ' Si no tienes login, cerrar la aplicación
            Me.Close()
        End If
    End Sub

    ' =============================================
    ' Método para cargar categorías de productos
    ' =============================================
    Private Sub CargarCategorias()
        Try
            panelCategoriasGrid.Controls.Clear()

            Dim categorias As List(Of Categoria) = CategoriaDAO.ObtenerCategoriasProductos()

            For Each cat As Categoria In categorias
                Dim btnCategoria As New Button()
                btnCategoria.Text = cat.Nombre.ToUpper()
                btnCategoria.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                btnCategoria.Size = New Size(220, 95)
                btnCategoria.BackColor = ColorVerdePrimario
                btnCategoria.ForeColor = Color.White
                btnCategoria.FlatStyle = FlatStyle.Flat
                btnCategoria.FlatAppearance.BorderSize = 0
                btnCategoria.Cursor = Cursors.Hand
                btnCategoria.Margin = New Padding(5)
                btnCategoria.Tag = cat

                AddHandler btnCategoria.MouseEnter, Sub() btnCategoria.BackColor = Color.FromArgb(120, 180, 165)
                AddHandler btnCategoria.MouseLeave, Sub() btnCategoria.BackColor = ColorVerdePrimario
                AddHandler btnCategoria.Click, AddressOf BtnCategoria_Click

                panelCategoriasGrid.Controls.Add(btnCategoria)
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

            For Each prod As Producto In productos
                Dim btnProducto As New Button()
                btnProducto.Text = prod.Nombre & vbCrLf & prod.Precio.ToString("0.00") & "€"
                btnProducto.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                btnProducto.Size = New Size(150, 110)
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

            For Each prod As Producto In productos
                Dim btnProducto As New Button()
                btnProducto.Text = prod.Nombre & vbCrLf & prod.Precio.ToString("0.00") & "€"
                btnProducto.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                btnProducto.Size = New Size(210, 110)
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
            Dim cantidad As Integer = Integer.Parse(If(String.IsNullOrEmpty(txtUDS.Text), "1", txtUDS.Text))

            ' Verificar si hay una comanda activa
            If comandaActual Is Nothing OrElse comandaActual.IdComanda = 0 Then
                comandaActual = New Comanda With {
                    .IdEmpleado = empleadoActual.IdEmpleado,
                    .Fecha = Date.Today,
                    .Hora = DateTime.Now.TimeOfDay,
                    .Total = 0
                }
                comandaActual.IdComanda = ComandaDAO.Crear(comandaActual)
            End If

            ' Verificar stock
            If Not ProductoDAO.VerificarStock(producto.IdProducto, cantidad) Then
                MessageBox.Show("Stock insuficiente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Verificar si el producto ya está en la comanda
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

            ' Si no existe, agregarlo
            If Not productoExiste Then
                Dim linea As New LineaComanda With {
                    .IdComanda = comandaActual.IdComanda,
                    .IdProducto = producto.IdProducto,
                    .Cantidad = cantidad,
                    .Precio = producto.Precio,
                    .NombreProducto = producto.Nombre
                }

                If ComandaDAO.InsertarLinea(linea) Then
                    dgvTicket.Rows.Add(cantidad, producto.Nombre, producto.Precio.ToString("0.00") & "€", "0%", (cantidad * producto.Precio).ToString("0.00") & "€")
                End If
            End If

            CalcularTotales()
            txtUDS.Text = "1"
            numeroActual = ""

        Catch ex As Exception
            MessageBox.Show("Error al agregar producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =============================================
    ' TECLADO NUMÉRICO - Conectar estos eventos en el diseñador
    ' =============================================
    Private Sub BtnNumero_Click(sender As Object, e As EventArgs) Handles btnNum1.Click, btnNum2.Click, btnNum3.Click, btnNum4.Click, btnNum5.Click, btnNum6.Click, btnNum7.Click, btnNum8.Click, btnNum9.Click, btnNum0.Click
        Dim btn As Button = DirectCast(sender, Button)
        numeroActual &= btn.Text
        txtUDS.Text = numeroActual
    End Sub

    Private Sub btnNumX_Click(sender As Object, e As EventArgs) Handles btnNumCancelar.Click
        numeroActual = ""
        txtUDS.Text = "1"
    End Sub

    Private Sub btnNumConfirmar_Click(sender As Object, e As EventArgs) Handles btnNumConfirmar.Click
        If Not String.IsNullOrEmpty(numeroActual) Then
            txtUDS.Text = numeroActual
        End If
        numeroActual = ""
    End Sub

    ' =============================================
    ' BOTONES DE ACCIÓN
    ' =============================================
    Private Sub btnAnularLinea_Click(sender As Object, e As EventArgs) Handles btnAnularLinea.Click
        If dgvTicket.SelectedRows.Count > 0 Then
            If MessageBox.Show("¿Eliminar esta línea?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dgvTicket.Rows.RemoveAt(dgvTicket.SelectedRows(0).Index)
                CalcularTotales()
            End If
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
                CalcularTotales()
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
            MessageBox.Show("Pago realizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvTicket.Rows.Clear()
            CalcularTotales()
            comandaActual = Nothing
        End If
    End Sub

    Private Sub CalcularTotales()
        Dim subtotal As Decimal = 0

        For Each row As DataGridViewRow In dgvTicket.Rows
            If row.Cells("Total").Value IsNot Nothing Then
                Dim totalStr As String = row.Cells("Total").Value.ToString().Replace("€", "").Trim()
                subtotal += Decimal.Parse(totalStr)
            End If
        Next

        txtSubtotal.Text = subtotal.ToString("0.00") & "€"
    End Sub

    ' =============================================
    ' Eventos vacíos del diseñador - Puedes eliminarlos
    ' =============================================
    Private Sub panelLogin_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub panelDerecha_Paint(sender As Object, e As PaintEventArgs) Handles panelDerecha.Paint
    End Sub

    Private Sub PanelTPV_Paint(sender As Object, e As PaintEventArgs) Handles PanelTPV.Paint
    End Sub

    Private Sub panelInferiorIzq_Paint(sender As Object, e As PaintEventArgs) Handles panelInferiorIzq.Paint
    End Sub

    Private Sub lblDNI_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub dgvTicket_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTicket.CellContentClick
    End Sub

    Private Sub panelCategoriasGrid_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class