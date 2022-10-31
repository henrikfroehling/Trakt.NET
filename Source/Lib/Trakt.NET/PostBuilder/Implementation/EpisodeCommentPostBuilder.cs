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
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException($"{nameof(episode)}.Ids");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode ids have no valid id", $"{nameof(episode)}.Ids");

            _episode = episode;
            return this;
        }

        public override ITraktEpisodeCommentPost Build()
        {
            ITraktEpisodeCommentPost episodeCommentPost = new TraktEpisodeCommentPost
            {
                Comment = _comment,
                Sharing = _sharing,
                Episode = _episode
            };

            if (_hasSpoiler.HasValue)
                episodeCommentPost.Spoiler = _hasSpoiler.Value;

            episodeCommentPost.Validate();
            return episodeCommentPost;
        }

        protected override ITraktEpisodeCommentPostBuilder GetBuilder() => this;
    }
}
