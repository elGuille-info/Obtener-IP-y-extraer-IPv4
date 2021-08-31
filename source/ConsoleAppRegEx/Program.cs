//-----------------------------------------------------------------------------
// Utils.LasIPv4                                                    (30/Ago/21)
// Extraer de una cadena las direcciones IPv4
//
// Usando la expresión regular para las IPv4 de:
// https://programmerclick.com/article/29011265391
//
// (c) Guillermo Som (Guille), 2021
//-----------------------------------------------------------------------------
using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleAppRegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine("Ejemplo en C# usando .NET 5.0 para obtener las IPs y extraer con RegEx solo las IPv4.");
            Console.WriteLine();

            string ipAdresses = Utils.ObtenerIPs();

            Console.WriteLine("La cadena con todas las IPs:");
            Console.WriteLine(ipAdresses);
            string ret = Utils.LasIPv4(ipAdresses);

            Console.WriteLine();
            Console.WriteLine("Direcciones IPv4:");
            Console.WriteLine(ret);

            Console.WriteLine();
            Console.WriteLine("Pulsa INTRO para terminar.");
            Console.ReadLine();
        }
    }

    public static class Utils
    {
        /// <summary>
        /// Devuelve una cadena con todas las direcciones IPv4 de la cadena indicada.
        /// </summary>
        /// <param name="ipAdresses">Cadena con las IPs IPv4 y otras a no tener en cuenta.</param>
        /// <returns>Una cadena con las IPs de tipo IPv4 de la cadena indicada.</returns>
        public static string LasIPv4(string ipAdresses)
        {
            StringBuilder sb = new();

            string sRegExIPv4 = @"((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)";
            Regex r = new Regex(sRegExIPv4);
            foreach (Match m in r.Matches(ipAdresses))
            {
                if(m.Success)
                {
                    sb.Append($"{m.Value}, ");
                }
            }

            return sb.ToString().TrimEnd(", ".ToCharArray());
        }

        /// <summary>
        /// Devuelve las IPs del equipo actual.
        /// </summary>
        /// <returns>Una cadena con las direcciones IP, sean IPv6 o IPv6.</returns>
        public static string ObtenerIPs()
        {
            StringBuilder sb = new StringBuilder();
            string ipAddresses;

            try
            {
                var hostName = Dns.GetHostName();
                IPAddress[] addresses = Dns.GetHostAddresses(hostName);

                foreach (IPAddress address in addresses)
                    sb.Append($"{address}, ");

                ipAddresses = sb.ToString().TrimEnd(", ".ToCharArray());
            }
            catch (Exception ex)
            {
                ipAddresses = "ERROR: " + ex.Message;
            }
            return ipAddresses;
        }

    }
}
