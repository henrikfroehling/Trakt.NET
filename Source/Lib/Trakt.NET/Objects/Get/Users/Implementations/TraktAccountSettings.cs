namespace TraktNet.Objects.Get.Users
{
    using Enums;

    /// <summary>Represents Trakt user account settings.</summary>
    public class TraktAccountSettings : ITraktAccountSettings
    {
        /// <summary>Gets or sets the user's timezone.<para>Nullable</para></summary>
        public string TimeZoneId { get; set; }

        /// <summary>Gets or sets, whether an user uses the 24h time format.</summary>
        public bool? Time24Hr { get; set; }

        /// <summary>Gets or sets the user's cover image url.<para>Nullable</para></summary>
        public string CoverImage { get; set; }

        /// <summary>Gets or sets the user's token.<para>Nullable</para></summary>
        public string Token { get; set; }

        /// <summary>Gets or sets the user's date format.<para>Nullable</para></summary>
        public TraktDateFormat DateFormat { get; set; }
    }
}
