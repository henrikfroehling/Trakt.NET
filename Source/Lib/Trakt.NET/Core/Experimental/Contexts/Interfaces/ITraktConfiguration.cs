namespace TraktNet.Core.Experimental.Contexts.Interfaces
{
    public interface ITraktConfiguration
    {
        int ApiVersion { get; set; }

        bool UseSandboxEnvironment { get; set; }

        bool ForceAuthorization { get; set; }

        bool ThrowResponseExceptions { get; set; }
    }
}
