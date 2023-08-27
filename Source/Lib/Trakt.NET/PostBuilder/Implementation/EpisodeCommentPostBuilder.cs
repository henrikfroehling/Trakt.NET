namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Get.Episodes;
    using Objects.Post.Comments;
    using System;

    internal sealed class EpisodeCommentPostBuilder : ACommentPostBuilder<ITraktEpisodeCommentPostBuilder, ITraktEpisodeCommentPost>, ITraktEpisodeCommentPostBuilder
    {
        private ITraktEpisode _episode;
        private ITraktEpisodeIds _episodeIds;

        public ITraktEpisodeCommentPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException($"{nameof(episode)}.Ids");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode ids have no valid id", $"{nameof(episode)}.Ids");

            _episode = episode;
            _episodeIds = null;
            return this;
        }

        public ITraktEpisodeCommentPostBuilder WithEpisode(ITraktEpisodeIds episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            if (!episodeIds.HasAnyId)
                throw new ArgumentException($"{nameof(episodeIds)} have no valid id");

            _episode = null;
            _episodeIds = episodeIds;
            return this;
        }

        public override ITraktEpisodeCommentPost Build()
        {
            ITraktEpisodeCommentPost episodeCommentPost = new TraktEpisodeCommentPost
            {
                Comment = _comment,
                Sharing = _sharing
            };

            if (_hasSpoiler.HasValue)
                episodeCommentPost.Spoiler = _hasSpoiler.Value;

            if (_episode == null && _episodeIds == null)
                throw new TraktPostValidationException("Empty comment post. No episode value set.");

            if (_episode != null)
            {
                episodeCommentPost.Episode = _episode;
            }
            else
            {
                episodeCommentPost.Episode = new TraktEpisode
                {
                    Ids = _episodeIds
                };
            }

            episodeCommentPost.Validate();
            return episodeCommentPost;
        }

        protected override ITraktEpisodeCommentPostBuilder GetBuilder() => this;
    }
}
