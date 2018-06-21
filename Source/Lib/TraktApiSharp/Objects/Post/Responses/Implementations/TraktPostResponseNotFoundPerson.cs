namespace TraktNet.Objects.Post.Responses
{
    using Get.People;

    public class TraktPostResponseNotFoundPerson : ITraktPostResponseNotFoundPerson
    {
        public ITraktPersonIds Ids { get; set; }
    }
}
