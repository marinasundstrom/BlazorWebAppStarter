using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorWebAppStarter.Client;

public sealed class CultureService
{
    private readonly IJSRuntime _jsRuntime;

    public CultureService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public CultureInfo CurrentCulture => CultureInfo.DefaultThreadCurrentCulture!;

    public void SetCulture(CultureInfo culture)
    {
        //if (culture == CurrentCulture)
        //    return;

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        Console.WriteLine("Set: " + culture);

    }

    public async Task SetCultureFromCookieAsync()
    {
        var cookieValue = await _jsRuntime.InvokeAsync<string>("getCookie", ".AspNetCore.Culture");

        if (!string.IsNullOrEmpty(cookieValue))
        {
            // The cookie format is usually "c=en-US|uic=en-US"
            var cultureName = cookieValue.Split('|')[0].Split('=')[1];

            Console.WriteLine(cultureName);

            var culture = new CultureInfo(cultureName);
            SetCulture(culture);
        }
    }
}
