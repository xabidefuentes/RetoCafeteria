<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuEmpleados
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
        Me.panelLogin = New System.Windows.Forms.Panel()
        Me.lblDNI = New System.Windows.Forms.Label()
        Me.panelLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelLogin
        '
        Me.panelLogin.Controls.Add(Me.lblDNI)
        Me.panelLogin.Location = New System.Drawing.Point(1, 0)
        Me.panelLogin.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.Size = New System.Drawing.Size(522, 577)
        Me.panelLogin.TabIndex = 9
        '
        'lblDNI
        '
        Me.lblDNI.AutoSize = True
        Me.lblDNI.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDNI.Location = New System.Drawing.Point(96, 55)
        Me.lblDNI.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDNI.Name = "lblDNI"
        Me.lblDNI.Size = New System.Drawing.Size(253, 29)
        Me.lblDNI.TabIndex = 1
        Me.lblDNI.Text = "SELECCIONAR EMPLEADO"
        '
        'MenuEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(524, 580)
        Me.Controls.Add(Me.panelLogin)
        Me.Name = "MenuEmpleados"
        Me.Text = "Login"
        Me.panelLogin.ResumeLayout(False)
        Me.panelLogin.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelLogin As Panel
    Friend WithEvents lblDNI As Label
End Class
