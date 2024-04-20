namespace TraktNet.Objects.Get.Notes
{
    using Enums;
    using System;
    using Users;

    /// <summary>A Trakt user note.</summary>
    public interface ITraktNote
    {
        /// <summary>Gets or sets the id of the note.</summary>
        ulong Id { get; set; }

        /// <summary>Gets or sets the content of the note.</summary>
        string Notes { get; set; }

        /// <summary>Gets or sets the privacy setting of the note.</summary>
        TraktListPrivacy Privacy { get; set; }

        /// <summary>Gets or sets whether the note contains any spoilers.</summary>
        bool? Spoiler { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the note was created.</summary>
        DateTime? CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the note was updated.</summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user, who wrote the note. See also <seealso cref="ITraktUser" />.
        /// </summary>
        ITraktUser User { get; set; }
    }
}
