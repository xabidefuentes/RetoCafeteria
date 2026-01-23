Imports System.IO
Imports System.Xml.Serialization

Public Class EuskalmetForm

    Private Async Sub EuskalmetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' 1. LLAMADA AL SERVICIO
            Dim resultado As EuskalmetDAO = Await EuskalmetService.ObtenerDatosTiempoAsync("Muskiz")

            ' 2. MOSTRAR DATOS BÁSICOS
            lblTemp.Text = $"Temp: {resultado.temperature} ºC"
            lblLluvia.Text = $"Lluvia: {resultado.precipitation} mm"
            lblViento.Text = $"Viento: {resultado.windSpeed} km/h"

            ' Etiquetas nuevas
            lblLugar.Text = resultado.stationName
            lblFecha.Text = resultado.fechaHora
            lblCondicionTexto.Text = resultado.condicionTexto

            ' 3. CONVERTIR DATOS A NÚMEROS
            Dim temp As Double = Convert.ToDouble(resultado.temperature)
            Dim estado As String = resultado.condicionTexto
            Dim viento As Double = Convert.ToDouble(resultado.windSpeed)

            ' A) Parte 1: TOLDOS
            Dim fraseToldos As String
            If estado.Equals("SOLEADO") Then
                fraseToldos = "Abre toldos"
            Else
                fraseToldos = "Cierra toldos"
            End If

            ' B) Parte 2: ESTUFA
            Dim fraseEstufa As String
            If temp < 15 Then
                fraseEstufa = "enciende estufa"
            Else
                fraseEstufa = "apaga estufa"
            End If

            ' C) Parte 3: ASPERSORES
            Dim fraseCalor As String
            If temp > 30 Then
                fraseCalor = "enciende aspersores"
            Else

                fraseCalor = "apaga aspersores"
            End If

            ' D) Parte 4: CORTAVIENTOS
            Dim fraseViento As String
            If viento > 20 Then
                fraseViento = "abre cortavientos"
            Else
                fraseViento = "cierra cortavientos"
            End If

            ' FINAL: Unimos todo
            lblOrden.Text = $"{fraseToldos}, {fraseEstufa}, {fraseCalor} y {fraseViento}"

            ' 4. COLORES (Visual)
            If temp < 10 Then
                lblTemp.ForeColor = Color.Blue
            ElseIf temp > 25 Then
                lblTemp.ForeColor = Color.Red
            Else
                lblTemp.ForeColor = Color.Black
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' ---------------------------------------------------------
    ' BOTÓN 1: DESCARGAR XML
    ' ---------------------------------------------------------
    Private Async Sub btnXml_Click(sender As Object, e As EventArgs) Handles btnXml.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim datos As EuskalmetDAO = Await EuskalmetService.ObtenerDatosTiempoAsync("Muskiz")

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Archivo XML|*.xml"
            saveFileDialog.FileName = "prevision_muskiz.xml"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim serializador As New XmlSerializer(GetType(EuskalmetDAO))
                Using writer As New StreamWriter(saveFileDialog.FileName)
                    serializador.Serialize(writer, datos)
                End Using
                MessageBox.Show("XML descargado correctamente.", "Éxito")
            End If
        Catch ex As Exception
            MessageBox.Show("Error XML: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ---------------------------------------------------------
    ' BOTÓN 2: SUBIR A DRIVE
    ' ---------------------------------------------------------
    ' ---------------------------------------------------------
    ' BOTÓN 2: GUARDAR TXT EN RUTA ESPECÍFICA DE DRIVE (G:)
    ' ---------------------------------------------------------
    Private Async Sub btnDrive_Click(sender As Object, e As EventArgs) Handles btnDrive.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ' 1. OBTENER DATOS
            Dim datos As EuskalmetDAO = Await EuskalmetService.ObtenerDatosTiempoAsync("Muskiz")

            ' 2. PREPARAR LA RUTA EXACTA
            Dim carpetaDestino As String = "G:\Mi unidad\RetoCafeteria\RMI"

            ' Importante: Si la carpeta no existe, la creamos automáticamente
            If Not Directory.Exists(carpetaDestino) Then
                Directory.CreateDirectory(carpetaDestino)
            End If

            ' 3. DEFINIR NOMBRE DEL ARCHIVO (Ej: Informe_Muskiz_20260123.txt)
            Dim nombreArchivo As String = $"Informe_{datos.stationName}.txt"
            Dim rutaFinal As String = Path.Combine(carpetaDestino, nombreArchivo)

            ' 4. ESCRIBIR EL INFORME (Formato TXT)
            Using writer As New StreamWriter(rutaFinal)
                writer.WriteLine("========================================")
                writer.WriteLine("       INFORME METEOROLÓGICO            ")
                writer.WriteLine("========================================")
                writer.WriteLine($"FECHA:       {datos.fechaHora}")
                writer.WriteLine($"LUGAR:       {datos.stationName}")
                writer.WriteLine("----------------------------------------")
                writer.WriteLine($"ESTADO:      {datos.condicionTexto}")
                writer.WriteLine("----------------------------------------")
                writer.WriteLine($"Temperatura: {datos.temperature} ºC")
                writer.WriteLine($"Lluvia:      {datos.precipitation} mm")
                writer.WriteLine($"Viento:      {datos.windSpeed} km/h")
                writer.WriteLine("========================================")
            End Using

            MessageBox.Show($"Archivo TXT guardado correctamente en Drive", "Drive Sincronizado")

        Catch ex As Exception
            MessageBox.Show("Error al guardar en Drive: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ---------------------------------------------------------
    ' BOTÓN 3: DESCARGAR TXT
    ' ---------------------------------------------------------
    Private Async Sub btnTxt_Click(sender As Object, e As EventArgs) Handles btnTxt.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim datos As EuskalmetDAO = Await EuskalmetService.ObtenerDatosTiempoAsync("Muskiz")

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Informe Texto|*.txt"
            saveFileDialog.FileName = $"Informe_{datos.stationName}.txt"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Using writer As New StreamWriter(saveFileDialog.FileName)
                    writer.WriteLine("========================================")
                    writer.WriteLine("       INFORME METEOROLÓGICO            ")
                    writer.WriteLine("========================================")
                    writer.WriteLine($"FECHA:       {datos.fechaHora}")
                    writer.WriteLine($"LUGAR:       {datos.stationName}")
                    writer.WriteLine("----------------------------------------")
                    writer.WriteLine($"ESTADO:      {datos.condicionTexto}")
                    writer.WriteLine("----------------------------------------")
                    writer.WriteLine($"Temperatura: {datos.temperature} ºC")
                    writer.WriteLine($"Lluvia:      {datos.precipitation} mm")
                    writer.WriteLine($"Viento:      {datos.windSpeed} km/h")
                    writer.WriteLine("========================================")
                End Using
                MessageBox.Show("TXT generado correctamente.", "Éxito")
            End If

        Catch ex As Exception
            MessageBox.Show("Error TXT: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class