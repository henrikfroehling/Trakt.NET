namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;
    using System;

    internal sealed class TraktMoviesMostCollectedRequest : ATraktMoviesMostPWCRequest<TraktMostCollectedMovie>
    {
        internal TraktMoviesMostCollectedRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
