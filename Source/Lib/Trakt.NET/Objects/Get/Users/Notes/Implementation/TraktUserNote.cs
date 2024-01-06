namespace TraktNet.Objects.Get.Users.Notes
{
    using Enums;
    using System;

    /// <summary>A Trakt user note.</summary>
    public class TraktUserNote : ITraktUserNote
    {
        /// <summary>Gets or sets the id of the note.</summary>
        public ulong Id { get; set; }

        /// <summary>Gets or sets the content of the note.</summary>
        public string Notes { get; set; }

        /// <summary>Gets or sets the privacy setting of the note.</summary>
        public TraktListPrivacy Privacy { get; set; }

        /// <summary>Gets or sets whether the note contains any spoilers.</summary>
        public bool? Spoiler { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the note was created.</summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the note was updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user, who wrote the note. See also <seealso cref="ITraktUser" />.
        /// </summary>
        public ITraktUser User { get; set; }
    }
}
