using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorTemplate.Client.Abstractions;
using BlazorTemplate.Client.AuthProviders;
using BlazorTemplate.Client.Classes;
using BlazorTemplate.Client.HttpRepository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTemplate.Client;

public class Program
{
    public static async Task Main(string[] args)
	{
		var builder = WebAssemblyHostBuilder.CreateDefault(args);
		builder.RootComponents.Add<App>("#app");
		var options = new ServerOptions();
		builder.Configuration.Bind("ServerOptions", options);
		builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(options.ApiUrl) });
		builder.Services.AddScoped<ICustomerHttpRepository, CustomerHttpRepository>();
		builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
		builder.Services.AddBlazoredLocalStorage(); 
		builder.Services.AddAuthorizationCore(); 
		builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

		await builder.Build().RunAsync();
	}
}