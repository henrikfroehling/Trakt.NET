namespace TraktApiSharp.Requests.People
{
    using Objects.Get.People.Implementations;

    internal sealed class TraktPersonSummaryRequest : ATraktPersonRequest<TraktPerson>
    {
        public override string UriTemplate => "people/{id}{?extended}";
    }
}
