namespace TraktApiSharp.Experimental.Requests.People
{
    using Objects.Get.People.Credits;
    using System;

    internal sealed class TraktPersonShowCreditsRequest : ATraktPersonCreditsRequest<TraktPersonShowCredits>
    {
        public TraktPersonShowCreditsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
