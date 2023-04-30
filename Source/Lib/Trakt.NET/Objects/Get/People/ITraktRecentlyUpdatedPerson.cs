namespace TraktNet.Objects.Get.People
{
    using System;

    /// <summary>An updated Trakt person.</summary>
    public interface ITraktRecentlyUpdatedPerson : ITraktPerson
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Person" /> was updated.</summary>
        DateTime? RecentlyUpdatedAt { get; set; }

        /// <summary>Gets or sets the Trakt person. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        ITraktPerson Person { get; set; }
    }
}
