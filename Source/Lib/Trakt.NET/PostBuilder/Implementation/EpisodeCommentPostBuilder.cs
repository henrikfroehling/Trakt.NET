namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Comments;

    internal sealed class EpisodeCommentPostBuilder : ACommentPostBuilder<ITraktEpisodeCommentPostBuilder, ITraktEpisodeCommentPost>, ITraktEpisodeCommentPostBuilder
    {
        private ITraktEpisode _episode;

        public ITraktEpisodeCommentPostBuilder WithEpisode(ITraktEpisode episode)
        {
            _episode = episode ?? throw new ArgumentNullException(nameof(episode));
            return this;
        }

        public override ITraktEpisodeCommentPost Build()
        {
            ITraktEpisodeCommentPost episodeCommentPost = new TraktEpisodeCommentPost
            {
                Comment = _comment,
                Spoiler = _hasSpoiler,
                Sharing = _sharing,
                Episode = _episode
            };

            episodeCommentPost.Validate();
            return episodeCommentPost;
        }

        protected override ITraktEpisodeCommentPostBuilder GetBuilder() => this;
    }
}
