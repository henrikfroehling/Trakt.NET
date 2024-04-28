using TraktNet.Objects.Authentication;

namespace Trakt.NET.Examples.Helper;

internal static class TraktExceptionExtensions
{
    internal static void WriteAuthorizationInformation(this ITraktAuthorization authorization)
    {
        Console.WriteLine($"Created (UTC): {authorization.CreatedAt}");
        Console.WriteLine($"Access Scope: {authorization.Scope.DisplayName}");
        Console.WriteLine($"Refresh Possible: {authorization.IsRefreshPossible}");
        Console.WriteLine($"Valid: {authorization.IsValid}");
        Console.WriteLine($"Access Token: {authorization.AccessToken}");
        Console.WriteLine($"Refresh Token: {authorization.RefreshToken}");
        Console.WriteLine($"Token Expired: {authorization.IsExpired}");

        DateTime created = authorization.CreatedAt;
        DateTime expirationDate = created.AddSeconds(authorization.ExpiresInSeconds);
        TimeSpan difference = expirationDate - DateTime.UtcNow;

        int days = difference.Days > 0 ? difference.Days : 0;
        int hours = difference.Hours > 0 ? difference.Hours : 0;
        int minutes = difference.Minutes > 0 ? difference.Minutes : 0;

        Console.WriteLine($"Expires in {days} Days, {hours} Hours, {minutes} Minutes");
    }
}
