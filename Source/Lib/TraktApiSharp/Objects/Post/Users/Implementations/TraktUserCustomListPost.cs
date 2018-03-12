namespace TraktApiSharp.Objects.Post.Users.Implementations
{
    using Enums;
    using System.Net.Http;

    /// <summary>An episode custom list post.</summary>
    public class TraktUserCustomListPost : ITraktUserCustomListPost
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

        public string HttpContentAsString => throw new System.NotImplementedException();

        public HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public void Validate() => throw new System.NotImplementedException();
    }
}
