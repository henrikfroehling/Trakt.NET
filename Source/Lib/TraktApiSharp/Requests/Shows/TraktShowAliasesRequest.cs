namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows;

    internal sealed class TraktShowAliasesRequest : ATraktShowRequest<TraktShowAlias>
    {
        public override string UriTemplate => "shows/{id}/aliases";
    }
}
