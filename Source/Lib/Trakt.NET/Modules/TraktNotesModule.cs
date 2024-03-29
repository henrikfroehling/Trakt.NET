namespace TraktNet.Modules
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Notes;
    using TraktNet.Requests.Handler;
    using TraktNet.Requests.Notes.OAuth;
    using TraktNet.Responses;

    /// <summary>
    /// Provides access to data retrieving methods specific to notes.
    /// <para>
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/notes">"Trakt API Doc - Notes"</a> section.
    /// </para>
    /// </summary>
    public class TraktNotesModule : ATraktModule
    {
        internal TraktNotesModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Adds notes for a <see cref="ITraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">An <see cref="ITraktMovie" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddMovieNoteAsync(ITraktMovie movie, string notes, bool? spoiler = null,
                                                                 TraktListPrivacy privacy = null,
                                                                 CancellationToken cancellationToken = default)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Movie = movie
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for a <see cref="ITraktShow" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="show">An <see cref="ITraktShow" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddShowNoteAsync(ITraktShow show, string notes, bool? spoiler = null,
                                                                TraktListPrivacy privacy = null,
                                                                CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Show = show
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for a <see cref="ITraktSeason" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="season">An <see cref="ITraktSeason" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddSeasonNoteAsync(ITraktSeason season, string notes, bool? spoiler = null,
                                                                  TraktListPrivacy privacy = null,
                                                                  CancellationToken cancellationToken = default)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Season = season
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for an <see cref="ITraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">An <see cref="ITraktEpisode" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddEpisodeNoteAsync(ITraktEpisode episode, string notes, bool? spoiler = null,
                                                                   TraktListPrivacy privacy = null,
                                                                   CancellationToken cancellationToken = default)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Episode = episode
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for a <see cref="ITraktPerson" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="person">An <see cref="ITraktPerson" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="person"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddPersonNoteAsync(ITraktPerson person, string notes, bool? spoiler = null,
                                                                  TraktListPrivacy privacy = null,
                                                                  CancellationToken cancellationToken = default)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Person = person
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for an history item.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="historyID">The ID of the history item for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddHistoryNoteAsync(ulong historyID, string notes, bool? spoiler = null,
                                                                   TraktListPrivacy privacy = null,
                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        AttachedTo = new TraktNoteAttachedTo
                        {
                            Type = TraktNotesObjectType.History,
                            Id = historyID
                        }
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for a collection <see cref="ITraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">An <see cref="ITraktMovie" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddCollectionMovieNoteAsync(ITraktMovie movie, string notes, bool? spoiler = null,
                                                                           TraktListPrivacy privacy = null,
                                                                           CancellationToken cancellationToken = default)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Movie = movie,
                        AttachedTo = new TraktNoteAttachedTo
                        {
                            Type = TraktNotesObjectType.Collection
                        }
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for a collection <see cref="ITraktShow" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="show">An <see cref="ITraktShow" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddCollectionShowNoteAsync(ITraktShow show, string notes, bool? spoiler = null,
                                                                          TraktListPrivacy privacy = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Show = show,
                        AttachedTo = new TraktNoteAttachedTo
                        {
                            Type = TraktNotesObjectType.Collection
                        }
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for a rated <see cref="ITraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">An <see cref="ITraktMovie" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddRatedMovieNoteAsync(ITraktMovie movie, string notes, bool? spoiler = null,
                                                                      TraktListPrivacy privacy = null,
                                                                      CancellationToken cancellationToken = default)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Movie = movie,
                        AttachedTo = new TraktNoteAttachedTo
                        {
                            Type = TraktNotesObjectType.Rating
                        }
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for a rated <see cref="ITraktShow" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="show">An <see cref="ITraktShow" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddRatedShowNoteAsync(ITraktShow show, string notes, bool? spoiler = null,
                                                                     TraktListPrivacy privacy = null,
                                                                     CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Show = show,
                        AttachedTo = new TraktNoteAttachedTo
                        {
                            Type = TraktNotesObjectType.Rating
                        }
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for a rated <see cref="ITraktSeason" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="season">An <see cref="ITraktSeason" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddRatedSeasonNoteAsync(ITraktSeason season, string notes, bool? spoiler = null,
                                                                       TraktListPrivacy privacy = null,
                                                                       CancellationToken cancellationToken = default)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Season = season,
                        AttachedTo = new TraktNoteAttachedTo
                        {
                            Type = TraktNotesObjectType.Rating
                        }
                    }
                }, cancellationToken);
        }

        /// <summary>
        /// Adds notes for an rated <see cref="ITraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/notes/add-notes">"Trakt API Doc - Notes: Add notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">An <see cref="ITraktEpisode" /> instance for which the notes will be attached.</param>
        /// <param name="notes">The content of the created note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the created user notes entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> AddRatedEpisodeNoteAsync(ITraktEpisode episode, string notes, bool? spoiler = null,
                                                                        TraktListPrivacy privacy = null,
                                                                        CancellationToken cancellationToken = default)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NotesAddRequest
                {
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        Episode = episode,
                        AttachedTo = new TraktNoteAttachedTo
                        {
                            Type = TraktNotesObjectType.Rating
                        }
                    }
                }, cancellationToken);
        }
    }
}
