namespace TraktApiSharp.Modules
{
    using Requests.Params;

    /// <summary>
    /// Collection containing multiple different combinations of ids and extended infos.
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new TraktMultipleObjectsQueryParams
    /// {
    ///     // { id[, extended info] }
    ///     "id-1",
    ///     { "id-2", new TraktExtendedInfo { Full = true } },
    ///     "id-3"
    /// };
    /// </code>
    /// </example>
    public class TraktMultipleObjectsQueryParams : TraktMultipleQueryParams<TraktObjectsQueryParams>
    {
        /// <summary>Adds a new object query parameter pack to the collection.</summary>
        /// <param name="idOrSlug">A Trakt id or slug.</param>
        /// <param name="extendedInfo">An optional extended info. See also <see cref="TraktExtendedInfo" />.</param>
        public void Add(string idOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Add(new TraktObjectsQueryParams(idOrSlug, extendedInfo));
        }
    }

    /// <summary>
    /// A single query parameter for multiple object queries.
    /// Contains a combination of a id or slug and an optional extended info.
    /// </summary>
    public struct TraktObjectsQueryParams
    {
        /// <summary>Initializes a new instance of the <see cref="TraktSeasonsQueryParams" /> class.</summary>
        /// <param name="idOrSlug">A Trakt id or slug.</param>
        /// <param name="extendedInfo">An optional extended info. See also <see cref="TraktExtendedInfo" />.</param>
        public TraktObjectsQueryParams(string idOrSlug, TraktExtendedInfo extendedInfo)
        {
            Id = idOrSlug;
            ExtendedInfo = extendedInfo;
        }

        /// <summary>Returns the Trakt id or slug.</summary>
        public string Id { get; }

        /// <summary>
        /// Returns the optional extended info.
        /// <para>Nullable.</para>
        /// </summary>
        public TraktExtendedInfo ExtendedInfo { get; }
    }
}
