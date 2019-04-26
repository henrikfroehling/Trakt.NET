namespace TraktNet.Core.Experimental.Contexts
{
    using Interfaces;
    using Objects.Authentication;

    public abstract class ATraktContext : ITraktContext
    {
        public abstract string UniqueContextId { get; }

        public virtual int ApiVersion
        {
            get { return Configuration.ApiVersion; }
            set { Configuration.ApiVersion = value; }
        }

        public virtual bool UseSandboxEnvironment
        {
            get { return Configuration.UseSandboxEnvironment; }
            set { Configuration.UseSandboxEnvironment = value; }
        }

        public virtual bool ForceAuthorization
        {
            get { return Configuration.ForceAuthorization; }
            set { Configuration.ForceAuthorization = value; }
        }

        public virtual bool ThrowResponseExceptions
        {
            get { return Configuration.ThrowResponseExceptions; }
            set { Configuration.ThrowResponseExceptions = value; }
        }

        public abstract string ClientId { get; set; }

        public abstract string ClientSecret { get; set; }

        public virtual ITraktAuthorization Authorization { get; set; } = new TraktAuthorization();

        public virtual ITraktConfiguration Configuration { get; } = new TraktConfiguration();

        public override string ToString() => UniqueContextId;
    }
}
