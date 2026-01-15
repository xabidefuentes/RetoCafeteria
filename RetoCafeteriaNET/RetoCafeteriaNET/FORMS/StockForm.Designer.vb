<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.lblDNI = New System.Windows.Forms.Label()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnActualizar
        '
        Me.btnActualizar.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Location = New System.Drawing.Point(220, 466)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(179, 48)
        Me.btnActualizar.TabIndex = 6
        Me.btnActualizar.Text = "ACTUALIZAR"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'dgvProductos
        '
        Me.dgvProductos.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Location = New System.Drawing.Point(71, 65)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.RowHeadersWidth = 51
        Me.dgvProductos.RowTemplate.Height = 24
        Me.dgvProductos.Size = New System.Drawing.Size(440, 381)
        Me.dgvProductos.TabIndex = 5
        '
        'lblDNI
        '
        Me.lblDNI.AutoSize = True
        Me.lblDNI.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDNI.Location = New System.Drawing.Point(181, 9)
        Me.lblDNI.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDNI.Name = "lblDNI"
        Me.lblDNI.Size = New System.Drawing.Size(249, 40)
        Me.lblDNI.TabIndex = 4
        Me.lblDNI.Text = "MODIFICAR STOCK"
        '
        'StockForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(582, 524)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.lblDNI)
        Me.Name = "StockForm"
        Me.Text = "Modificar Stock"
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnActualizar As Button
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents lblDNI As Label
End Class
