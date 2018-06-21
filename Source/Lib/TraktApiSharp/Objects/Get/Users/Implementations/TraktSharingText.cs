namespace TraktNet.Objects.Get.Users
{
    /// <summary>Represents Trakt user social media sharing text settings.</summary>
    public class TraktSharingText : ITraktSharingText
    {
        /// <summary>Gets or sets the user's sharing text for watching an item.<para>Nullable</para></summary>
        public string Watching { get; set; }

        /// <summary>Gets or sets the user's sharing text for watched items.<para>Nullable</para></summary>
        public string Watched { get; set; }
    }
}
