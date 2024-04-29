namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Get.Seasons;
    using Objects.Post.Comments;
    using System;

    internal sealed class SeasonCommentPostBuilder : ACommentPostBuilder<ITraktSeasonCommentPostBuilder, ITraktSeasonCommentPost>, ITraktSeasonCommentPostBuilder
    {
        private ITraktSeason _season;
        private ITraktSeasonIds _seasonIds;

        public ITraktSeasonCommentPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            if (season.Ids == null)
                throw new ArgumentNullException($"{nameof(season)}.Ids");

            if (!season.Ids.HasAnyId)
                throw new ArgumentException("season ids have no valid id", $"{nameof(season)}.Ids");

            _season = season;
            _seasonIds = null;
            return this;
        }

        public ITraktSeasonCommentPostBuilder WithSeason(ITraktSeasonIds seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            if (!seasonIds.HasAnyId)
                throw new ArgumentException($"{nameof(seasonIds)} have no valid id");

            _season = null;
            _seasonIds = seasonIds;
            return this;
        }

        public override ITraktSeasonCommentPost Build()
        {
            ITraktSeasonCommentPost seasonCommentPost = new TraktSeasonCommentPost
            {
                Comment = _comment,
                Sharing = _sharing
            };

            if (_hasSpoiler.HasValue)
                seasonCommentPost.Spoiler = _hasSpoiler.Value;

            if (_season == null && _seasonIds == null)
                throw new TraktPostValidationException("Empty comment post. No season value set.");

            if (_season != null)
            {
                seasonCommentPost.Season = _season;
            }
            else
            {
                seasonCommentPost.Season = new TraktSeason
                {
                    Ids = _seasonIds
                };
            }

            seasonCommentPost.Validate();
            return seasonCommentPost;
        }

        protected override ITraktSeasonCommentPostBuilder GetBuilder() => this;
    }
}
