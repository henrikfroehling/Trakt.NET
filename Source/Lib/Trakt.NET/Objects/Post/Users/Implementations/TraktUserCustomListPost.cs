namespace TraktNet.Objects.Post.Users
{
    using Enums;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>An episode custom list post.</summary>
    public class TraktUserCustomListPost : ITraktUserPersonalListPost
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

        /// <summary>Gets or sets the custom list sort-by setting.</summary>
        public string SortBy { get; set; }

        /// <summary>Gets or sets the custom list sort-how setting.</summary>
        public string SortHow { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktUserPersonalListPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktUserPersonalListPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            // TODO
        }
    }
}
