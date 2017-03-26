namespace TraktApiSharp.Objects.Get.Shows
{
    public interface ITraktShowAirs
    {
        string Day { get; set; }

        string Time { get; set; }

        string TimeZoneId { get; set; }
    }
}
