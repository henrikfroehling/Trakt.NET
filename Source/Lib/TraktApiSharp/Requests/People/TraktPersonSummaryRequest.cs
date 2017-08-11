namespace TraktApiSharp.Requests.People
{
    using Objects.Get.People;

    internal sealed class TraktPersonSummaryRequest : ATraktPersonRequest<ITraktPerson>
    {
        public override string UriTemplate => "people/{id}{?extended}";
    }
}
