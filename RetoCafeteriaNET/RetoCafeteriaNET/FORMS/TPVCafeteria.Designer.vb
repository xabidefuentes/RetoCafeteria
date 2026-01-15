<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TPVCafeteria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TPVCafeteria))
        Me.PanelTPV = New System.Windows.Forms.Panel()
        Me.panelIzquierda = New System.Windows.Forms.Panel()
        Me.txtDTO = New System.Windows.Forms.TextBox()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.txtUDS = New System.Windows.Forms.TextBox()
        Me.lblDTO = New System.Windows.Forms.Label()
        Me.lblUDS = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.panelInferiorIzq = New System.Windows.Forms.Panel()
        Me.PanelTeclado = New System.Windows.Forms.Panel()
        Me.btnNumCancelar = New System.Windows.Forms.Button()
        Me.btnNumConfirmar = New System.Windows.Forms.Button()
        Me.btnNum3 = New System.Windows.Forms.Button()
        Me.btnNum4 = New System.Windows.Forms.Button()
        Me.btnNum5 = New System.Windows.Forms.Button()
        Me.btnNum6 = New System.Windows.Forms.Button()
        Me.btnNum7 = New System.Windows.Forms.Button()
        Me.btnNum8 = New System.Windows.Forms.Button()
        Me.btnNum0 = New System.Windows.Forms.Button()
        Me.btnNum9 = New System.Windows.Forms.Button()
        Me.btnNum2 = New System.Windows.Forms.Button()
        Me.btnNum1 = New System.Windows.Forms.Button()
        Me.PanelInfoAcciones = New System.Windows.Forms.Panel()
        Me.btnCobrar = New System.Windows.Forms.Button()
        Me.btnAnularLinea = New System.Windows.Forms.Button()
        Me.btnAnularComanda = New System.Windows.Forms.Button()
        Me.dgvTicket = New System.Windows.Forms.DataGridView()
        Me.uds = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.btnStock = New System.Windows.Forms.Button()
        Me.btnTiempo = New System.Windows.Forms.Button()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnCambiarEmpleado = New System.Windows.Forms.Button()
        Me.lblCafeteria = New System.Windows.Forms.Label()
        Me.panelDerecha = New System.Windows.Forms.Panel()
        Me.panelProductosGrid = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelCategoriasGrid = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblProductosTitulo = New System.Windows.Forms.Label()
        Me.lblCategoriasTitulo = New System.Windows.Forms.Label()
        Me.panelLogin = New System.Windows.Forms.Panel()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.dgvEmpleados = New System.Windows.Forms.DataGridView()
        Me.lblDNI = New System.Windows.Forms.Label()
        Me.PanelTPV.SuspendLayout()
        Me.panelIzquierda.SuspendLayout()
        Me.panelInferiorIzq.SuspendLayout()
        Me.PanelTeclado.SuspendLayout()
        Me.PanelInfoAcciones.SuspendLayout()
        CType(Me.dgvTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelDerecha.SuspendLayout()
        Me.panelLogin.SuspendLayout()
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTPV
        '
        Me.PanelTPV.Controls.Add(Me.panelIzquierda)
        Me.PanelTPV.Controls.Add(Me.panelHeader)
        Me.PanelTPV.Controls.Add(Me.panelDerecha)
        Me.PanelTPV.Location = New System.Drawing.Point(0, 0)
        Me.PanelTPV.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.PanelTPV.Name = "PanelTPV"
        Me.PanelTPV.Size = New System.Drawing.Size(1545, 780)
        Me.PanelTPV.TabIndex = 0
        '
        'panelIzquierda
        '
        Me.panelIzquierda.BackColor = System.Drawing.Color.FloralWhite
        Me.panelIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelIzquierda.Controls.Add(Me.txtDTO)
        Me.panelIzquierda.Controls.Add(Me.txtSubtotal)
        Me.panelIzquierda.Controls.Add(Me.txtUDS)
        Me.panelIzquierda.Controls.Add(Me.lblDTO)
        Me.panelIzquierda.Controls.Add(Me.lblUDS)
        Me.panelIzquierda.Controls.Add(Me.lblSubtotal)
        Me.panelIzquierda.Controls.Add(Me.panelInferiorIzq)
        Me.panelIzquierda.Controls.Add(Me.dgvTicket)
        Me.panelIzquierda.Location = New System.Drawing.Point(0, 77)
        Me.panelIzquierda.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.panelIzquierda.Name = "panelIzquierda"
        Me.panelIzquierda.Size = New System.Drawing.Size(566, 706)
        Me.panelIzquierda.TabIndex = 1
        '
        'txtDTO
        '
        Me.txtDTO.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDTO.Location = New System.Drawing.Point(181, 376)
        Me.txtDTO.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtDTO.Name = "txtDTO"
        Me.txtDTO.Size = New System.Drawing.Size(66, 40)
        Me.txtDTO.TabIndex = 7
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(339, 376)
        Me.txtSubtotal.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(88, 40)
        Me.txtSubtotal.TabIndex = 6
        '
        'txtUDS
        '
        Me.txtUDS.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUDS.Location = New System.Drawing.Point(57, 376)
        Me.txtUDS.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtUDS.Name = "txtUDS"
        Me.txtUDS.Size = New System.Drawing.Size(69, 40)
        Me.txtUDS.TabIndex = 5
        '
        'lblDTO
        '
        Me.lblDTO.AutoSize = True
        Me.lblDTO.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDTO.Location = New System.Drawing.Point(133, 379)
        Me.lblDTO.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDTO.Name = "lblDTO"
        Me.lblDTO.Size = New System.Drawing.Size(52, 33)
        Me.lblDTO.TabIndex = 4
        Me.lblDTO.Text = "DTO:"
        '
        'lblUDS
        '
        Me.lblUDS.AutoSize = True
        Me.lblUDS.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUDS.Location = New System.Drawing.Point(7, 379)
        Me.lblUDS.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUDS.Name = "lblUDS"
        Me.lblUDS.Size = New System.Drawing.Size(53, 33)
        Me.lblUDS.TabIndex = 3
        Me.lblUDS.Text = "UDS:"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.Location = New System.Drawing.Point(251, 379)
        Me.lblSubtotal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(95, 33)
        Me.lblSubtotal.TabIndex = 2
        Me.lblSubtotal.Text = "Subtotal:"
        '
        'panelInferiorIzq
        '
        Me.panelInferiorIzq.BackColor = System.Drawing.Color.AliceBlue
        Me.panelInferiorIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelInferiorIzq.Controls.Add(Me.PanelTeclado)
        Me.panelInferiorIzq.Controls.Add(Me.PanelInfoAcciones)
        Me.panelInferiorIzq.Cursor = System.Windows.Forms.Cursors.Default
        Me.panelInferiorIzq.Location = New System.Drawing.Point(10, 415)
        Me.panelInferiorIzq.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.panelInferiorIzq.Name = "panelInferiorIzq"
        Me.panelInferiorIzq.Size = New System.Drawing.Size(555, 283)
        Me.panelInferiorIzq.TabIndex = 1
        '
        'PanelTeclado
        '
        Me.PanelTeclado.Controls.Add(Me.btnNumCancelar)
        Me.PanelTeclado.Controls.Add(Me.btnNumConfirmar)
        Me.PanelTeclado.Controls.Add(Me.btnNum3)
        Me.PanelTeclado.Controls.Add(Me.btnNum4)
        Me.PanelTeclado.Controls.Add(Me.btnNum5)
        Me.PanelTeclado.Controls.Add(Me.btnNum6)
        Me.PanelTeclado.Controls.Add(Me.btnNum7)
        Me.PanelTeclado.Controls.Add(Me.btnNum8)
        Me.PanelTeclado.Controls.Add(Me.btnNum0)
        Me.PanelTeclado.Controls.Add(Me.btnNum9)
        Me.PanelTeclado.Controls.Add(Me.btnNum2)
        Me.PanelTeclado.Controls.Add(Me.btnNum1)
        Me.PanelTeclado.Location = New System.Drawing.Point(3, 4)
        Me.PanelTeclado.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.PanelTeclado.Name = "PanelTeclado"
        Me.PanelTeclado.Size = New System.Drawing.Size(205, 271)
        Me.PanelTeclado.TabIndex = 0
        '
        'btnNumCancelar
        '
        Me.btnNumCancelar.BackColor = System.Drawing.Color.LightCoral
        Me.btnNumCancelar.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNumCancelar.Location = New System.Drawing.Point(6, 206)
        Me.btnNumCancelar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNumCancelar.Name = "btnNumCancelar"
        Me.btnNumCancelar.Size = New System.Drawing.Size(60, 60)
        Me.btnNumCancelar.TabIndex = 11
        Me.btnNumCancelar.Text = "X"
        Me.btnNumCancelar.UseVisualStyleBackColor = False
        '
        'btnNumConfirmar
        '
        Me.btnNumConfirmar.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnNumConfirmar.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNumConfirmar.Location = New System.Drawing.Point(134, 206)
        Me.btnNumConfirmar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNumConfirmar.Name = "btnNumConfirmar"
        Me.btnNumConfirmar.Size = New System.Drawing.Size(60, 60)
        Me.btnNumConfirmar.TabIndex = 10
        Me.btnNumConfirmar.Text = "✓"
        Me.btnNumConfirmar.UseVisualStyleBackColor = False
        '
        'btnNum3
        '
        Me.btnNum3.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum3.Location = New System.Drawing.Point(134, 4)
        Me.btnNum3.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum3.Name = "btnNum3"
        Me.btnNum3.Size = New System.Drawing.Size(60, 60)
        Me.btnNum3.TabIndex = 9
        Me.btnNum3.Text = "3"
        Me.btnNum3.UseVisualStyleBackColor = True
        '
        'btnNum4
        '
        Me.btnNum4.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum4.Location = New System.Drawing.Point(6, 73)
        Me.btnNum4.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum4.Name = "btnNum4"
        Me.btnNum4.Size = New System.Drawing.Size(60, 60)
        Me.btnNum4.TabIndex = 8
        Me.btnNum4.Text = "4"
        Me.btnNum4.UseVisualStyleBackColor = True
        '
        'btnNum5
        '
        Me.btnNum5.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum5.Location = New System.Drawing.Point(70, 73)
        Me.btnNum5.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum5.Name = "btnNum5"
        Me.btnNum5.Size = New System.Drawing.Size(60, 60)
        Me.btnNum5.TabIndex = 7
        Me.btnNum5.Text = "5"
        Me.btnNum5.UseVisualStyleBackColor = True
        '
        'btnNum6
        '
        Me.btnNum6.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum6.Location = New System.Drawing.Point(134, 73)
        Me.btnNum6.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum6.Name = "btnNum6"
        Me.btnNum6.Size = New System.Drawing.Size(60, 60)
        Me.btnNum6.TabIndex = 6
        Me.btnNum6.Text = "6"
        Me.btnNum6.UseVisualStyleBackColor = True
        '
        'btnNum7
        '
        Me.btnNum7.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum7.Location = New System.Drawing.Point(6, 138)
        Me.btnNum7.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum7.Name = "btnNum7"
        Me.btnNum7.Size = New System.Drawing.Size(60, 60)
        Me.btnNum7.TabIndex = 5
        Me.btnNum7.Text = "7"
        Me.btnNum7.UseVisualStyleBackColor = True
        '
        'btnNum8
        '
        Me.btnNum8.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum8.Location = New System.Drawing.Point(70, 138)
        Me.btnNum8.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum8.Name = "btnNum8"
        Me.btnNum8.Size = New System.Drawing.Size(60, 60)
        Me.btnNum8.TabIndex = 4
        Me.btnNum8.Text = "8"
        Me.btnNum8.UseVisualStyleBackColor = True
        '
        'btnNum0
        '
        Me.btnNum0.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum0.Location = New System.Drawing.Point(70, 206)
        Me.btnNum0.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum0.Name = "btnNum0"
        Me.btnNum0.Size = New System.Drawing.Size(60, 60)
        Me.btnNum0.TabIndex = 3
        Me.btnNum0.Text = "0"
        Me.btnNum0.UseVisualStyleBackColor = True
        '
        'btnNum9
        '
        Me.btnNum9.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum9.Location = New System.Drawing.Point(134, 138)
        Me.btnNum9.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum9.Name = "btnNum9"
        Me.btnNum9.Size = New System.Drawing.Size(60, 60)
        Me.btnNum9.TabIndex = 2
        Me.btnNum9.Text = "9"
        Me.btnNum9.UseVisualStyleBackColor = True
        '
        'btnNum2
        '
        Me.btnNum2.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum2.Location = New System.Drawing.Point(70, 4)
        Me.btnNum2.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum2.Name = "btnNum2"
        Me.btnNum2.Size = New System.Drawing.Size(60, 60)
        Me.btnNum2.TabIndex = 1
        Me.btnNum2.Text = "2"
        Me.btnNum2.UseVisualStyleBackColor = True
        '
        'btnNum1
        '
        Me.btnNum1.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNum1.Location = New System.Drawing.Point(6, 4)
        Me.btnNum1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNum1.Name = "btnNum1"
        Me.btnNum1.Size = New System.Drawing.Size(60, 60)
        Me.btnNum1.TabIndex = 0
        Me.btnNum1.Text = "1"
        Me.btnNum1.UseVisualStyleBackColor = True
        '
        'PanelInfoAcciones
        '
        Me.PanelInfoAcciones.Controls.Add(Me.btnCobrar)
        Me.PanelInfoAcciones.Controls.Add(Me.btnAnularLinea)
        Me.PanelInfoAcciones.Controls.Add(Me.btnAnularComanda)
        Me.PanelInfoAcciones.Location = New System.Drawing.Point(220, 8)
        Me.PanelInfoAcciones.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.PanelInfoAcciones.Name = "PanelInfoAcciones"
        Me.PanelInfoAcciones.Size = New System.Drawing.Size(331, 271)
        Me.PanelInfoAcciones.TabIndex = 1
        '
        'btnCobrar
        '
        Me.btnCobrar.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCobrar.Location = New System.Drawing.Point(2, 93)
        Me.btnCobrar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(327, 70)
        Me.btnCobrar.TabIndex = 2
        Me.btnCobrar.Text = "COBRAR"
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'btnAnularLinea
        '
        Me.btnAnularLinea.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnularLinea.Location = New System.Drawing.Point(2, 4)
        Me.btnAnularLinea.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnAnularLinea.Name = "btnAnularLinea"
        Me.btnAnularLinea.Size = New System.Drawing.Size(327, 81)
        Me.btnAnularLinea.TabIndex = 1
        Me.btnAnularLinea.Text = "ANULAR LINEA"
        Me.btnAnularLinea.UseVisualStyleBackColor = True
        '
        'btnAnularComanda
        '
        Me.btnAnularComanda.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnularComanda.Location = New System.Drawing.Point(2, 171)
        Me.btnAnularComanda.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnAnularComanda.Name = "btnAnularComanda"
        Me.btnAnularComanda.Size = New System.Drawing.Size(327, 86)
        Me.btnAnularComanda.TabIndex = 0
        Me.btnAnularComanda.Text = "ANULAR COMANDA"
        Me.btnAnularComanda.UseVisualStyleBackColor = True
        '
        'dgvTicket
        '
        Me.dgvTicket.AllowUserToAddRows = False
        Me.dgvTicket.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTicket.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.uds, Me.descripcion, Me.precio, Me.dto, Me.total})
        Me.dgvTicket.Location = New System.Drawing.Point(-16, -1)
        Me.dgvTicket.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.dgvTicket.Name = "dgvTicket"
        Me.dgvTicket.RowHeadersWidth = 51
        Me.dgvTicket.RowTemplate.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.dgvTicket.RowTemplate.Height = 24
        Me.dgvTicket.Size = New System.Drawing.Size(642, 371)
        Me.dgvTicket.TabIndex = 0
        '
        'uds
        '
        Me.uds.HeaderText = "UDS"
        Me.uds.MinimumWidth = 6
        Me.uds.Name = "uds"
        Me.uds.Width = 60
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.MinimumWidth = 6
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Width = 210
        '
        'precio
        '
        Me.precio.HeaderText = "Precio"
        Me.precio.MinimumWidth = 6
        Me.precio.Name = "precio"
        Me.precio.Width = 80
        '
        'dto
        '
        Me.dto.HeaderText = "DTO"
        Me.dto.MinimumWidth = 6
        Me.dto.Name = "dto"
        Me.dto.Width = 60
        '
        'total
        '
        Me.total.HeaderText = "Total"
        Me.total.MinimumWidth = 6
        Me.total.Name = "total"
        Me.total.Width = 120
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.PowderBlue
        Me.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelHeader.Controls.Add(Me.btnStock)
        Me.panelHeader.Controls.Add(Me.btnTiempo)
        Me.panelHeader.Controls.Add(Me.lblUsuario)
        Me.panelHeader.Controls.Add(Me.PictureBox2)
        Me.panelHeader.Controls.Add(Me.btnCambiarEmpleado)
        Me.panelHeader.Controls.Add(Me.lblCafeteria)
        Me.panelHeader.Location = New System.Drawing.Point(1, 0)
        Me.panelHeader.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1535, 69)
        Me.panelHeader.TabIndex = 0
        '
        'btnStock
        '
        Me.btnStock.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStock.Location = New System.Drawing.Point(547, 12)
        Me.btnStock.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnStock.Name = "btnStock"
        Me.btnStock.Size = New System.Drawing.Size(191, 44)
        Me.btnStock.TabIndex = 6
        Me.btnStock.Text = "STOCK"
        Me.btnStock.UseVisualStyleBackColor = True
        '
        'btnTiempo
        '
        Me.btnTiempo.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTiempo.Location = New System.Drawing.Point(338, 12)
        Me.btnTiempo.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnTiempo.Name = "btnTiempo"
        Me.btnTiempo.Size = New System.Drawing.Size(191, 44)
        Me.btnTiempo.TabIndex = 5
        Me.btnTiempo.Text = "Meteorologia"
        Me.btnTiempo.UseVisualStyleBackColor = True
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(1129, 18)
        Me.lblUsuario.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(94, 33)
        Me.lblUsuario.TabIndex = 4
        Me.lblUsuario.Text = "Usuario"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.InitialImage = CType(resources.GetObject("PictureBox2.InitialImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(13, -1)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 69)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'btnCambiarEmpleado
        '
        Me.btnCambiarEmpleado.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiarEmpleado.Location = New System.Drawing.Point(1329, 12)
        Me.btnCambiarEmpleado.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnCambiarEmpleado.Name = "btnCambiarEmpleado"
        Me.btnCambiarEmpleado.Size = New System.Drawing.Size(191, 44)
        Me.btnCambiarEmpleado.TabIndex = 2
        Me.btnCambiarEmpleado.Text = "Cambiar Empleado"
        Me.btnCambiarEmpleado.UseVisualStyleBackColor = True
        '
        'lblCafeteria
        '
        Me.lblCafeteria.AutoSize = True
        Me.lblCafeteria.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCafeteria.Location = New System.Drawing.Point(75, 12)
        Me.lblCafeteria.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCafeteria.Name = "lblCafeteria"
        Me.lblCafeteria.Size = New System.Drawing.Size(232, 48)
        Me.lblCafeteria.TabIndex = 0
        Me.lblCafeteria.Text = "Café Gaupasa"
        '
        'panelDerecha
        '
        Me.panelDerecha.BackColor = System.Drawing.Color.FloralWhite
        Me.panelDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelDerecha.Controls.Add(Me.panelProductosGrid)
        Me.panelDerecha.Controls.Add(Me.panelCategoriasGrid)
        Me.panelDerecha.Controls.Add(Me.lblProductosTitulo)
        Me.panelDerecha.Controls.Add(Me.lblCategoriasTitulo)
        Me.panelDerecha.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelDerecha.Location = New System.Drawing.Point(570, 77)
        Me.panelDerecha.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.panelDerecha.Name = "panelDerecha"
        Me.panelDerecha.Size = New System.Drawing.Size(966, 731)
        Me.panelDerecha.TabIndex = 2
        '
        'panelProductosGrid
        '
        Me.panelProductosGrid.BackColor = System.Drawing.Color.AliceBlue
        Me.panelProductosGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelProductosGrid.Location = New System.Drawing.Point(20, 327)
        Me.panelProductosGrid.Name = "panelProductosGrid"
        Me.panelProductosGrid.Size = New System.Drawing.Size(925, 349)
        Me.panelProductosGrid.TabIndex = 5
        '
        'panelCategoriasGrid
        '
        Me.panelCategoriasGrid.BackColor = System.Drawing.Color.AliceBlue
        Me.panelCategoriasGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelCategoriasGrid.Location = New System.Drawing.Point(20, 36)
        Me.panelCategoriasGrid.Name = "panelCategoriasGrid"
        Me.panelCategoriasGrid.Size = New System.Drawing.Size(924, 256)
        Me.panelCategoriasGrid.TabIndex = 4
        '
        'lblProductosTitulo
        '
        Me.lblProductosTitulo.AutoSize = True
        Me.lblProductosTitulo.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductosTitulo.Location = New System.Drawing.Point(433, 295)
        Me.lblProductosTitulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProductosTitulo.Name = "lblProductosTitulo"
        Me.lblProductosTitulo.Size = New System.Drawing.Size(126, 29)
        Me.lblProductosTitulo.TabIndex = 2
        Me.lblProductosTitulo.Text = "PRODUCTOS"
        '
        'lblCategoriasTitulo
        '
        Me.lblCategoriasTitulo.AutoSize = True
        Me.lblCategoriasTitulo.Font = New System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriasTitulo.Location = New System.Drawing.Point(433, 5)
        Me.lblCategoriasTitulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCategoriasTitulo.Name = "lblCategoriasTitulo"
        Me.lblCategoriasTitulo.Size = New System.Drawing.Size(129, 29)
        Me.lblCategoriasTitulo.TabIndex = 0
        Me.lblCategoriasTitulo.Text = "CATEGORIAS"
        '
        'panelLogin
        '
        Me.panelLogin.BackColor = System.Drawing.Color.FloralWhite
        Me.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelLogin.Controls.Add(Me.btnSeleccionar)
        Me.panelLogin.Controls.Add(Me.dgvEmpleados)
        Me.panelLogin.Controls.Add(Me.lblDNI)
        Me.panelLogin.Location = New System.Drawing.Point(503, 146)
        Me.panelLogin.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.Size = New System.Drawing.Size(522, 552)
        Me.panelLogin.TabIndex = 10
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionar.Location = New System.Drawing.Point(191, 475)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(127, 48)
        Me.btnSeleccionar.TabIndex = 3
        Me.btnSeleccionar.Text = "ENTRAR"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'dgvEmpleados
        '
        Me.dgvEmpleados.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleados.Location = New System.Drawing.Point(42, 74)
        Me.dgvEmpleados.Name = "dgvEmpleados"
        Me.dgvEmpleados.RowHeadersWidth = 51
        Me.dgvEmpleados.RowTemplate.Height = 24
        Me.dgvEmpleados.Size = New System.Drawing.Size(440, 381)
        Me.dgvEmpleados.TabIndex = 2
        '
        'lblDNI
        '
        Me.lblDNI.AutoSize = True
        Me.lblDNI.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDNI.Location = New System.Drawing.Point(121, 19)
        Me.lblDNI.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDNI.Name = "lblDNI"
        Me.lblDNI.Size = New System.Drawing.Size(344, 40)
        Me.lblDNI.TabIndex = 1
        Me.lblDNI.Text = "SELECCIONAR EMPLEADO"
        '
        'TPVCafeteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1541, 766)
        Me.Controls.Add(Me.panelLogin)
        Me.Controls.Add(Me.PanelTPV)
        Me.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "TPVCafeteria"
        Me.Text = "TPV Café Gaupasa"
        Me.PanelTPV.ResumeLayout(False)
        Me.panelIzquierda.ResumeLayout(False)
        Me.panelIzquierda.PerformLayout()
        Me.panelInferiorIzq.ResumeLayout(False)
        Me.PanelTeclado.ResumeLayout(False)
        Me.PanelInfoAcciones.ResumeLayout(False)
        CType(Me.dgvTicket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelDerecha.ResumeLayout(False)
        Me.panelDerecha.PerformLayout()
        Me.panelLogin.ResumeLayout(False)
        Me.panelLogin.PerformLayout()
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTPV As Panel
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelIzquierda As Panel
    Friend WithEvents dgvTicket As DataGridView
    Friend WithEvents panelInferiorIzq As Panel
    Friend WithEvents PanelInfoAcciones As Panel
    Friend WithEvents PanelTeclado As Panel
    Friend WithEvents btnNum2 As Button
    Friend WithEvents btnNum1 As Button
    Friend WithEvents btnNumCancelar As Button
    Friend WithEvents btnNumConfirmar As Button
    Friend WithEvents btnNum3 As Button
    Friend WithEvents btnNum4 As Button
    Friend WithEvents btnNum5 As Button
    Friend WithEvents btnNum6 As Button
    Friend WithEvents btnNum7 As Button
    Friend WithEvents btnNum8 As Button
    Friend WithEvents btnNum0 As Button
    Friend WithEvents btnNum9 As Button
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblDTO As Label
    Friend WithEvents lblUDS As Label
    Friend WithEvents txtDTO As TextBox
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents txtUDS As TextBox
    Friend WithEvents panelDerecha As Panel
    Friend WithEvents lblCategoriasTitulo As Label
    Friend WithEvents lblProductosTitulo As Label
    Friend WithEvents btnCambiarEmpleado As Button
    Friend WithEvents lblCafeteria As Label
    Friend WithEvents btnCobrar As Button
    Friend WithEvents btnAnularLinea As Button
    Friend WithEvents btnAnularComanda As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents panelCategoriasGrid As FlowLayoutPanel
    Friend WithEvents panelProductosGrid As FlowLayoutPanel
    Friend WithEvents btnStock As Button
    Friend WithEvents btnTiempo As Button
    Friend WithEvents panelLogin As Panel
    Friend WithEvents btnSeleccionar As Button
    Friend WithEvents dgvEmpleados As DataGridView
    Friend WithEvents lblDNI As Label
    Friend WithEvents uds As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents precio As DataGridViewTextBoxColumn
    Friend WithEvents dto As DataGridViewTextBoxColumn
    Friend WithEvents total As DataGridViewTextBoxColumn
End Class
