using System.Threading.Tasks;
using BlazorTemplate.Classes.DTO;
using BlazorTemplate.Client.Abstractions;
using BlazorTemplate.Client.HttpRepository;
using Microsoft.AspNetCore.Components;

namespace BlazorTemplate.Client.Pages;

public partial class Login
{
    private UserForAuthenticationDto _userForAuthentication = new UserForAuthenticationDto();

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public bool ShowAuthError { get; set; }
    public string Error { get; set; }

    public async Task ExecuteLogin()
    {
        ShowAuthError = false;

        var result = await AuthenticationService.Login(_userForAuthentication);
        if (!result.IsAuthSuccessful)
        {
            Error = result.ErrorMessage;
            ShowAuthError = true;
        }
        else
        {
            NavigationManager.NavigateTo("/");
        }
    }
}