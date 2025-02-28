﻿namespace TodoTemplate.App.Services.Implementations;

public class AppAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IAuthTokenProvider _tokenProvider;

    public AppAuthenticationStateProvider(IAuthTokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public async Task RaiseAuthenticationStateHasChanged()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(await GetAuthenticationStateAsync()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var access_token = await _tokenProvider.GetAcccessToken();

        if (string.IsNullOrWhiteSpace(access_token))
        {
            return NotSignedIn();
        }

        var identity = new ClaimsIdentity(claims: ParseTokenClaims(access_token), authenticationType: "Bearer", nameType: "name", roleType: "role");

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public async Task<bool> IsUserAuthenticated()
    {
        return (await GetAuthenticationStateAsync()).User.Identity?.IsAuthenticated == true;
    }

    AuthenticationState NotSignedIn()
    {
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    private IEnumerable<Claim> ParseTokenClaims(string access_token)
    {
        return Jose.JWT.Payload<Dictionary<string, object>>(access_token)
            .Select(keyValue => new Claim(keyValue.Key, keyValue.Value.ToString() ?? string.Empty))
            .ToArray();
    }
}
