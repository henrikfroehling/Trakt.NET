namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Checkins;

    internal sealed class EpisodeCheckinPostBuilder : ACheckinPostBuilder<ITraktEpisodeCheckinPostBuilder, ITraktEpisodeCheckinPost>, ITraktEpisodeCheckinPostBuilder
    {
        private ITraktEpisode _episode;
        private ITraktShow _show;
        private int _seasonNumber;
        private int _episodeNumber;
        private bool _useSeasonAndEpisodeNumber;

        public ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException($"{nameof(episode)}.Ids");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode ids have no valid id", $"{nameof(episode)}.Ids");

            _episode = episode;
            return this;
        }

        public ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktShow show, int seasonNumber, int episodeNumber)
        {
            CheckShow(show);

            if (seasonNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(seasonNumber), "season number must be at least 0");

            if (episodeNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(episodeNumber), "episode season number must be at least 1");

            _episode = null;
            _show = show;
            _seasonNumber = seasonNumber;
            _episodeNumber = episodeNumber;
            _useSeasonAndEpisodeNumber = true;
            return this;
        }

        public ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktShow show, int absoluteEpisodeNumber)
        {
            CheckShow(show);

            if (absoluteEpisodeNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(absoluteEpisodeNumber), "episode season number must be at least 1");

            _episode = null;
            _show = show;
            _episodeNumber = absoluteEpisodeNumber;
            _useSeasonAndEpisodeNumber = false;
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

            if (_episode == null)
            {
                episodeCheckinPost.Show = _show;

                if (_useSeasonAndEpisodeNumber)
                {
                    episodeCheckinPost.Episode = new TraktEpisode
                    {
                        SeasonNumber = _seasonNumber,
                        Number = _episodeNumber
                    };
                }
                else
                {
                    episodeCheckinPost.Episode = new TraktEpisode
                    {
                        NumberAbsolute = _episodeNumber
                    };
                }
            }
            else
            {
                episodeCheckinPost.Episode = _episode;
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
    }
}
