namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows.Implementations;

    internal sealed class TraktShowAliasesRequest : ATraktShowRequest<TraktShowAlias>
    {
        public override string UriTemplate => "shows/{id}/aliases";
    }
}
