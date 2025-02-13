using BlazorWebAppStarter.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register services
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddLocalization();
builder.Services.AddSingleton<CultureService>();

var host = builder.Build();

// Apply culture before rendering the app
var cultureService = host.Services.GetRequiredService<CultureService>();
await cultureService.SetCultureFromCookieAsync();


await host.RunAsync();
