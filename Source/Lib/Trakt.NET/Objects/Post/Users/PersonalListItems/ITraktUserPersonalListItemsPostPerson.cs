namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    using TraktNet.Objects.Get.People;

    /// <summary>An user personal list items post person, containing the required person ids.</summary>
    public interface ITraktUserPersonalListItemsPostPerson
    {
        /// <summary>Gets or sets the required person ids. See also <seealso cref="ITraktPersonIds" />.</summary>
        ITraktPersonIds Ids { get; set; }

        /// <summary>Gets or sets the person notes.</summary>
        string Notes { get; set; }
    }
}
