namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Post.Checkins;

    public interface ITraktCheckinPostBuilder<TPostBuilder, out TPostObject>
        where TPostBuilder : ITraktCheckinPostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktCheckinPost
    {
        TPostBuilder WithMessage(string message);

        TPostBuilder WithAppVersion(string appVersion);

        TPostBuilder WithAppDate(string appDate);

        TPostBuilder WithFoursquareVenueId(string foursquareVenueId);

        TPostBuilder WithFoursquareVenueName(string foursquareVenueName);

        TPostBuilder WithSharing(ITraktConnections sharing);

        TPostObject Build();
    }
}
