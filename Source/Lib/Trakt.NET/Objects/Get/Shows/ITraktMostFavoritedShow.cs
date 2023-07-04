namespace TraktNet.Objects.Get.Shows
{
    /// <summary>A favorited Trakt show.</summary>
    public interface ITraktMostFavoritedShow : ITraktShow
    {
        /// <summary>Gets or sets the user count for the <see cref="Show" />.</summary>
        int? UserCount { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        ITraktShow Show { get; set; }
    }
}
