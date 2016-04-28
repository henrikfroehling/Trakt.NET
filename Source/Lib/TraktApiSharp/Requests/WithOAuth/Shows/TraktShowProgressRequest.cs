namespace TraktApiSharp.Requests.WithOAuth.Shows
{
    using Base.Get;
    using System.Collections.Generic;

    internal abstract class TraktShowProgressRequest<T> : TraktGetByIdRequest<T, T>
    {
        internal TraktShowProgressRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        internal bool Hidden { get; set; }

        internal bool Specials { get; set; }

        protected override bool UseCustomExtendedOptions => true;

        protected override IEnumerable<KeyValuePair<string, string>> GetCustomExtendedOptionParameters()
        {
            var optionParams = new Dictionary<string, string>();

            optionParams["hidden"] = Hidden.ToString().ToLower();
            optionParams["specials"] = Specials.ToString().ToLower();

            return optionParams;
        }
    }
}
