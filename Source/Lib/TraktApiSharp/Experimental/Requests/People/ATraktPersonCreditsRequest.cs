namespace TraktApiSharp.Experimental.Requests.People
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktPersonCreditsRequest<TITem> : ATraktSingleItemGetByIdRequest<TITem>, ITraktObjectRequest, ITraktExtendedInfo
    {
        internal ATraktPersonCreditsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedOption ExtendedOption { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.People;
    }
}
