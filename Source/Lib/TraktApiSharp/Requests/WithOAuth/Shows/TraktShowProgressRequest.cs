namespace TraktApiSharp.Requests.WithOAuth.Shows
{
    using Base.Get;
    using System.Collections.Generic;

    internal abstract class TraktShowProgressRequest<T> : TraktGetByIdRequest<T, T>
    {
        internal TraktShowProgressRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        internal bool? Hidden { get; set; }

        internal bool? Specials { get; set; }

        protected override bool UseCustomExtendedOptions => true;

        protected override IEnumerable<KeyValuePair<string, string>> GetCustomExtendedOptionParameters()
        {
            var optionParams = new Dictionary<string, string>();

            if (Hidden.HasValue)
                optionParams["hidden"] = Hidden.Value.ToString().ToLower();

            if (Specials.HasValue)
                optionParams["specials"] = Specials.Value.ToString().ToLower();

            return optionParams;
        }
    }
}
