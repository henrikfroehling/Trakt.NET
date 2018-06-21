namespace TraktNet.Objects.Post.Responses
{
    using Get.Shows;

    public class TraktPostResponseNotFoundShow : ITraktPostResponseNotFoundShow
    {
        public ITraktShowIds Ids { get; set; }
    }
}
