using System.Text.Json.Serialization;

namespace CardStorageService.Models.Requests
{
    public interface AuthenticationRequest
    {
       
        public string Login { get; set; }
      
        public string Password { get; set; }
    }
}
