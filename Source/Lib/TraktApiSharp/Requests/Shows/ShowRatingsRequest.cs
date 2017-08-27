namespace TraktApiSharp.Requests.Shows
{
    using Objects.Basic;

    internal sealed class ShowRatingsRequest : AShowRequest<ITraktRating>
    {
        public override string UriTemplate => "shows/{id}/ratings";
    }
}
