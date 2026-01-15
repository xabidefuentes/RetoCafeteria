Imports System.Drawing
Imports System.Windows.Forms

Public Class StockForm

    ' IDs de las categorías a controlar
    Private ReadOnly CategoriasControladas As New List(Of Integer) From {1011, 1012, 1013, 1014, 1015}
    Private filaSeleccionada As Integer = -1

    Private Sub StockForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        ConfigurarDataGridView()
        CargarProductos()

        btnActualizar.Enabled = False
        txtCantidad.Text = ""
    End Sub

    Private Sub ConfigurarDataGridView()
        dgvProductos.Columns.Clear()
        dgvProductos.Rows.Clear()

        Dim colProducto As New DataGridViewTextBoxColumn()
        colProducto.Name = "Producto"
        colProducto.HeaderText = "PRODUCTO"
        colProducto.Width = 180
        colProducto.ReadOnly = True
        colProducto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colProducto.DefaultCellStyle.Font = New Font("Segoe UI", 13)
        colProducto.DefaultCellStyle.Padding = New Padding(10, 0, 0, 0)
        dgvProductos.Columns.Add(colProducto)

        Dim colStock As New DataGridViewTextBoxColumn()
        colStock.Name = "Stock"
        colStock.HeaderText = "STOCK"
        colStock.Width = 70
        colStock.ReadOnly = True
        colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStock.DefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        dgvProductos.Columns.Add(colStock)

        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductos.MultiSelect = False
    End Sub

    Private Sub CargarProductos()
        Try
            dgvProductos.Rows.Clear()

            Dim todosProductos As List(Of Producto) = ProductoDAO.ObtenerTodos()

            Dim productosOrdenados = todosProductos _
                .Where(Function(p) CategoriasControladas.Contains(p.IdCategoria)) _
                .OrderBy(Function(p) p.Nombre) _
                .ToList()

            For Each prod As Producto In productosOrdenados
                Dim rowIndex As Integer = dgvProductos.Rows.Add(prod.Nombre, prod.Stock)
                ' Guardamos solo el ID en el Tag
                dgvProductos.Rows(rowIndex).Tag = prod.IdProducto
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cuando haces clic en una celda/fila
    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex >= 0 Then
            filaSeleccionada = e.RowIndex
            btnActualizar.Enabled = True
            txtCantidad.Focus()

            dgvProductos.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub btnAñadir_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If filaSeleccionada < 0 Then
            MessageBox.Show("Selecciona un producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtCantidad.Text) Then
            MessageBox.Show("Introduce una cantidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim cantidad As Integer = CInt(txtCantidad.Text)

            If cantidad <= 0 Then
                MessageBox.Show("La cantidad debe ser mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Obtener stock actual y sumar
            Dim stockActual As Integer = CInt(dgvProductos.Rows(filaSeleccionada).Cells("Stock").Value)
            Dim nuevoStock As Integer = stockActual + cantidad

            dgvProductos.Rows(filaSeleccionada).Cells("Stock").Value = nuevoStock

            txtCantidad.Text = ""
            txtCantidad.Focus()

        Catch ex As Exception
            MessageBox.Show("Error: Introduce un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Dim productosActualizados As Integer = 0

            For Each row As DataGridViewRow In dgvProductos.Rows
                Dim idProducto As Integer = CInt(row.Tag)
                Dim nuevoStock As Integer = CInt(row.Cells("Stock").Value)

                If ProductoDAO.ActualizarStock(idProducto, nuevoStock) Then
                    productosActualizados += 1
                End If
            Next

            MessageBox.Show($"Stock actualizado correctamente.{vbCrLf}",
                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al actualizar stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCantidadAñadir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnActualizar.PerformClick()
        End If
    End Sub
End Class