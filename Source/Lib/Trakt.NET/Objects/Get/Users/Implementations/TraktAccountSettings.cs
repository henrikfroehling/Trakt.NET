namespace TraktNet.Objects.Get.Users
{
    /// <summary>Represents Trakt user account settings.</summary>
    public class TraktAccountSettings : ITraktAccountSettings
    {
        /// <summary>Gets or sets the user's timezone.<para>Nullable</para></summary>
        public string TimeZoneId { get; set; }

        /// <summary>Gets or sets, whether an user uses the 24h time format.</summary>
        public bool? Time24Hr { get; set; }

        /// <summary>Gets or sets the user's cover image url.<para>Nullable</para></summary>
        public string CoverImage { get; set; }

        public string Token { get; set; }
    }
}
