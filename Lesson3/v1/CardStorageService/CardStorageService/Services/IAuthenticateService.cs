using CardStorageService.Models;
using CardStorageService.Models.Requests;
using Newtonsoft.Json;

namespace CardStorageService.Services
{
    public interface IAuthenticateService
    {
        AuthenticationResponse Login(AuthenticationRequest authenticationRequest);
        public SessionInfo GetSessionInfo(string sessionToken);
    }
}
