namespace TraktNet.Core.Experimental.Contexts.Interfaces
{
    public interface ITraktContext : ITraktConfiguration, ITraktAuthorizationContext
    {
        string UniqueContextId { get; }

        ITraktConfiguration Configuration { get; }
    }
}
