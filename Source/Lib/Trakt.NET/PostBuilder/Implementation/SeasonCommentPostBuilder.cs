namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Comments;

    internal sealed class SeasonCommentPostBuilder : ACommentPostBuilder<ITraktSeasonCommentPostBuilder, ITraktSeasonCommentPost>, ITraktSeasonCommentPostBuilder
    {
        private ITraktSeason _season;

        public ITraktSeasonCommentPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            if (season.Ids == null)
                throw new ArgumentNullException(nameof(season.Ids));

            if (!season.Ids.HasAnyId)
                throw new ArgumentException("season ids have no valid id", nameof(season.Ids));

            _season = season;
            return this;
        }

        public override ITraktSeasonCommentPost Build()
        {
            ITraktSeasonCommentPost seasonCommentPost = new TraktSeasonCommentPost
            {
                Comment = _comment,
                Sharing = _sharing,
                Season = _season
            };

            if (_hasSpoiler.HasValue)
                seasonCommentPost.Spoiler = _hasSpoiler.Value;

            seasonCommentPost.Validate();
            return seasonCommentPost;
        }

        protected override ITraktSeasonCommentPostBuilder GetBuilder() => this;
    }
}
