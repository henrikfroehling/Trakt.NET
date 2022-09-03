namespace TraktNet.Objects.Post.Users
{
    using Enums;
    using Requests.Interfaces;

    /// <summary>An episode personal list post.</summary>
    public interface ITraktUserPersonalListPost : IRequestBody
    {
        /// <summary>Gets or sets the required name of the personal list.</summary>
        string Name { get; set; }

        /// <summary>Gets or sets the optional description of the personal list.<para>Nullable</para></summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the optional privacy setting of the personal list.
        /// See also <seealso cref="TraktAccessScope" />.
        /// <para>Nullable</para>
        /// </summary>
        TraktAccessScope Privacy { get; set; }

        /// <summary>Gets or sets, whether the personal list should display numbers.</summary>
        bool? DisplayNumbers { get; set; }

        /// <summary>Gets or sets, whether the personal list allows comments.</summary>
        bool? AllowComments { get; set; }

        /// <summary>Gets or sets the personal list sort-by setting.</summary>
        string SortBy { get; set; }

        /// <summary>Gets or sets the personal list sort-how setting.</summary>
        string SortHow { get; set; }
    }
}
