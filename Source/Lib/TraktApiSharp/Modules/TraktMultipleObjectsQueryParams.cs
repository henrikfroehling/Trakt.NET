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
        public void Add(string id, TraktExtendedOption extended = null)
        {
            Add(new TraktObjectsQueryParams(id, extended));
        }
    }

    public struct TraktObjectsQueryParams
    {
        public TraktObjectsQueryParams(string id, TraktExtendedOption extended)
        {
            Id = id;
            ExtendedOption = extended;
        }

        public string Id { get; }

        public TraktExtendedOption ExtendedOption { get; }
    }
}
