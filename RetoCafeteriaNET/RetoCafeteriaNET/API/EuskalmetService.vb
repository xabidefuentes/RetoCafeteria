Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Threading.Tasks

Public Class EuskalmetService

    Private Shared ReadOnly client As HttpClient = New HttpClient()

    Public Shared Async Function ObtenerDatosTiempoAsync(codigoEstacion As String) As Task(Of EuskalmetDAO)

        ' 1. Coordenadas (Muskiz/La Arena)
        Dim lat As String = "43.3496"
        Dim lon As String = "-3.1158"

        ' 2. URL Modificada: Añadimos 'weather_code' y 'time'
        Dim url As String = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,precipitation,wind_speed_10m,weather_code&timezone=Europe%2FMadrid"

        Try
            Dim respuesta As String = Await client.GetStringAsync(url)
            Dim json As JObject = JObject.Parse(respuesta)
            Dim current = json("current")

            Dim datos As New EuskalmetDAO()
            datos.stationName = "Muskiz (Open-Meteo)"

            ' Lectura de datos básicos
            datos.temperature = current("temperature_2m").ToString()
            datos.precipitation = current("precipitation").ToString()
            datos.windSpeed = current("wind_speed_10m").ToString()

            ' --- NUEVO: OBTENER FECHA Y HORA ---
            ' Open-Meteo la devuelve en formato ISO, la ponemos bonita
            Dim fechaCruda As String = current("time").ToString() ' Ej: 2026-01-22T11:00
            datos.fechaHora = DateTime.Parse(fechaCruda).ToString("dd/MM/yyyy HH:mm")

            ' --- NUEVO: TRADUCIR EL CÓDIGO A TEXTO ---
            Dim codigo As Integer = current("weather_code").Value(Of Integer)()
            datos.condicionTexto = InterpretarCodigoTiempo(codigo)

            Return datos

        Catch ex As Exception
            Throw New Exception("Error conectando con Open-Meteo: " & ex.Message)
        End Try
    End Function

    ' Esta función convierte los códigos WMO de Open-Meteo a tus 4 categorías
    Private Shared Function InterpretarCodigoTiempo(code As Integer) As String
        Select Case code
            Case 0, 1
                Return "SOLEADO" ' Despejado o mayormente despejado
            Case 2, 3, 45, 48
                Return "NUBLADO" ' Nubes o niebla
            Case 51, 53, 55, 61, 63, 65, 80, 81, 82
                Return "LLUVIOSO" ' Lluvia ligera, moderada o fuerte
            Case 71, 73, 75, 77, 85, 86
                Return "NIEVE"    ' Nieve
            Case 95, 96, 99
                Return "TORMENTA" ' Tormenta (Opcional, si no, pon LLUVIOSO)
            Case Else
                Return "NUBLADO"  ' Por defecto
        End Select
    End Function

End Class