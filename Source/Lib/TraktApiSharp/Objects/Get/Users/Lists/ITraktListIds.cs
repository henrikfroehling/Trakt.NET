namespace TraktApiSharp.Objects.Get.Users.Lists
{
    using Basic;

    public interface ITraktListIds : IIds
    {
        uint Trakt { get; set; }

        string Slug { get; set; }
    }
}
