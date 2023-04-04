namespace TraktNet.Objects.Get.Recommendations
{
    using Users;

    /// <summary>A Trakt recommended by entry.</summary>
    public class TraktRecommendedBy : ITraktRecommendedBy
    {
        /// <summary>A Trakt user who recommended the movie or show. See also <seealso cref="ITraktUser" />.<para>Nullable</para></summary>
        public ITraktUser User { get; set; }

        /// <summary>Gets or sets the notes of the user who recommended this.<para>Nullable</para></summary>
        public string Notes { get; set; }
    }
}
