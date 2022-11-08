namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Post.Checkins;

    internal abstract class ACheckinPostBuilder<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktCheckinPostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktCheckinPost
    {
        protected string _message;
        protected string _appVersion;
        protected string _appDate;
        protected string _foursquareVenueId;
        protected string _foursquareVenueName;
        protected ITraktConnections _sharing;

        protected ACheckinPostBuilder()
        {
            _message = null;
            _appVersion = null;
            _appDate = null;
            _foursquareVenueId = null;
            _foursquareVenueName = null;
            _sharing = null;
        }

        public TPostBuilder WithMessage(string message)
        {
            _message = message ?? throw new ArgumentNullException(nameof(message));
            return GetBuilder();
        }

        public TPostBuilder WithAppVersion(string appVersion)
        {
            _appVersion = appVersion ?? throw new ArgumentNullException(nameof(appVersion));
            return GetBuilder();
        }

        public TPostBuilder WithAppDate(string appDate)
        {
            _appDate = appDate ?? throw new ArgumentNullException(nameof(appDate));
            return GetBuilder();
        }

        public TPostBuilder WithFoursquareVenueId(string foursquareVenueId)
        {
            _foursquareVenueId = foursquareVenueId ?? throw new ArgumentNullException(nameof(foursquareVenueId));
            return GetBuilder();
        }

        public TPostBuilder WithFoursquareVenueName(string foursquareVenueName)
        {
            _foursquareVenueName = foursquareVenueName ?? throw new ArgumentNullException(nameof(foursquareVenueName));
            return GetBuilder();
        }

        public TPostBuilder WithSharing(ITraktConnections sharing)
        {
            _sharing = sharing ?? throw new ArgumentNullException(nameof(sharing));
            return GetBuilder();
        }

        public abstract TPostObject Build();

        protected abstract TPostBuilder GetBuilder();
    }
}
