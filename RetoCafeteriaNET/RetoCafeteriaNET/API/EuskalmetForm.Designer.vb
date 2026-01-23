<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EuskalmetForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EuskalmetForm))
        Me.lblTemp = New System.Windows.Forms.Label()
        Me.lblViento = New System.Windows.Forms.Label()
        Me.lblLluvia = New System.Windows.Forms.Label()
        Me.btnXml = New System.Windows.Forms.Button()
        Me.btnDrive = New System.Windows.Forms.Button()
        Me.btnTxt = New System.Windows.Forms.Button()
        Me.lblCondicionTexto = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblLugar = New System.Windows.Forms.Label()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'lblTemp
        '
        Me.lblTemp.AutoSize = True
        Me.lblTemp.BackColor = System.Drawing.Color.AliceBlue
        Me.lblTemp.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemp.Location = New System.Drawing.Point(67, 149)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(82, 34)
        Me.lblTemp.TabIndex = 2
        Me.lblTemp.Text = "Label1"
        '
        'lblViento
        '
        Me.lblViento.AutoSize = True
        Me.lblViento.BackColor = System.Drawing.Color.AliceBlue
        Me.lblViento.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViento.Location = New System.Drawing.Point(315, 149)
        Me.lblViento.Name = "lblViento"
        Me.lblViento.Size = New System.Drawing.Size(82, 34)
        Me.lblViento.TabIndex = 3
        Me.lblViento.Text = "Label1"
        '
        'lblLluvia
        '
        Me.lblLluvia.AutoSize = True
        Me.lblLluvia.BackColor = System.Drawing.Color.AliceBlue
        Me.lblLluvia.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLluvia.Location = New System.Drawing.Point(573, 149)
        Me.lblLluvia.Name = "lblLluvia"
        Me.lblLluvia.Size = New System.Drawing.Size(87, 34)
        Me.lblLluvia.TabIndex = 4
        Me.lblLluvia.Text = "Label2"
        '
        'btnXml
        '
        Me.btnXml.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXml.Location = New System.Drawing.Point(38, 340)
        Me.btnXml.Name = "btnXml"
        Me.btnXml.Size = New System.Drawing.Size(189, 42)
        Me.btnXml.TabIndex = 5
        Me.btnXml.Text = "DESCARGAR XML"
        Me.btnXml.UseVisualStyleBackColor = True
        '
        'btnDrive
        '
        Me.btnDrive.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDrive.Location = New System.Drawing.Point(526, 340)
        Me.btnDrive.Name = "btnDrive"
        Me.btnDrive.Size = New System.Drawing.Size(238, 42)
        Me.btnDrive.TabIndex = 6
        Me.btnDrive.Text = "SUBIR A GOOGLE DRIVE"
        Me.btnDrive.UseVisualStyleBackColor = True
        '
        'btnTxt
        '
        Me.btnTxt.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTxt.Location = New System.Drawing.Point(289, 340)
        Me.btnTxt.Name = "btnTxt"
        Me.btnTxt.Size = New System.Drawing.Size(183, 42)
        Me.btnTxt.TabIndex = 7
        Me.btnTxt.Text = "DESCARGAR TXT"
        Me.btnTxt.UseVisualStyleBackColor = True
        '
        'lblCondicionTexto
        '
        Me.lblCondicionTexto.AutoSize = True
        Me.lblCondicionTexto.BackColor = System.Drawing.Color.AliceBlue
        Me.lblCondicionTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCondicionTexto.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondicionTexto.Location = New System.Drawing.Point(626, 33)
        Me.lblCondicionTexto.Name = "lblCondicionTexto"
        Me.lblCondicionTexto.Size = New System.Drawing.Size(95, 38)
        Me.lblCondicionTexto.TabIndex = 8
        Me.lblCondicionTexto.Text = "Label2"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(57, 33)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(95, 38)
        Me.lblFecha.TabIndex = 9
        Me.lblFecha.Text = "Label2"
        '
        'lblLugar
        '
        Me.lblLugar.AutoSize = True
        Me.lblLugar.BackColor = System.Drawing.Color.AliceBlue
        Me.lblLugar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLugar.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLugar.Location = New System.Drawing.Point(308, 33)
        Me.lblLugar.Name = "lblLugar"
        Me.lblLugar.Size = New System.Drawing.Size(95, 38)
        Me.lblLugar.TabIndex = 10
        Me.lblLugar.Text = "Label2"
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.BackColor = System.Drawing.Color.AliceBlue
        Me.lblOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrden.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.Location = New System.Drawing.Point(48, 257)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(75, 30)
        Me.lblOrden.TabIndex = 11
        Me.lblOrden.Text = "Label2"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(38, 114)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(726, 100)
        Me.Panel1.TabIndex = 12
        '
        'EuskalmetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.lblLugar)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblCondicionTexto)
        Me.Controls.Add(Me.btnTxt)
        Me.Controls.Add(Me.btnDrive)
        Me.Controls.Add(Me.btnXml)
        Me.Controls.Add(Me.lblLluvia)
        Me.Controls.Add(Me.lblViento)
        Me.Controls.Add(Me.lblTemp)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EuskalmetForm"
        Me.Text = "Meteorologia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTemp As Label
    Friend WithEvents lblViento As Label
    Friend WithEvents lblLluvia As Label
    Friend WithEvents btnXml As Button
    Friend WithEvents btnDrive As Button
    Friend WithEvents btnTxt As Button
    Friend WithEvents lblCondicionTexto As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblLugar As Label
    Friend WithEvents lblOrden As Label
    Friend WithEvents Panel1 As Panel
End Class
