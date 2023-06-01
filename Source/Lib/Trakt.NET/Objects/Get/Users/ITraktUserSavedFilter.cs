namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using System;

    /// <summary>A Trakt user saved filter.</summary>
    public interface ITraktUserSavedFilter
    {
        /// <summary>Gets or sets the id of the saved filter.</summary>
        int Id { get; set; }

        /// <summary>Gets or sets the rank of the saved filter.</summary>
        int? Rank { get; set; }

        /// <summary>
        /// Gets or sets the filter section of the saved filter.
        /// See also <seealso cref="TraktFilterSection" />.<para>Nullable</para>
        /// </summary>
        TraktFilterSection Section { get; set; }

        /// <summary>Gets or sets the name of the saved filter.<para>Nullable</para></summary>
        string Name { get; set; }

        /// <summary>Gets or sets the path of the saved filter.<para>Nullable</para></summary>
        string Path { get; set; }

        /// <summary>Gets or sets the query of the saved filter.<para>Nullable</para></summary>
        string Query { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the saved filter was updated.</summary>
        DateTime? UpdatedAt { get; set; }
    }
}
