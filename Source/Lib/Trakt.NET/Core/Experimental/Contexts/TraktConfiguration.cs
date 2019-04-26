namespace TraktNet.Core.Experimental.Contexts
{
    public class TraktConfiguration : ATraktConfiguration
    {
        public override int ApiVersion { get; set; } = 2;

        public override bool UseSandboxEnvironment { get; set; } = false;

        public override bool ForceAuthorization { get; set; } = false;

        public override bool ThrowResponseExceptions { get; set; } = true;
    }
}
