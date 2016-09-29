namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    using Base.Post;
    using System;

    internal sealed class TraktScrobbleStopRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>
    {
        public TraktScrobbleStopRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
