namespace TraktNet.Modules
{
    using Exceptions;
    using Extensions;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Scrobbles;
    using Objects.Post.Scrobbles.Responses;
    using Requests.Handler;
    using Requests.Interfaces;
    using Requests.Scrobbles.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to scrobbles.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/scrobble">"Trakt API Doc - Scrobble"</a> section.
    /// </para>
    /// </summary>
    public class TraktScrobbleModule : ATraktModule
    {
        internal TraktScrobbleModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Starts watching a <see cref="ITraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="ITraktMovie" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movie's title is null or empty. Thrown, if the given movie has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if the given movie's ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid. Thrown, if the given progress value is not between 0 and 100.</exception>
        public Task<TraktResponse<ITraktMovieScrobblePostResponse>> StartMovieAsync(ITraktMovie movie, float progress,
                                                                                    string appVersion = null, DateTime? appBuildDate = null,
                                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktMovieScrobblePost requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStartRequest<ITraktMovieScrobblePostResponse, ITraktMovieScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Pauses watching a <see cref="ITraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="ITraktMovie" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movie's title is null or empty. Thrown, if the given movie has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if the given movie's ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid. Thrown, if the given progress value is not between 0 and 100.</exception>
        public Task<TraktResponse<ITraktMovieScrobblePostResponse>> PauseMovieAsync(ITraktMovie movie, float progress,
                                                                                    string appVersion = null, DateTime? appBuildDate = null,
                                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktMovieScrobblePost requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobblePauseRequest<ITraktMovieScrobblePostResponse, ITraktMovieScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Stops watching a <see cref="ITraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="ITraktMovie" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movie's title is null or empty. Thrown, if the given movie has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if the given movie's ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid. Thrown, if the given progress value is not between 0 and 100.</exception>
        public Task<TraktResponse<ITraktMovieScrobblePostResponse>> StopMovieAsync(ITraktMovie movie, float progress,
                                                                                   string appVersion = null, DateTime? appBuildDate = null,
                                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktMovieScrobblePost requestBody = CreateMovieScrobblePost(movie, progress, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStopRequest<ITraktMovieScrobblePostResponse, ITraktMovieScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Starts watching a <see cref="ITraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null or if the given episode's ids are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> StartEpisodeAsync(ITraktEpisode episode, float progress,
                                                                                        string appVersion = null, DateTime? appBuildDate = null,
                                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStartRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Pauses watching a <see cref="ITraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null or if the given episode's ids are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> PauseEpisodeAsync(ITraktEpisode episode, float progress,
                                                                                        string appVersion = null, DateTime? appBuildDate = null,
                                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobblePauseRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Stops watching a <see cref="ITraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be scrobbled.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null or if the given episode's ids are null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> StopEpisodeAsync(ITraktEpisode episode, float progress,
                                                                                       string appVersion = null, DateTime? appBuildDate = null,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(episode, progress, null, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStopRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Starts watching a <see cref="ITraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be scrobbled.</param>
        /// <param name="show">The <see cref="ITraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> StartEpisodeWithShowAsync(ITraktEpisode episode, ITraktShow show, float progress,
                                                                                                string appVersion = null, DateTime? appBuildDate = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStartRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Starts watching a <see cref="ITraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="absoluteEpisodeNumber">The absolute number of the episode, which will be scrobbled.</param>
        /// <param name="show">The <see cref="ITraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> StartEpisodeWithShowAsync(int absoluteEpisodeNumber, ITraktShow show, float progress,
                                                                                                string appVersion = null, DateTime? appBuildDate = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(absoluteEpisodeNumber, progress, show, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStartRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Pauses watching a <see cref="ITraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be scrobbled.</param>
        /// <param name="show">The <see cref="ITraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> PauseEpisodeWithShowAsync(ITraktEpisode episode, ITraktShow show, float progress,
                                                                                                string appVersion = null, DateTime? appBuildDate = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobblePauseRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Pauses watching a <see cref="ITraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="absoluteEpisodeNumber">The absolute number of the episode, which will be scrobbled.</param>
        /// <param name="show">The <see cref="ITraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> PauseEpisodeWithShowAsync(int absoluteEpisodeNumber, ITraktShow show, float progress,
                                                                                                string appVersion = null, DateTime? appBuildDate = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(absoluteEpisodeNumber, progress, show, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobblePauseRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Stops watching a <see cref="ITraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be scrobbled.</param>
        /// <param name="show">The <see cref="ITraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> StopEpisodeWithShowAsync(ITraktEpisode episode, ITraktShow show, float progress,
                                                                                               string appVersion = null, DateTime? appBuildDate = null,
                                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(episode, progress, show, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStopRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        /// <summary>
        /// Stops watching a <see cref="ITraktEpisode" /> in a media center. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="absoluteEpisodeNumber">The absolute number of the episode, which will be scrobbled.</param>
        /// <param name="show">The <see cref="ITraktShow" />, which will be used to scrobble the given episode.</param>
        /// <param name="progress">The watching progress. Should be a value between 0 and 100.</param>
        /// <param name="appVersion">Optional application version for the scrobble.</param>
        /// <param name="appBuildDate">Optional application build date for the scrobble. Will be converted to the Trakt date-format.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if the given episode's ids are null and the given show is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if given show's title is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given episode's season number is below zero or the given episode's number is below one.
        /// Thrown, if the given progress value is not between 0 and 100.
        /// </exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> StopEpisodeWithShowAsync(int absoluteEpisodeNumber, ITraktShow show, float progress,
                                                                                               string appVersion = null, DateTime? appBuildDate = null,
                                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            ITraktEpisodeScrobblePost requestBody = CreateEpisodeScrobblePost(absoluteEpisodeNumber, progress, show, appVersion, appBuildDate);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStopRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(requestBody), cancellationToken);
        }

        private ScrobbleStartRequest<T, U> CreateScrobbleStartRequest<T, U>(U requestBody) where U : ITraktScrobblePost, IRequestBody
            => new ScrobbleStartRequest<T, U> { RequestBody = requestBody };

        private ScrobblePauseRequest<T, U> CreateScrobblePauseRequest<T, U>(U requestBody) where U : ITraktScrobblePost, IRequestBody
            => new ScrobblePauseRequest<T, U> { RequestBody = requestBody };

        private ScrobbleStopRequest<T, U> CreateScrobbleStopRequest<T, U>(U requestBody) where U : ITraktScrobblePost, IRequestBody
            => new ScrobbleStopRequest<T, U> { RequestBody = requestBody };

        private ITraktMovieScrobblePost CreateMovieScrobblePost(ITraktMovie movie, float progress, string appVersion = null, DateTime? appDate = null)
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

        private ITraktEpisodeScrobblePost CreateEpisodeScrobblePost(ITraktEpisode episode, float progress, ITraktShow show = null,
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
                Show = show != null
                    ? new TraktShow
                      {
                          Title = show.Title,
                          Ids = show.Ids
                      }
                    : null,
                Progress = progress
            };

            if (!string.IsNullOrEmpty(appVersion))
                episodeScrobblePost.AppVersion = appVersion;

            if (appDate.HasValue)
                episodeScrobblePost.AppDate = appDate.Value.ToTraktDateString();

            return episodeScrobblePost;
        }

        private ITraktEpisodeScrobblePost CreateEpisodeScrobblePost(int absoluteEpisodeNumber, float progress, ITraktShow show = null,
                                                                    string appVersion = null, DateTime? appDate = null)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show), "show must not be null");

            ValidateProgress(progress);

            var episodeScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = new TraktEpisode
                {
                    NumberAbsolute = absoluteEpisodeNumber
                },
                Show = show != null
                    ? new TraktShow
                    {
                        Title = show.Title,
                        Ids = show.Ids
                    }
                    : null,
                Progress = progress
            };

            if (!string.IsNullOrEmpty(appVersion))
                episodeScrobblePost.AppVersion = appVersion;

            if (appDate.HasValue)
                episodeScrobblePost.AppDate = appDate.Value.ToTraktDateString();

            return episodeScrobblePost;
        }

        private void Validate(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "movie must not be null");

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie), "movie.Ids must not be null");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie.Ids have no valid id", nameof(movie));
        }

        private void Validate(ITraktEpisode episode, ITraktShow show)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode), "episode must not be null");

            if (episode.Ids == null || !episode.Ids.HasAnyId)
            {
                if (show == null)
                    throw new ArgumentNullException(nameof(show), "episode ids not set or have no valid id - show must not be null");

                if (string.IsNullOrEmpty(show.Title))
                    throw new ArgumentException("episode ids not set or have no valid id  - show title not valid", nameof(show));

                if (episode.SeasonNumber < 0)
                    throw new ArgumentOutOfRangeException(nameof(episode), "episode ids not set or have no valid id  - episode season number not valid");

                if (episode.Number <= 0)
                    throw new ArgumentOutOfRangeException(nameof(episode), "episode ids not set or have no valid id  - episode number not valid");
            }
        }

        private void ValidateProgress(float progress)
        {
            if (progress.CompareTo(0.0f) < 0 || progress.CompareTo(100.0f) > 0)
                throw new ArgumentOutOfRangeException(nameof(progress), "progress value not valid - value must be between 0 and 100");
        }
    }
}
