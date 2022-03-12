using System.Threading.Tasks;
using BlazorTemplate.Shared.DTO;

namespace BlazorTemplate.Client.Abstractions;

public interface IAuthenticationService
{
    Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
    Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication); 
    Task Logout();
}