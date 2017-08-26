namespace TraktApiSharp.Requests.People
{
    using Objects.Get.People;

    internal sealed class TraktPersonSummaryRequest : APersonRequest<ITraktPerson>
    {
        public override string UriTemplate => "people/{id}{?extended}";
    }
}
