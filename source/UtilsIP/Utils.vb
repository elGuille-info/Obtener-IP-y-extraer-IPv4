'------------------------------------------------------------------------------
' UtilsIP                                                           (01/Sep/21)
' Obtener las IPs del usuario
' Extraer de una cadena las direcciones IPv4
'
' Usando la expresión regular para las IPv4 de:
' https://programmerclick.com/article/29011265391
'
' (c) Guillermo Som (Guille), 2021
'------------------------------------------------------------------------------
Imports System
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions


Public Class Utils
    ''' <summary>
    ''' Devuelve una cadena con todas las direcciones IPv4 de la cadena indicada.
    ''' </summary>
    ''' <param name="ipAdresses">Cadena con las IPs IPv4 y otras a no tener en cuenta.</param>
    ''' <returns>Una cadena con las IPs de tipo IPv4 de la cadena indicada.</returns>
    Public Shared Function LasIPv4(ipAdresses As String) As String
        Dim sb As New StringBuilder()

        Dim sRegExIPv4 As String = "((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)"
        Dim r As Regex = New Regex(sRegExIPv4)

        For Each m As Match In r.Matches(ipAdresses)
            If m.Success Then
                sb.Append($"{m.Value}, ")
            End If
        Next

        Return sb.ToString().TrimEnd(", ".ToCharArray())
    End Function

    ''' <summary>
    ''' Devuelve las IPs del equipo actual.
    ''' </summary>
    ''' <returns>Una cadena con las direcciones IP, sean IPv6 o IPv6.</returns>
    Public Shared Function ObtenerIPs()

        Dim sb As New StringBuilder()
        Dim ipAddresses As String

        Try
            Dim hostName = Dns.GetHostName()
            Dim addresses As IPAddress() = Dns.GetHostAddresses(hostName)

            For Each address As IPAddress In addresses
                sb.Append($"{address}, ")
            Next

            ipAddresses = sb.ToString().TrimEnd(", ".ToCharArray())
        Catch ex As Exception
            ipAddresses = "ERROR: " & ex.Message
        End Try
        Return ipAddresses
    End Function
End Class
