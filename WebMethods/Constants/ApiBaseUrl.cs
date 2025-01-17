using System.Net.Sockets;

namespace Requests.Constants
{
    internal class ApiBaseUrl
    {
        public const string localhostServer = "https://localhost:44398"; //https://localhost:44398
        public const string azureServer = "https://172.16.9.160:443";
        //public const string azureServer = "https://yektamakwebapp.azurewebsites.net";
        public static string server = GetServerUrl();
        public static string GetServerUrl()
        {
            if (IsIISRunning())
            {
                return localhostServer;
            }
            else
            {
                return azureServer;
            }
        }

        private static bool IsIISRunning()
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 44398))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
