namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Get.Episodes;
    using Objects.Get.Shows;
    using Objects.Post.Checkins;
    using System;
    using System.Diagnostics;

    internal sealed class EpisodeCheckinPostBuilder : ACheckinPostBuilder<ITraktEpisodeCheckinPostBuilder, ITraktEpisodeCheckinPost>, ITraktEpisodeCheckinPostBuilder
    {
        private enum State
        {
            None,
            Episode,
            EpisodeIds,
            ShowWithSeasonAndEpisodeNumber,
            ShowWithAbsoluteEpisodeNumber
        }

        private State _state;
        private ITraktEpisode _episode;
        private ITraktEpisodeIds _episodeIds;
        private ITraktShow _show;
        private int _seasonNumber;
        private int _episodeNumber;

        public ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException($"{nameof(episode)}.Ids");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode ids have no valid id", $"{nameof(episode)}.Ids");

            Reset();
            _state = State.Episode;
            _episode = episode;
            return this;
        }

        public ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktEpisodeIds episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            if (!episodeIds.HasAnyId)
                throw new ArgumentException($"{nameof(episodeIds)} have no valid id");

            Reset();
            _state = State.EpisodeIds;
            _episodeIds = episodeIds;
            return this;
        }

        public ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktShow show, int seasonNumber, int episodeNumber)
        {
            CheckShow(show);

            if (seasonNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(seasonNumber), "season number must be at least 0");

            if (episodeNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(episodeNumber), "episode number must be at least 1");

            Reset();
            _state = State.ShowWithSeasonAndEpisodeNumber;
            _show = show;
            _seasonNumber = seasonNumber;
            _episodeNumber = episodeNumber;
            return this;
        }

        public ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktShow show, int absoluteEpisodeNumber)
        {
            CheckShow(show);

            if (absoluteEpisodeNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(absoluteEpisodeNumber), "episode number must be at least 1");

            Reset();
            _state = State.ShowWithAbsoluteEpisodeNumber;
            _show = show;
            _episodeNumber = absoluteEpisodeNumber;
            return this;
        }

        public override ITraktEpisodeCheckinPost Build()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Message = _message,
                AppVersion = _appVersion,
                AppDate = _appDate,
                FoursquareVenueId = _foursquareVenueId,
                FoursquareVenueName = _foursquareVenueName,
                Sharing = _sharing
            };

            switch (_state)
            {
                case State.Episode:
                    Debug.Assert(_episode != null);
                    episodeCheckinPost.Episode = _episode;
                    break;
                case State.EpisodeIds:
                    Debug.Assert(_episodeIds != null);
                    
                    episodeCheckinPost.Episode = new TraktEpisode
                    {
                        Ids = _episodeIds
                    };

                    break;
                case State.ShowWithSeasonAndEpisodeNumber:
                    Debug.Assert(_show != null);
                    episodeCheckinPost.Show = _show;

                    episodeCheckinPost.Episode = new TraktEpisode
                    {
                        SeasonNumber = _seasonNumber,
                        Number = _episodeNumber
                    };

                    break;
                case State.ShowWithAbsoluteEpisodeNumber:
                    Debug.Assert(_show != null);
                    episodeCheckinPost.Show = _show;

                    episodeCheckinPost.Episode = new TraktEpisode
                    {
                        NumberAbsolute = _episodeNumber
                    };

                    break;
                case State.None:
                default:
                    throw new TraktPostValidationException("Empty checkin post. No episode value set.");
            }

            episodeCheckinPost.Validate();
            return episodeCheckinPost;
        }

        protected override ITraktEpisodeCheckinPostBuilder GetBuilder() => this;

        private void CheckShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException($"{nameof(show)}.Ids");

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("show ids have no valid id", $"{nameof(show)}.Ids");
        }

        private void Reset()
        {
            _state = State.None;
            _episode = null;
            _episodeIds = null;
            _show = null;
            _seasonNumber = -1;
            _episodeNumber = 0;
        }
    }
}
