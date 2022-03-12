﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorTemplate.Shared.DTO;
using BlazorTemplate.Client.Abstractions;
using BlazorTemplate.Client.AuthProviders;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorTemplate.Client.HttpRepository;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly AuthenticationStateProvider _authStateProvider; 
    private readonly ILocalStorageService _localStorage;

    public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _authStateProvider = authStateProvider; 
        _localStorage = localStorage;
    }

    public async Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        var content = JsonSerializer.Serialize(userForRegistration);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var registrationResult = await _client.PostAsync("users", bodyContent);
        var registrationContent = await registrationResult.Content.ReadAsStringAsync();

        if (!registrationResult.IsSuccessStatusCode)
        {
            var result = JsonSerializer.Deserialize<RegistrationResponseDto>(registrationContent, _options);
            return result;
        }

        return new RegistrationResponseDto { IsSuccessfulRegistration = true };
    }

    public async Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication)
    {
        var content = JsonSerializer.Serialize(userForAuthentication);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var authResult = await _client.PostAsync("users/auth", bodyContent);
        var authContent = await authResult.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<AuthResponseDto>(authContent, _options);

        if (!authResult.IsSuccessStatusCode)
            return result;

        await _localStorage.SetItemAsync("authToken", result.Token);
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(userForAuthentication.Email);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            
        return new AuthResponseDto { IsAuthSuccessful = true };
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _client.DefaultRequestHeaders.Authorization = null;
    }
}