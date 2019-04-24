namespace TraktNet.Objects.Get.Users
{
    /// <summary>Represents Trakt user social media sharing text settings.</summary>
    public interface ITraktSharingText
    {
        /// <summary>Gets or sets the user's sharing text for watching an item.<para>Nullable</para></summary>
        string Watching { get; set; }

        /// <summary>Gets or sets the user's sharing text for watched items.<para>Nullable</para></summary>
        string Watched { get; set; }
    }
}
