namespace TraktNet.Objects.Basic
{
    /// <summary>A Trakt network.</summary>
    public class TraktNetwork : ITraktNetwork
    {
        /// <summary>Gets or sets the network name.<para>Nullable</para></summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the country code for the network.<para>Nullable</para></summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the network for various web services.
        /// See also <seealso cref="ITraktNetworkIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktNetworkIds Ids { get; set; }
    }
}
