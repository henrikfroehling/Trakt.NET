namespace TraktApiSharp.Requests.Shows
{
    using Objects.Basic;

    internal sealed class TraktShowRatingsRequest : ATraktShowRequest<ITraktRating>
    {
        public override string UriTemplate => "shows/{id}/ratings";
    }
}
