namespace TraktNet.Objects.Get.Shows
{
    using System;

    /// <summary>An updated Trakt show.</summary>
    public interface ITraktRecentlyUpdatedShow : ITraktShow
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Show" /> was updated.</summary>
        DateTime? RecentlyUpdatedAt { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        ITraktShow Show { get; set; }
    }
}
