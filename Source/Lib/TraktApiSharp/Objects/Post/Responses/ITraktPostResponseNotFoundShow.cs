namespace TraktApiSharp.Objects.Post.Responses
{
    using Get.Shows;

    public interface ITraktPostResponseNotFoundShow
    {
        ITraktShowIds Ids { get; set; }
    }
}
