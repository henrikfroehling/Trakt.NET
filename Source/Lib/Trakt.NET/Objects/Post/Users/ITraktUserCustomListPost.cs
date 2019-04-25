namespace TraktNet.Objects.Post.Users
{
    using Enums;
    using Requests.Interfaces;

    /// <summary>An episode custom list post.</summary>
    public interface ITraktUserCustomListPost : IRequestBody
    {
        /// <summary>Gets or sets the required name of the custom list.</summary>
        string Name { get; set; }

        /// <summary>Gets or sets the optional description of the custom list.<para>Nullable</para></summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the optional privacy setting of the custom list.
        /// See also <seealso cref="TraktAccessScope" />.
        /// <para>Nullable</para>
        /// </summary>
        TraktAccessScope Privacy { get; set; }

        /// <summary>Gets or sets, whether the custom list should display numbers.</summary>
        bool? DisplayNumbers { get; set; }

        /// <summary>Gets or sets, whether the custom list allows comments.</summary>
        bool? AllowComments { get; set; }

        /// <summary>Gets or sets the custom list sort-by setting.</summary>
        string SortBy { get; set; }

        /// <summary>Gets or sets the custom list sort-how setting.</summary>
        string SortHow { get; set; }
    }
}
