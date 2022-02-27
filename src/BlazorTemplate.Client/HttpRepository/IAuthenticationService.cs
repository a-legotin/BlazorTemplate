﻿using System.Threading.Tasks;
using BlazorTemplate.Classes.DTO;

namespace BlazorProducts.Client.HttpRepository
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication); 
        Task Logout();
    }
}
