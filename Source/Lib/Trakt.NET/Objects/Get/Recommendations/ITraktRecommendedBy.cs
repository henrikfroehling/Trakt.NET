namespace TraktNet.Objects.Get.Recommendations
{
    using Users;

    /// <summary>A Trakt recommended by entry.</summary>
    public interface ITraktRecommendedBy
    {
        /// <summary>A Trakt user who recommended the movie or show. See also <seealso cref="ITraktUser" />.<para>Nullable</para></summary>
        ITraktUser User { get; set; }

        /// <summary>Gets or sets the notes of the user who recommended this.<para>Nullable</para></summary>
        string Notes { get; set; }
    }
}
