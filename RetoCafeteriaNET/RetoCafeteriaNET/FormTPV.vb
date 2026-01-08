Imports System.Drawing
Imports System.Windows.Forms

Public Class TPVCafeteria

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
        Me.WindowState = FormWindowState.Maximized
        Me.AutoScaleMode = AutoScaleMode.Dpi

    End Sub

    Private Sub panelLogin_Paint(sender As Object, e As PaintEventArgs) Handles panelLogin.Paint

    End Sub

    Private Sub panelDerecha_Paint(sender As Object, e As PaintEventArgs) Handles panelDerecha.Paint

    End Sub

    Private Sub PanelTPV_Paint(sender As Object, e As PaintEventArgs) Handles PanelTPV.Paint

    End Sub

    Private Sub panelInferiorIzq_Paint(sender As Object, e As PaintEventArgs) Handles panelInferiorIzq.Paint

    End Sub

    Private Sub lblDNI_Click(sender As Object, e As EventArgs) Handles lblDNI.Click

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub btnNumConfirmar_Click(sender As Object, e As EventArgs) Handles btnNumConfirmar.Click

    End Sub

    Private Sub dgvTicket_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTicket.CellContentClick

    End Sub
End Class