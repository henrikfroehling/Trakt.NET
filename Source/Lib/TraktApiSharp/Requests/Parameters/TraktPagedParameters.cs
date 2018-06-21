namespace TraktNet.Requests.Parameters
{
    public sealed class TraktPagedParameters
    {
        public TraktPagedParameters(uint? page = null, uint? limit = null)
        {
            Page = page;
            Limit = limit;
        }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }
    }
}
