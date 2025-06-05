using Microsoft.AspNetCore.Http;

namespace OBAWebAPI.Framework.Domain.Models
{
    public class LogInformationViewModel
    {
        public LogInformationViewModel(HostString requestPort, string requestPath, string requestMethod, string requestOrigin, QueryString requestQueryString, string requestBody, string responseCorrId, string userId, string username, string userLoginProvider)
        {
            RequestPort = requestPort;
            RequestPath = requestPath;
            RequestMethod = requestMethod;
            RequestOrigin = requestOrigin;
            RequestQueryString = requestQueryString;
            RequestBody = requestBody;
            ResponseCorrId = responseCorrId;
            UserId = userId;
            Username = username;
            UserLoginProvider = userLoginProvider;
        }
        public HostString RequestPort { get; set; }
        public string RequestPath { get; set; }
        public string RequestMethod { get; set; }
        public string RequestOrigin { get; set; }
        public QueryString RequestQueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseCorrId { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string UserLoginProvider { get; set; }
    }
}
