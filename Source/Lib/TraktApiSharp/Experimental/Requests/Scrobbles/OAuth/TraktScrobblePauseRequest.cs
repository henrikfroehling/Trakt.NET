namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    using Base.Post;
    using System;

    internal sealed class TraktScrobblePauseRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>
    {
        public TraktScrobblePauseRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
