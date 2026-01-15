Imports System.Drawing
Imports System.Windows.Forms

Public Class StockForm

    ' IDs de las categorías a controlar
    Private ReadOnly CategoriasControladas As New List(Of Integer) From {1011, 1012, 1013, 1014, 1015}

    Private Sub StockForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        ConfigurarDataGridView()
        CargarProductos()
    End Sub

    Private Sub ConfigurarDataGridView()
        dgvProductos.Columns.Clear()
        dgvProductos.Rows.Clear()

        ' Columna Producto
        Dim colProducto As New DataGridViewTextBoxColumn()
        colProducto.Name = "Producto"
        colProducto.HeaderText = "PRODUCTO"
        colProducto.Width = 180
        colProducto.ReadOnly = True
        colProducto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colProducto.DefaultCellStyle.Font = New Font("Segoe UI", 13)
        colProducto.DefaultCellStyle.Padding = New Padding(10, 0, 0, 0)
        dgvProductos.Columns.Add(colProducto)

        ' Columna Stock - EDITABLE
        Dim colStock As New DataGridViewTextBoxColumn()
        colStock.Name = "Stock"
        colStock.HeaderText = "STOCK"
        colStock.Width = 80
        colStock.ReadOnly = False
        colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStock.DefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        dgvProductos.Columns.Add(colStock)
    End Sub

    Private Sub CargarProductos()
        Try
            dgvProductos.Rows.Clear()

            ' Obtener todos los productos
            Dim todosProductos As List(Of Producto) = ProductoDAO.ObtenerTodos()

            ' Filtrar por categorías controladas y ordenar alfabéticamente
            Dim productosOrdenados = todosProductos _
                .Where(Function(p) CategoriasControladas.Contains(p.IdCategoria)) _
                .OrderBy(Function(p) p.Nombre) _
                .ToList()

            ' Cargar en el DataGridView
            For Each prod As Producto In productosOrdenados
                ' Solo agregamos Nombre y Stock (2 columnas visibles)
                Dim rowIndex As Integer = dgvProductos.Rows.Add(prod.Nombre, prod.Stock)

                ' Guardamos el ID en el Tag de la fila (NO VISIBLE)
                dgvProductos.Rows(rowIndex).Tag = prod.IdProducto
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Dim productosActualizados As Integer = 0

            For Each row As DataGridViewRow In dgvProductos.Rows
                ' Obtenemos el ID desde el Tag de la fila
                Dim idProducto As Integer = CInt(row.Tag)
                Dim stockStr As String = row.Cells("Stock").Value?.ToString()

                If Not String.IsNullOrWhiteSpace(stockStr) Then
                    Dim stock As Integer = CInt(stockStr)

                    If stock < 0 Then
                        MessageBox.Show("El stock no puede ser negativo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If

                    If ProductoDAO.ActualizarStock(idProducto, stock) Then
                        productosActualizados += 1
                    End If
                End If
            Next

            MessageBox.Show($"Stock actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al actualizar stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProductos_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvProductos.CellValidating
        If dgvProductos.Columns(e.ColumnIndex).Name = "Stock" Then
            Dim nuevoValor As String = e.FormattedValue.ToString()

            If Not String.IsNullOrWhiteSpace(nuevoValor) Then
                Dim numero As Integer
                If Not Integer.TryParse(nuevoValor, numero) OrElse numero < 0 Then
                    MessageBox.Show("Ingrese un número válido (0 o mayor)", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
End Class