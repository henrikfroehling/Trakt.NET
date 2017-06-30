namespace TraktApiSharp.Objects.Post.Responses.Implementations
{
    using Get.People;

    public class TraktPostResponseNotFoundPerson : ITraktPostResponseNotFoundPerson
    {
        public ITraktPersonIds Ids { get; set; }
    }
}
