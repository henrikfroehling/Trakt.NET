namespace TraktApiSharp.Requests.WithOAuth.Shows
{
    using Base.Get;
    using Objects.Get.Shows;

    internal class TraktShowCollectionProgressRequest : TraktGetByIdRequest<TraktShowCollectionProgress, TraktShowCollectionProgress>
    {
        public TraktShowCollectionProgressRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        internal bool Hidden { get; set; }

        internal bool Specials { get; set; }

        protected override string UriTemplate => "shows/{id}/progress/collection";
    }
}
