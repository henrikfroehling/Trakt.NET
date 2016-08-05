namespace TraktApiSharp.Modules
{
    using Requests.Params;

    /// <summary>
    /// Collection containing multiple different combinations of ids and extended options.
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new TraktMultipleObjectsQueryParams
    /// {
    ///     // { id[, extended option] }
    ///     "id-1",
    ///     { "id-2", new TraktExtendedOption { Full = true } },
    ///     "id-3"
    /// };
    /// </code>
    /// </example>
    public class TraktMultipleObjectsQueryParams : TraktMultipleQueryParams<TraktObjectsQueryParams>
    {
        /// <summary>Adds a new object query parameter pack to the collection.</summary>
        /// <param name="idOrSlug">A Trakt id or slug.</param>
        /// <param name="extendedOption">An optional extended option. See also <see cref="TraktExtendedOption" />.</param>
        public void Add(string idOrSlug, TraktExtendedOption extendedOption = null)
        {
            Add(new TraktObjectsQueryParams(idOrSlug, extendedOption));
        }
    }

    /// <summary>
    /// A single query parameter for multiple object queries.
    /// Contains a combination of a id or slug and an optional extended option.
    /// </summary>
    public struct TraktObjectsQueryParams
    {
        /// <summary>Initializes a new instance of the <see cref="TraktSeasonsQueryParams" /> class.</summary>
        /// <param name="idOrSlug">A Trakt id or slug.</param>
        /// <param name="extendedOption">An optional extended option. See also <see cref="TraktExtendedOption" />.</param>
        public TraktObjectsQueryParams(string idOrSlug, TraktExtendedOption extendedOption)
        {
            Id = idOrSlug;
            ExtendedOption = extendedOption;
        }

        /// <summary>Returns the Trakt id or slug.</summary>
        public string Id { get; }

        /// <summary>
        /// Returns the optional extended option.
        /// <para>Nullable.</para>
        /// </summary>
        public TraktExtendedOption ExtendedOption { get; }
    }
}
