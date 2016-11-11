namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Movies;
    using Objects.Get.Shows.Common;
    using System;

    internal sealed class TraktShowsMostAnticipatedRequest : ATraktMoviesRequest<TraktMostAnticipatedShow>
    {
        public TraktShowsMostAnticipatedRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
