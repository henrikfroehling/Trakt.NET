namespace TraktNet.Objects.Get.Users
{
    /// <summary>Represents Trakt user account settings.</summary>
    public interface ITraktAccountSettings
    {
        /// <summary>Gets or sets the user's timezone.<para>Nullable</para></summary>
        string TimeZoneId { get; set; }

        /// <summary>Gets or sets, whether an user uses the 24h time format.</summary>
        bool? Time24Hr { get; set; }

        /// <summary>Gets or sets the user's cover image url.<para>Nullable</para></summary>
        string CoverImage { get; set; }

        /// <summary>Gets or sets the user's token.<para>Nullable</para></summary>
        string Token { get; set; }
    }
}
