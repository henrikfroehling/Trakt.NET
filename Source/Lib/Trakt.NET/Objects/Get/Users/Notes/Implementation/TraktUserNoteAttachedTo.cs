﻿namespace TraktNet.Objects.Get.Users.Notes
{
    using Enums;

    /// <summary>Contains information about to which media a Trakt user note is attached.</summary>
    public class TraktUserNoteAttachedTo : ITraktUserNoteAttachedTo
    {
        /// <summary>Gets or sets the media type to which a note is attached. See also <seealso cref="TraktNotesObjectType" />.</summary>
        public TraktNotesObjectType Type { get; set; }

        /// <summary>
        /// Gets or sets the history id of the history item,
        /// if <see cref="Type" /> is set to <see cref="TraktNotesObjectType.History" />
        /// and a note is attached to an history item.
        /// </summary>
        public ulong? Id { get; set; }
    }
}
