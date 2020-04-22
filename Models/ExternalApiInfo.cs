using System.Configuration;

namespace LESSION_WEB_API_DEMO.Models
{
    public class ExternalApiInfo
    {
        public string EndPoint { get; }

        public ExternalApiInfo()
        {
            EndPoint = ConfigurationManager.AppSettings["ExternalApiEndPoint"];
        }
    }
}