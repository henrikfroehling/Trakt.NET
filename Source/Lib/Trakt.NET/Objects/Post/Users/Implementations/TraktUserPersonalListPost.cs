namespace TraktNet.Objects.Post.Users
{
    using Enums;
    using Exceptions;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>An episode custom list post.</summary>
    public class TraktUserPersonalListPost : ITraktUserPersonalListPost
    {
        /// <summary>Gets or sets the required name of the custom list.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the optional description of the custom list.<para>Nullable</para></summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the optional privacy setting of the custom list.
        /// See also <seealso cref="TraktAccessScope" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktAccessScope Privacy { get; set; }

        /// <summary>Gets or sets, whether the custom list should display numbers.</summary>
        public bool? DisplayNumbers { get; set; }

        /// <summary>Gets or sets, whether the custom list allows comments.</summary>
        public bool? AllowComments { get; set; }

        /// <summary>
        /// Gets or sets the custom list sort-by setting.
        /// See also <seealso cref="TraktSortBy" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktSortBy SortBy { get; set; }

        /// <summary>
        /// Gets or sets the custom list sort-how setting.
        /// See also <seealso cref="TraktSortHow" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktSortHow SortHow { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktUserPersonalListPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktUserPersonalListPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            if (Name == null)
                throw new TraktPostValidationException(nameof(Name), "list name must not be null");

            if (Name.Length == 0)
                throw new TraktPostValidationException(nameof(Name), "list name must not be empty");

            if (Privacy != null && Privacy == TraktAccessScope.Unspecified)
                throw new TraktPostValidationException(nameof(Privacy), "Privacy must not be unspecified");
        }

        /// <summary>Returns whether the post has any values set.</summary>
        public bool HasAnyValuesSet()
        {
            return !string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(Description)
                || (Privacy != null && Privacy != TraktAccessScope.Unspecified)
                || DisplayNumbers.HasValue || AllowComments.HasValue
                || (SortBy != null && SortBy != TraktSortBy.Unspecified)
                || (SortHow != null && SortHow != TraktSortHow.Unspecified);
        }
    }
}
