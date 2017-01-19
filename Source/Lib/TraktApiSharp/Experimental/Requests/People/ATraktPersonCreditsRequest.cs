namespace TraktApiSharp.Experimental.Requests.People
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktPersonCreditsRequest<TITem> : ATraktSingleItemGetByIdRequest<TITem>, ITraktSupportsExtendedInfo
    {
        internal ATraktPersonCreditsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.People;
    }
}
