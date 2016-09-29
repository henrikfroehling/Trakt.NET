namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    using Base.Post;
    using System;

    internal sealed class TraktScrobbleStartRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>
    {
        public TraktScrobbleStartRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
