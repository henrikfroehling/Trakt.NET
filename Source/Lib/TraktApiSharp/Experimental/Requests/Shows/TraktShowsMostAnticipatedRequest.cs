namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Movies;
    using Objects.Get.Shows.Common;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowsMostAnticipatedRequest : ATraktMoviesRequest<TraktMostAnticipatedShow>
    {
        public TraktShowsMostAnticipatedRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
