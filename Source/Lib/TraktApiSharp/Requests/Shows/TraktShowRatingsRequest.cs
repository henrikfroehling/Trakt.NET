namespace TraktApiSharp.Requests.Shows
{
    using Objects.Basic;

    internal sealed class TraktShowRatingsRequest : ATraktShowRequest<TraktRating>
    {
        public override string UriTemplate => "shows/{id}/ratings";
    }
}
