namespace TraktApiSharp.Objects.Get.Users
{
    public interface ITraktAccountSettings
    {
        string TimeZoneId { get; set; }

        bool? Time24Hr { get; set; }

        string CoverImage { get; set; }
    }
}
