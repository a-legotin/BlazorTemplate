using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTemplate.Classes.DTO;
using BlazorTemplate.Client.HttpRepository;
using Microsoft.AspNetCore.Components;

namespace BlazorTemplate.Client.Pages;

public partial class Registration
{
    private UserForRegistrationDto _userForRegistration = new UserForRegistrationDto();

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public bool ShowRegistrationErros { get; set; }
    public IEnumerable<string> Errors { get; set; }

    public async Task Register()
    {
        ShowRegistrationErros = false;

        var result = await AuthenticationService.RegisterUser(_userForRegistration);
        if(!result.IsSuccessfulRegistration)
        {
            Errors = result.Errors;
            ShowRegistrationErros = true;
        }
        else
        {
            NavigationManager.NavigateTo("/");
        }
    }
}