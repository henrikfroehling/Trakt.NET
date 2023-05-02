namespace TraktNet.Requests.Shows
{
    using Objects.Get.Shows;

    internal sealed class ShowCertificationsRequest : AShowRequest<ITraktShowCertification>
    {
        public override string UriTemplate => "shows/{id}/certifications";
    }
}
