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
            _season = season ?? throw new ArgumentNullException(nameof(season));
            return this;
        }

        public override ITraktSeasonCommentPost Build()
        {
            ITraktSeasonCommentPost seasonCommentPost = new TraktSeasonCommentPost
            {
                Comment = _comment,
                Spoiler = _hasSpoiler,
                Sharing = _sharing,
                Season = _season
            };

            seasonCommentPost.Validate();
            return seasonCommentPost;
        }

        protected override ITraktSeasonCommentPostBuilder GetBuilder() => this;
    }
}
