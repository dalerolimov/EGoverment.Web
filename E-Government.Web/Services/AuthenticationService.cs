using Blazored.LocalStorage;
using EGovernment.Web.Abstractions;
using EGovernment.Web.Extensions;
using EGovernment.Web.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace EGovernment.Web.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorageService;
    private readonly INavigationService _navigationService;

    public AuthenticationService(AuthenticationStateProvider authenticationStateProvider,
        ILocalStorageService localStorageService, INavigationService navigationService)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _localStorageService = localStorageService;
        _navigationService = navigationService;
    }

    public async Task SignIn(string username, string password)
    {
        var token =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlNoYWhyaXlhciIsInJvbGUiOiJBZG1pbiIsImlhdCI6MTUxNjIzOTAyMn0.l9E7Oypb-ozndpFUkeVhOYzhtjGEuFmdYdAxhbpXAFY";

        await _localStorageService.SetItemAsync("token", token);
        await _authenticationStateProvider.GetAuthenticationStateAsync();
        _navigationService.NavigateTo("/");
    }
}