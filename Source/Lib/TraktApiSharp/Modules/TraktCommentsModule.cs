namespace TraktApiSharp.Modules
{
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Episodes;
    using Objects.Get.Shows.Seasons;
    using Objects.Get.Users.Lists;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using Requests;
    using Requests.WithOAuth.Comments;
    using Requests.WithoutOAuth.Comments;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TraktCommentsModule : TraktBaseModule
    {
        internal TraktCommentsModule(TraktClient client) : base(client) { }

        public async Task<TraktComment> GetCommentAsync(string id)
        {
            ValidateId(id);

            return await QueryAsync(new TraktCommentSummaryRequest(Client) { Id = id });
        }

        public async Task<TraktListResult<TraktComment>> GetMutlipleCommentsAsync(string[] ids)
        {
            if (ids == null || ids.Length <= 0)
                return null;

            var tasks = new List<Task<TraktComment>>();

            for (int i = 0; i < ids.Length; i++)
            {
                Task<TraktComment> task = GetCommentAsync(ids[i]);
                tasks.Add(task);
            }

            var comments = await Task.WhenAll(tasks);
            return new TraktListResult<TraktComment> { Items = comments.ToList() };
        }

        public async Task<TraktCommentPostResponse> PostMovieCommentAsync(TraktMovie movie, string comment,
                                                                          bool? spoiler = null, TraktSharing sharing = null)
        {
            ValidateMovie(movie);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktMovieCommentPost>(Client)
            {
                RequestBody = new TraktMovieCommentPost
                {
                    Movie = new TraktMovie
                    {
                        Title = movie.Title,
                        Year = movie.Year,
                        Ids = movie.Ids
                    },
                    Comment = comment,
                    Spoiler = spoiler,
                    Sharing = sharing
                }
            });
        }

        public async Task<TraktCommentPostResponse> PostShowCommentAsync(TraktShow show, string comment,
                                                                         bool? spoiler = null, TraktSharing sharing = null)
        {
            ValidateShow(show);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktShowCommentPost>(Client)
            {
                RequestBody = new TraktShowCommentPost
                {
                    Show = new TraktShow
                    {
                        Title = show.Title,
                        Ids = show.Ids
                    },
                    Comment = comment,
                    Spoiler = spoiler,
                    Sharing = sharing
                }
            });
        }

        public async Task<TraktCommentPostResponse> PostSeasonCommentAsync(TraktSeason season, string comment,
                                                                           bool? spoiler = null, TraktSharing sharing = null)
        {
            ValidateSeason(season);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktSeasonCommentPost>(Client)
            {
                RequestBody = new TraktSeasonCommentPost
                {
                    Season = new TraktSeason { Ids = season.Ids },
                    Comment = comment,
                    Spoiler = spoiler,
                    Sharing = sharing
                }
            });
        }

        public async Task<TraktCommentPostResponse> PostEpisodeCommentAsync(TraktEpisode episode, string comment,
                                                                            bool? spoiler = null, TraktSharing sharing = null)
        {
            ValidateEpisode(episode);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktEpisodeCommentPost>(Client)
            {
                RequestBody = new TraktEpisodeCommentPost
                {
                    Episode = new TraktEpisode { Ids = episode.Ids },
                    Comment = comment,
                    Spoiler = spoiler,
                    Sharing = sharing
                }
            });
        }

        public async Task<TraktCommentPostResponse> PostListCommentAsync(TraktList list, string comment,
                                                                         bool? spoiler = null, TraktSharing sharing = null)
        {
            ValidateList(list);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktListCommentPost>(Client)
            {
                RequestBody = new TraktListCommentPost
                {
                    List = new TraktList { Ids = list.Ids },
                    Comment = comment,
                    Spoiler = spoiler,
                    Sharing = sharing
                }
            });
        }

        public async Task<TraktCommentPostResponse> UpdateCommentAsync(string commentId, string comment, bool? spoiler = null)
        {
            ValidateId(commentId);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentUpdateRequest(Client)
            {
                Id = commentId,
                RequestBody = new TraktCommentUpdatePost
                {
                    Comment = comment,
                    Spoiler = spoiler
                }
            });
        }

        public async Task<TraktCommentPostResponse> PostCommentReplyAsync(string commentId, string comment, bool? spoiler = null)
        {
            ValidateId(commentId);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentReplyRequest(Client)
            {
                Id = commentId,
                RequestBody = new TraktCommentReplyPost
                {
                    Comment = comment,
                    Spoiler = spoiler
                }
            });
        }

        public async Task DeleteCommentAsync(string commentId)
        {
            ValidateId(commentId);

            await QueryAsync(new TraktCommentDeleteRequest(Client) { Id = commentId });
        }

        public async Task LikeCommentAsync(string commentId)
        {
            ValidateId(commentId);

            await QueryAsync(new TraktCommentLikeRequest(Client) { Id = commentId });
        }

        public async Task UnlikeCommentAsync(string commentId)
        {
            ValidateId(commentId);

            await QueryAsync(new TraktCommentUnlikeRequest(Client) { Id = commentId });
        }

        public async Task<TraktPaginationListResult<TraktComment>> GetCommentRepliesAsync(string id, int? page = null, int? limit = null)
        {
            ValidateId(id);

            return await QueryAsync(new TraktCommentRepliesRequest(Client)
            {
                Id = id,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        private void ValidateId(string id)
        {
            if (string.IsNullOrEmpty(id) || id.ContainsSpace())
                throw new ArgumentException("comment id not valid", nameof(id));
        }

        private void ValidateComment(string comment)
        {
            if (string.IsNullOrEmpty(comment))
                throw new ArgumentException("comment is empty", nameof(comment));

            if (comment.WordCount() < 5)
                throw new ArgumentException("comment has too few words - at least five words are required", nameof(comment));
        }

        private void ValidateMovie(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentException("movie must not be null", nameof(movie));

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("movie title not valid", nameof(movie.Title));

            if (movie.Year <= 0)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));

            if (movie.Ids == null)
                throw new ArgumentException("movie ids must not be null", nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie ids have no valid id", nameof(movie.Ids));
        }

        private void ValidateShow(TraktShow show)
        {
            if (show == null)
                throw new ArgumentException("show must not be null", nameof(show));

            if (string.IsNullOrEmpty(show.Title))
                throw new ArgumentException("show title not valid", nameof(show.Title));

            if (show.Ids == null)
                throw new ArgumentException("show ids must not be null", nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("show ids have no valid id", nameof(show.Ids));
        }

        private void ValidateSeason(TraktSeason season)
        {
            if (season == null)
                throw new ArgumentException("season must not be null", nameof(season));

            if (season.Ids == null)
                throw new ArgumentException("season ids must not be null", nameof(season.Ids));

            if (!season.Ids.HasAnyId)
                throw new ArgumentException("season ids have no valid id", nameof(season.Ids));
        }

        private void ValidateEpisode(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentException("episode must not be null", nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentException("episode ids must not be null", nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode ids have no valid id", nameof(episode.Ids));
        }

        private void ValidateList(TraktList list)
        {
            if (list == null)
                throw new ArgumentException("list must not be null", nameof(list));

            if (list.Ids == null)
                throw new ArgumentException("list ids must not be null", nameof(list.Ids));

            if (!list.Ids.HasAnyId)
                throw new ArgumentException("list ids have no valid id", nameof(list.Ids));
        }
    }
}
