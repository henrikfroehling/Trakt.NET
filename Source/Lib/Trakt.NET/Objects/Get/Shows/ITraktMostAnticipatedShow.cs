namespace TraktNet.Objects.Get.Shows
{
    /// <summary>A anticipated Trakt show.</summary>
    public interface ITraktMostAnticipatedShow : ITraktShow
    {
        /// <summary>Gets or sets the list count for the <see cref="Show" />.</summary>
        int? ListCount { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        ITraktShow Show { get; set; }
    }
}
