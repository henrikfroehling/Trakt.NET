namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using System;

    /// <summary>A Trakt user saved filter.</summary>
    public class TraktUserSavedFilter : ITraktUserSavedFilter
    {
        /// <summary>Gets or sets the id of the saved filter.</summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the filter section of the saved filter.
        /// See also <seealso cref="TraktFilterSection" />.<para>Nullable</para>
        /// </summary>
        public TraktFilterSection Section { get; set; }

        /// <summary>Gets or sets the name of the saved filter.<para>Nullable</para></summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the path of the saved filter.<para>Nullable</para></summary>
        public string Path { get; set; }

        /// <summary>Gets or sets the query of the saved filter.<para>Nullable</para></summary>
        public string Query { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the saved filter was updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
