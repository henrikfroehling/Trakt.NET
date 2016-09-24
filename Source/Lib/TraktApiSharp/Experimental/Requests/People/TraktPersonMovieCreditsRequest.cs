namespace TraktApiSharp.Experimental.Requests.People
{
    using Objects.Get.People.Credits;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktPersonMovieCreditsRequest : ATraktPersonCreditsRequest<TraktPersonMovieCredits>
    {
        public TraktPersonMovieCreditsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
