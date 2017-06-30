namespace TraktApiSharp.Objects.Post.Responses.Implementations
{
    using Get.Shows;

    public class TraktPostResponseNotFoundShow : ITraktPostResponseNotFoundShow
    {
        public ITraktShowIds Ids { get; set; }
    }
}
