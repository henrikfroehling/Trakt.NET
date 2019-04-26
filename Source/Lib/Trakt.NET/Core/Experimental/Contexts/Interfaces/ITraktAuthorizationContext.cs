namespace TraktNet.Core.Experimental.Contexts.Interfaces
{
    using Objects.Authentication;

    public interface ITraktAuthorizationContext
    {
        string ClientId { get; set; }

        string ClientSecret { get; set; }

        ITraktAuthorization Authorization { get; set; }
    }
}
