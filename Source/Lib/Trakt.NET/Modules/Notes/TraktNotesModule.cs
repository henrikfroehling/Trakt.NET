namespace TraktNet.Modules
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Notes;
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
    public partial class TraktNotesModule : ATraktModule
    {
        internal TraktNotesModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Returns a single note.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/note/get-a-note">"Trakt API Doc - Note: Get a note"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="noteId">The id of the note which should is requested.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the requested note.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> GetNoteAsync(ulong noteId, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NoteGetRequest
                {
                    Id = noteId
                }, cancellationToken);
        }

        /// <summary>
        /// Update a single note (500 maximum characters).
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/notes/note/update-a-note">"Trakt API Doc - Note: Update a note"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="noteId">The id of the note which should be updated.</param>
        /// <param name="notes">The new content of the note.</param>
        /// <param name="spoiler">Optional parameter which determines whether the note contains any spoilers.</param>
        /// <param name="privacy">Optional parameter determining the privacy setting of the note.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktNote" /> instance, which contains information about the requested note.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktNote>> UpdateNoteAsync(ulong noteId, string notes, bool? spoiler = null,
                                                               TraktListPrivacy privacy = null,
                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(
                new NoteUpdateRequest
                {
                    Id = noteId,
                    RequestBody = new TraktNotePost
                    {
                        Notes = notes,
                        Spoiler = spoiler,
                        Privacy = privacy,
                        IgnoreCompleteValidation = true
                    }
                }, cancellationToken);
        }
    }
}
