namespace TraktApiSharp.Modules
{
    using Attributes;
    using Extensions;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Episodes;
    using Objects.Post.Scrobbles;
    using Objects.Post.Scrobbles.Responses;
    using Requests.WithOAuth.Scrobbles;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to scrobbles.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/scrobble">"Trakt API Doc - Scrobble"</a> section.
    /// </para>
    /// </summary>
    public class TraktScrobbleModule : TraktBaseModule
    {
        internal TraktScrobbleModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Starts watching a <see cref="TraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="TraktMovie" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movie's title is null or empty. Thrown, if the given movie has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if the given movie's ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid. Thrown, if the given progress value is not between 0 and 100.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktMovieScrobblePostResponse> StartMovieAsync([NotNull] TraktMovie movie, float progress,
                                                                          string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobbleStartRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(requestBody));
        }

        /// <summary>
        /// Pauses watching a <see cref="TraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="TraktMovie" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movie's title is null or empty. Thrown, if the given movie has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if the given movie's ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid. Thrown, if the given progress value is not between 0 and 100.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktMovieScrobblePostResponse> PauseMovieAsync([NotNull] TraktMovie movie, float progress,
                                                                          string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobblePauseRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(requestBody));
        }

        /// <summary>
        /// Stops watching a <see cref="TraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="TraktMovie" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movie's title is null or empty. Thrown, if the given movie has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if the given movie's ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid. Thrown, if the given progress value is not between 0 and 100.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktMovieScrobblePostResponse> StopMovieAsync([NotNull] TraktMovie movie, float progress,
                                                                         string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobbleStopRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePost>(requestBody));
        }

        /// <summary>
        /// Starts watching a <see cref="TraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null or if the given episode's ids are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktEpisodeScrobblePostResponse> StartEpisodeAsync([NotNull] TraktEpisode episode, float progress,
                                                                              string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobbleStartRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody));
        }

        /// <summary>
        /// Pauses watching a <see cref="TraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null or if the given episode's ids are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktEpisodeScrobblePostResponse> PauseEpisodeAsync([NotNull] TraktEpisode episode, float progress,
                                                                              string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobblePauseRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody));
        }

        /// <summary>
        /// Stops watching a <see cref="TraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null or if the given episode's ids are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktEpisodeScrobblePostResponse> StopEpisodeAsync([NotNull] TraktEpisode episode, float progress,
                                                                             string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobbleStopRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody));
        }

        /// <summary>
        /// Starts watching a <see cref="TraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, which will be scrobbled.</param>
        /// <param name="show">The <see cref="TraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktEpisodeScrobblePostResponse> StartEpisodeWithShowAsync([NotNull] TraktEpisode episode, TraktShow show, float progress,
                                                                                      string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobbleStartRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody));
        }

        /// <summary>
        /// Pauses watching a <see cref="TraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, which will be scrobbled.</param>
        /// <param name="show">The <see cref="TraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktEpisodeScrobblePostResponse> PauseEpisodeWithShowAsync([NotNull] TraktEpisode episode, TraktShow show, float progress,
                                                                                      string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobblePauseRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody));
        }

        /// <summary>
        /// Stops watching a <see cref="TraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, which will be scrobbled.</param>
        /// <param name="show">The <see cref="TraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <returns>An <see cref="TraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktEpisodeScrobblePostResponse> StopEpisodeWithShowAsync([NotNull] TraktEpisode episode, TraktShow show, float progress,
                                                                                     string appVersion = null, DateTime? appBuildDate = null)
        {
            var requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appBuildDate);
            return await QueryAsync(CreateScrobbleStopRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>(requestBody));
        }

        private TraktScrobbleStartRequest<T, U> CreateScrobbleStartRequest<T, U>(U requestBody) where U : TraktScrobblePost
        {
            return new TraktScrobbleStartRequest<T, U>(Client) { RequestBody = requestBody };
        }

        private TraktScrobblePauseRequest<T, U> CreateScrobblePauseRequest<T, U>(U requestBody) where U : TraktScrobblePost
        {
            return new TraktScrobblePauseRequest<T, U>(Client) { RequestBody = requestBody };
        }

        private TraktScrobbleStopRequest<T, U> CreateScrobbleStopRequest<T, U>(U requestBody) where U : TraktScrobblePost
        {
            return new TraktScrobbleStopRequest<T, U>(Client) { RequestBody = requestBody };
        }

        private TraktMovieScrobblePost CreateMovieScrobblePost(TraktMovie movie, float progress,
                                                               string appVersion = null, DateTime? appDate = null)
        {
            Validate(movie);
            ValidateProgress(progress);

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
            ValidateProgress(progress);

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
                throw new ArgumentNullException(nameof(movie), "movie must not be null");

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("movie title not valid", nameof(movie.Title));

            if (movie.Year <= 0 || movie.Year.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(movie), "movie year not valid");

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids), "movie.Ids must not be null");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie.Ids have no valid id", nameof(movie.Ids));
        }

        private void Validate(TraktEpisode episode, TraktShow show)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode), "episode must not be null");

            if (episode.Ids == null || !episode.Ids.HasAnyId)
            {
                if (show == null)
                    throw new ArgumentNullException(nameof(show), "episode ids not set or have no valid id - show must not be null");

                if (string.IsNullOrEmpty(show.Title))
                    throw new ArgumentException("episode ids not set or have no valid id  - show title not valid", nameof(show.Title));

                if (episode.SeasonNumber < 0)
                    throw new ArgumentOutOfRangeException(nameof(episode.SeasonNumber), "episode ids not set or have no valid id  - episode season number not valid");

                if (episode.Number <= 0)
                    throw new ArgumentOutOfRangeException(nameof(episode.Number), "episode ids not set or have no valid id  - episode number not valid");
            }
        }

        private void ValidateProgress(float progress)
        {
            if (progress.CompareTo(0.0f) < 0 || progress.CompareTo(100.0f) > 0)
                throw new ArgumentOutOfRangeException(nameof(progress), "progress value not valid - value must be between 0 and 100");
        }
    }
}
