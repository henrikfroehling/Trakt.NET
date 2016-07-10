namespace TraktApiSharp.Modules
{
    using Extensions;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Episodes;
    using Objects.Post.Scrobbles;
    using Objects.Post.Scrobbles.Responses;
    using Requests;
    using Requests.WithOAuth.Scrobbles;
    using System;
    using System.Threading.Tasks;

    public class TraktScrobbleModule : TraktBaseModule
    {
        internal TraktScrobbleModule(TraktClient client) : base(client) { }

        public async Task<TraktMovieScrobblePostResponse> StartMovieAsync(TraktMovie movie, float progress,
                                                                          string appVersion = null, DateTime? appDate = null)
        {
            var requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appDate);
            return await QueryAsync(CreateScrobbleStartRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(requestBody));
        }

        public async Task<TraktMovieScrobblePostResponse> PauseMovieAsync(TraktMovie movie, float progress,
                                                                          string appVersion = null, DateTime? appDate = null)
        {
            var requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appDate);
            return await QueryAsync(CreateScrobblePauseRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(requestBody));
        }

        public async Task<TraktMovieScrobblePostResponse> StopMovieAsync(TraktMovie movie, float progress,
                                                                         string appVersion = null, DateTime? appDate = null)
        {
            var requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appDate);
            return await QueryAsync(CreateScrobbleStopRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(requestBody));
        }

        // TODO remove extended option
        public async Task<TraktEpisodeScrobblePostResponse> StartEpisodeAsync(TraktEpisode episode, float progress,
                                                                             string appVersion = null, DateTime? appDate = null,
                                                                             TraktExtendedOption extended = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appDate);
            return await QueryAsync(CreateScrobbleStartRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody, extended));
        }

        // TODO remove extended option
        public async Task<TraktEpisodeScrobblePostResponse> PauseEpisodeAsync(TraktEpisode episode, float progress,
                                                                              string appVersion = null, DateTime? appDate = null,
                                                                              TraktExtendedOption extended = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appDate);
            return await QueryAsync(CreateScrobblePauseRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody, extended));
        }

        // TODO remove extended option
        public async Task<TraktEpisodeScrobblePostResponse> StopEpisodeAsync(TraktEpisode episode, float progress,
                                                                             string appVersion = null, DateTime? appDate = null,
                                                                             TraktExtendedOption extended = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appDate);
            return await QueryAsync(CreateScrobbleStopRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody, extended));
        }

        // TODO remove extended option
        public async Task<TraktEpisodeScrobblePostResponse> StartEpisodeWithShowAsync(TraktEpisode episode, TraktShow show, float progress,
                                                                                      string appVersion = null, DateTime? appDate = null,
                                                                                      TraktExtendedOption extended = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appDate);
            return await QueryAsync(CreateScrobbleStartRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody, extended));
        }

        // TODO remove extended option
        public async Task<TraktEpisodeScrobblePostResponse> PauseEpisodeWithShowAsync(TraktEpisode episode, TraktShow show, float progress,
                                                                                      string appVersion = null, DateTime? appDate = null,
                                                                                      TraktExtendedOption extended = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appDate);
            return await QueryAsync(CreateScrobblePauseRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody, extended));
        }

        // TODO remove extended option
        public async Task<TraktEpisodeScrobblePostResponse> StopEpisodeWithShowAsync(TraktEpisode episode, TraktShow show, float progress,
                                                                                     string appVersion = null, DateTime? appDate = null,
                                                                                     TraktExtendedOption extended = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appDate);
            return await QueryAsync(CreateScrobbleStopRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody, extended));
        }

        private TraktScrobbleStartRequest<T, U> CreateScrobbleStartRequest<T, U>(U requestBody,
                                                                                 TraktExtendedOption extended = null) where U : TraktScrobblePost
        {
            return new TraktScrobbleStartRequest<T, U>(Client)
            {
                RequestBody = requestBody,
                ExtendedOption = extended ?? new TraktExtendedOption()
            };
        }

        private TraktScrobblePauseRequest<T, U> CreateScrobblePauseRequest<T, U>(U requestBody,
                                                                                 TraktExtendedOption extended = null) where U : TraktScrobblePost
        {
            return new TraktScrobblePauseRequest<T, U>(Client)
            {
                RequestBody = requestBody,
                ExtendedOption = extended ?? new TraktExtendedOption()
            };
        }

        private TraktScrobbleStopRequest<T, U> CreateScrobbleStopRequest<T, U>(U requestBody,
                                                                                 TraktExtendedOption extended = null) where U : TraktScrobblePost
        {
            return new TraktScrobbleStopRequest<T, U>(Client)
            {
                RequestBody = requestBody,
                ExtendedOption = extended ?? new TraktExtendedOption()
            };
        }

        private TraktMovieScrobblePost CreateMovieScrobblePost(TraktMovie movie, float progress,
                                                               string appVersion = null, DateTime? appDate = null)
        {
            Validate(movie);

            var movieScrobblePost = new TraktMovieScrobblePost
            {
                Movie = new TraktMovie
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Ids = movie.Ids
                },
                Progress = progress
            };

            if (!string.IsNullOrEmpty(appVersion))
                movieScrobblePost.AppVersion = appVersion;

            if (appDate.HasValue)
                movieScrobblePost.AppDate = appDate.Value.ToTraktDateString();

            return movieScrobblePost;
        }

        private TraktEpisodeScrobblePost CreateEpisodeScrobblePost(TraktEpisode episode, float progress, TraktShow show = null,
                                                                   string appVersion = null, DateTime? appDate = null)
        {
            Validate(episode, show);

            var episodeScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = new TraktEpisode
                {
                    Ids = episode.Ids,
                    SeasonNumber = episode.SeasonNumber,
                    Number = episode.Number
                },
                Show = show != null ? new TraktShow { Title = show.Title } : null,
                Progress = progress
            };

            if (!string.IsNullOrEmpty(appVersion))
                episodeScrobblePost.AppVersion = appVersion;

            if (appDate.HasValue)
                episodeScrobblePost.AppDate = appDate.Value.ToTraktDateString();

            return episodeScrobblePost;
        }

        private void Validate(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentException("movie must not be null", nameof(movie));

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("movie title not valid", nameof(movie.Title));

            if (movie.Year <= 0)
                throw new ArgumentException("movie year not valid", nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentException("movie.Ids must not be null", nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie.Ids have no valid id", nameof(movie.Ids));
        }

        private void Validate(TraktEpisode episode, TraktShow show)
        {
            if (episode == null)
                throw new ArgumentException("episode must not be null", nameof(episode));

            if (episode.Ids == null || !episode.Ids.HasAnyId)
            {
                if (show == null)
                    throw new ArgumentException("episode ids not set or have no valid id - show must not be null", nameof(show));

                if (string.IsNullOrEmpty(show.Title))
                    throw new ArgumentException("episode ids not set or have no valid id  - show title not valid", nameof(show.Title));

                if (episode.SeasonNumber < 0)
                    throw new ArgumentException("episode ids not set or have no valid id  - episode season number not valid", nameof(episode.SeasonNumber));

                if (episode.Number <= 0)
                    throw new ArgumentException("episode ids not set or have no valid id  - episode number not valid", nameof(episode.Number));
            }
        }
    }
}
