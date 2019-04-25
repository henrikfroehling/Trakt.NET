namespace TraktNet.Objects.Post.Responses
{
    using Get.People;

    /// <summary>A Trakt person, which was not found.</summary>
    public interface ITraktPostResponseNotFoundPerson
    {
        /// <summary>Gets or sets the ids of the not found person. See also <seealso cref="ITraktPersonIds" />.</summary>
        ITraktPersonIds Ids { get; set; }
    }
}
