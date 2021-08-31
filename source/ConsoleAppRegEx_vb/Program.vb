'------------------------------------------------------------------------------
' Utils.LasIPv4                                                     (30/Ago/21)
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

Module Program
    Sub Main(args As String())
        'Console.WriteLine("Hello World!")
        Console.WriteLine("Ejemplo en Visual Basic usando .NET 5.0 para obtener las IPs y extraer con RegEx solo las IPv4.")
        Console.WriteLine()

        Dim ipAdresses As String = Utils.ObtenerIPs()

        Console.WriteLine("La cadena con todas las IPs:")
        Console.WriteLine(ipAdresses)
        Dim ret As String = Utils.LasIPv4(ipAdresses)

        Console.WriteLine()
        Console.WriteLine("Direcciones IPv4:")
        Console.WriteLine(ret)

        Console.WriteLine()
        Console.WriteLine("Pulsa INTRO para terminar.")
        Console.ReadLine()
    End Sub

    Sub MainUsandoModule()
        Console.WriteLine("Ejemplo en Visual Basic usando .NET 5.0 para obtener las IPs y extraer con RegEx solo las IPv4.")
        Console.WriteLine()

        Dim ipAdresses As String = UtilsModule.ObtenerIPs()

        Console.WriteLine("La cadena con todas las IPs:")
        Console.WriteLine(ipAdresses)
        Dim ret As String = UtilsModule.LasIPv4(ipAdresses)

        Console.WriteLine()
        Console.WriteLine("Direcciones IPv4:")
        Console.WriteLine(ret)

        Console.WriteLine()
        Console.WriteLine("Pulsa INTRO para terminar.")
        Console.ReadLine()

    End Sub
End Module

Class Utils
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

Module UtilsModule
    ''' <summary>
    ''' Devuelve una cadena con todas las direcciones IPv4 de la cadena indicada.
    ''' </summary>
    ''' <param name="ipAdresses">Cadena con las IPs IPv4 y otras a no tener en cuenta.</param>
    ''' <returns>Una cadena con las IPs de tipo IPv4 de la cadena indicada.</returns>
    Public Function LasIPv4(ByVal ipAdresses As String) As String
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
    Public Function ObtenerIPs()

        Dim sb As New StringBuilder()
        Dim ipAddresses As String

        Try
            Dim hostName = Dns.GetHostName()
            Dim addresses As IPAddress() = Dns.GetHostAddresses(hostName)

            For Each address As IPAddress In addresses
                sb.Append($"{address}, ")
            Next

            ipAddresses = sb.ToString().TrimEnd(", ".ToCharArray())
            'ipAddresses = LasIPv4(ipAddresses)
        Catch ex As Exception
            ipAddresses = "ERROR: " & ex.Message
        End Try
        Return ipAddresses ' String.Format("HostName: {0}, IPv4: {1}", hostName, ipAddresses)
    End Function

End Module
