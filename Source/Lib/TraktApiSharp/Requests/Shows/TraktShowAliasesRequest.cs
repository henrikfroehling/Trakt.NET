namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows;

    internal sealed class TraktShowAliasesRequest : AShowRequest<ITraktShowAlias>
    {
        public override string UriTemplate => "shows/{id}/aliases";
    }
}
