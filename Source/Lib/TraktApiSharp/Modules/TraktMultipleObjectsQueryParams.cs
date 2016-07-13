namespace TraktApiSharp.Modules
{
    using Requests.Params;
    using Utils;

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
