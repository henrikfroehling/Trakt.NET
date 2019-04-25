namespace TraktNet.Requests.Parameters
{
    /// <summary>
    /// Container class for pagination parameters.
    /// <para>
    /// See <a href ="https://trakt.docs.apiary.io/#introduction/pagination">"Trakt API Doc - Pagination"</a> for more information.
    /// </para>
    /// </summary>
    public sealed class TraktPagedParameters
    {
        /// <summary>Initializes a new instance of <see cref="TraktPagedParameters" />.</summary>
        /// <param name="page">Number of page of results to be returned. Defaults to the first page.</param>
        /// <param name="limit">Number of results to return per page. Defaults to 10.</param>
        public TraktPagedParameters(uint? page = null, uint? limit = null)
        {
            Page = page;
            Limit = limit;
        }

        /// <summary>Number of page of results to be returned. Defaults to the first page.</summary>
        public uint? Page { get; set; }

        /// <summary>Number of results to return per page. Defaults to 10.</summary>
        public uint? Limit { get; set; }
    }
}
