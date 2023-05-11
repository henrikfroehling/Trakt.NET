namespace TraktNet.Objects.Basic
{
    /// <summary>A Trakt studio.</summary>
    public interface ITraktStudio
    {
        /// <summary>Gets or sets the studio name.<para>Nullable</para></summary>
        string Name { get; set; }

        /// <summary>Gets or sets the content country code of the studio.<para>Nullable</para></summary>
        string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the studio for various web services.
        /// See also <seealso cref="ITraktStudioIds" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktStudioIds Ids { get; set; }
    }
}
