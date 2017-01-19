namespace TraktApiSharp.Experimental.Requests.People
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktPersonCreditsRequest<TITem> : ITraktSupportsExtendedInfo
    {
        internal ATraktPersonCreditsRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.People;
    }
}
