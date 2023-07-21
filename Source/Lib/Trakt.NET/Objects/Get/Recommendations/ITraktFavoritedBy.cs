namespace TraktNet.Objects.Get.Recommendations
{
    using Users;

    /// <summary>A Trakt favorited by entry.</summary>
    public interface ITraktFavoritedBy
    {
        /// <summary>A Trakt user who favorited the movie or show. See also <seealso cref="ITraktUser" />.<para>Nullable</para></summary>
        ITraktUser User { get; set; }

        /// <summary>Gets or sets the notes of the user who favorited this.<para>Nullable</para></summary>
        string Notes { get; set; }
    }
}
