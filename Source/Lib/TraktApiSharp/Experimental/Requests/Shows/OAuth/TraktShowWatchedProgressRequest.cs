namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Objects.Get.Shows;
    using System;

    internal sealed class TraktShowWatchedProgressRequest : ATraktShowProgressRequest<TraktShowWatchedProgress>
    {
        public TraktShowWatchedProgressRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
