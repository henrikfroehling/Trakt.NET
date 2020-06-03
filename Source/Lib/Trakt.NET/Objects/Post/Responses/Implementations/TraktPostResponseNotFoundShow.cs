namespace TraktNet.Objects.Post.Responses
{
    using Get.Shows;

    /// <summary>A Trakt show, which was not found.</summary>
    public class TraktPostResponseNotFoundShow : ITraktPostResponseNotFoundShow
    {
        /// <summary>Gets or sets the ids of the not found show. See also <seealso cref="ITraktShowIds" />.</summary>
        public ITraktShowIds Ids { get; set; }
    }
}
