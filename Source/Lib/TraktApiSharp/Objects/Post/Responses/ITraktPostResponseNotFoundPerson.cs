namespace TraktNet.Objects.Post.Responses
{
    using Get.People;

    public interface ITraktPostResponseNotFoundPerson
    {
        ITraktPersonIds Ids { get; set; }
    }
}
