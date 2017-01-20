namespace TraktApiSharp.Experimental.Requests.People
{
    using TraktApiSharp.Objects.Get.People;

    internal sealed class TraktPersonSummaryRequest : ATraktPersonRequest<TraktPerson>
    {
        public override string UriTemplate => "people/{id}{?extended}";
    }
}
